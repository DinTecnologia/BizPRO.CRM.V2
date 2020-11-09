using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Core.ValueObjects;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class ChatAppServico : AppServicoDapper, IChatAppServico
    {
        private readonly IAtividadeServico _atividadeServico;
        private readonly IAtendimentoServico _atendimentoServico;
        private readonly IClienteServico _clienteServico;
        private readonly IPessoaFisicaServico _pessoaFisicaServico;
        private readonly IPessoaJuridicaServico _pessoaJuridicaServico;
        private readonly IChatMensagemServico _chatMensagensServico;
        private readonly IStatusAtividadeServico _statusAtividadeServico;
        private readonly IAtividadeTipoServico _atividadeTipoServico;
        private readonly IChatUraServico _chatUraServico;
        private readonly ICanalServico _canalServico;
        private readonly IMidiaServico _midiaServico;
        private readonly IChatServico _chatServico;
        private readonly IEntidadeServico _entidadeServico;
        private readonly IChatSolicitacaoServico _chatSolicitacaoServico;

        public ChatAppServico(IAtividadeServico atividadeServico, IAtendimentoServico atendimentoServico,
            IClienteServico clienteServico, IPessoaFisicaServico pessoaFisicaServico,
            IPessoaJuridicaServico pessoaJuridicaServico, IChatMensagemServico chatMensagensServico,
            IStatusAtividadeServico statusAtividadeServico, IAtividadeTipoServico atividadeTipoServico,
            IChatUraServico chatUraServico, ICanalServico canalServico, IMidiaServico midiaServico,
            IChatServico chatServico, IEntidadeServico entidadeServico, IChatSolicitacaoServico chatSolicitacaoServico)
        {
            _atividadeServico = atividadeServico;
            _atendimentoServico = atendimentoServico;
            _clienteServico = clienteServico;
            _pessoaFisicaServico = pessoaFisicaServico;
            _pessoaJuridicaServico = pessoaJuridicaServico;
            _chatMensagensServico = chatMensagensServico;
            _statusAtividadeServico = statusAtividadeServico;
            _atividadeTipoServico = atividadeTipoServico;
            _chatUraServico = chatUraServico;
            _canalServico = canalServico;
            _midiaServico = midiaServico;
            _chatServico = chatServico;
            _entidadeServico = entidadeServico;
            _chatSolicitacaoServico = chatSolicitacaoServico;
        }

        public ChatViewModel AdicionarAtendimento(string userId, string k)
        {
            var viewModel = new ChatViewModel();
            var statusAtividade = _statusAtividadeServico.ObterStatusAtividadeChat();
            var tipoAtividade = _atividadeTipoServico.BuscarPorNome("Chat");
            var canal = _canalServico.ObterPorNome("chat");
            var atividade = new Atividade();
            if (!string.IsNullOrEmpty(k))
                atividade = _atividadeServico.ObterPorId(Convert.ToInt64(k));

            if (atividade.AtendimentoId != null)
            {
                var retornoAtendimento = _atendimentoServico.ObterPorId(atividade.AtendimentoId.Value);
                retornoAtendimento.CanalOrigemId = 4;
                _atendimentoServico.Atualizar(retornoAtendimento);
                if (statusAtividade.Any() && tipoAtividade != null)
                {
                    if (atividade.Id > 0)
                    {
                        atividade.AtendimentoId = retornoAtendimento.Id;
                        _atividadeServico.Atualizar(atividade);
                    }

                    IEnumerable<Cliente> listaCliente = new List<Cliente>();

                    if (atividade.PessoasJuridicasId.HasValue)
                    {
                        var pj = _pessoaJuridicaServico.ObterPorId(atividade.PessoasJuridicasId.Value);
                        if (pj != null)
                        {
                            atividade.PessoasJuridicasId = pj.Id;
                            _atividadeServico.Atualizar(atividade);
                            listaCliente = _clienteServico.ObterSugestoes(pj.NomeFantasia, pj.Cnpj, null, null);
                            viewModel.Popular(statusAtividade, retornoAtendimento.Protocolo, listaCliente,
                                retornoAtendimento.Id, null,
                                atividade.PessoasJuridicasId.Value, pj.NomeFantasia);
                        }
                    }

                    if (atividade.PessoasFisicasId.HasValue)
                    {
                        var pf = _pessoaFisicaServico.ObterPorId(atividade.PessoasFisicasId.Value);
                        if (pf != null)
                        {
                            atividade.PessoasFisicasId = pf.Id;
                            _atividadeServico.Atualizar(atividade);
                            listaCliente = _clienteServico.ObterSugestoes(pf.Nome, pf.Cpf, null, null);
                            viewModel.Popular(statusAtividade, retornoAtendimento.Protocolo, listaCliente,
                                retornoAtendimento.Id,
                                atividade.PessoasFisicasId.Value, null, pf.Nome);
                        }
                    }
                    else
                        viewModel.Popular(statusAtividade, retornoAtendimento.Protocolo, listaCliente,
                            retornoAtendimento.Id, null,
                            null, null);
                }
                else
                    viewModel.ValidationResult.Add(
                        new ValidationError("Não possui StatusAtividade Cadastrado."));
            }
            else if (statusAtividade.Any() && tipoAtividade != null)
            {
                var atendimento = new Atendimento(userId, _atendimentoServico.GerarNumeroProtocolo(DateTime.Now), null,
                    null);
                var firstOrDefault = canal.FirstOrDefault();
                if (firstOrDefault != null) atendimento.CanalOrigemId = firstOrDefault.Id;
                var atendimentoAux = _atendimentoServico.Adicionar(atendimento);
                if (!atendimentoAux.IsValid) return viewModel;

                if (atividade.Id > 0)
                {
                    atividade.AtendimentoId = atendimento.Id;
                    _atividadeServico.Atualizar(atividade);
                }

                IEnumerable<Cliente> listaCliente = new List<Cliente>();

                if (atividade.PessoasJuridicasId.HasValue)
                {
                    var pj = _pessoaJuridicaServico.ObterPorId(atividade.PessoasJuridicasId.Value);
                    if (pj != null)
                    {
                        atividade.PessoasJuridicasId = pj.Id;
                        _atividadeServico.Atualizar(atividade);
                        listaCliente = _clienteServico.ObterSugestoes(pj.NomeFantasia, pj.Cnpj, null, null);
                        viewModel.Popular(statusAtividade, atendimento.Protocolo, listaCliente, atendimento.Id, null,
                            atividade.PessoasJuridicasId.Value, pj.NomeFantasia);
                    }
                }

                if (atividade.PessoasFisicasId.HasValue)
                {
                    var pf = _pessoaFisicaServico.ObterPorId(atividade.PessoasFisicasId.Value);
                    if (pf != null)
                    {
                        atividade.PessoasFisicasId = pf.Id;
                        _atividadeServico.Atualizar(atividade);
                        listaCliente = _clienteServico.ObterSugestoes(pf.Nome, pf.Cpf, null, null);
                        viewModel.Popular(statusAtividade, atendimento.Protocolo, listaCliente, atendimento.Id,
                            atividade.PessoasFisicasId.Value, null, pf.Nome);
                    }
                }
                else
                    viewModel.Popular(statusAtividade, atendimento.Protocolo, listaCliente, atendimento.Id, null,
                        null, null);
            }
            else
                viewModel.ValidationResult.Add(
                    new ValidationError("Não possui StatusAtividade Cadastrado."));

            return viewModel;
        }

        public ChatViewModel AdicionarAtendimentoMessenger(string userId, string k)
        {
            var viewModel = new ChatViewModel();
            var statusAtividade = _statusAtividadeServico.ObterStatusAtividadeMessenger();
            var tipoAtividade = _atividadeTipoServico.BuscarPorNome("Chat");
            var canal = _canalServico.ObterPorNome("chat");
            var atividade = new Atividade();
            if (!string.IsNullOrEmpty(k))
                atividade = _atividadeServico.ObterPorId(Convert.ToInt64(k));

            if (atividade.AtendimentoId != null)
            {
                var retornoAtendimento = _atendimentoServico.ObterPorId(atividade.AtendimentoId.Value);
                retornoAtendimento.CanalOrigemId = 4;
                _atendimentoServico.Atualizar(retornoAtendimento);
                if (statusAtividade.Any() && tipoAtividade != null)
                {
                    //var Atendimento = new Atendimento(userId, _atendimentoServico.ObterNumeroProtocolo(DateTime.Now), null);
                    //var AtendimentoAux = _atendimentoServico.Adicionar(Atendimento);
                    //if (!AtendimentoAux.IsValid) return viewModel;

                    if (atividade.Id > 0)
                    {
                        atividade.AtendimentoId = retornoAtendimento.Id;
                        _atividadeServico.Atualizar(atividade);
                    }

                    IEnumerable<Cliente> ListaCliente = new List<Cliente>();
                    var pj = new PessoaJuridica();
                    var pf = new PessoaFisica();

                    if (atividade != null)
                    {
                        if (atividade.PessoasJuridicasId.HasValue)
                        {
                            pj = _pessoaJuridicaServico.ObterPorId(atividade.PessoasJuridicasId.Value);
                            if (pj != null)
                            {
                                atividade.PessoasJuridicasId = pj.Id;
                                _atividadeServico.Atualizar(atividade);
                                ListaCliente = _clienteServico.ObterSugestoes(pj.NomeFantasia, pj.Cnpj, null, null);
                                viewModel.Popular(statusAtividade, retornoAtendimento.Protocolo, ListaCliente,
                                    retornoAtendimento.Id, null,
                                    atividade.PessoasJuridicasId.Value, pj.NomeFantasia);
                            }
                        }

                        if (atividade.PessoasFisicasId.HasValue)
                        {
                            pf = _pessoaFisicaServico.ObterPorId(atividade.PessoasFisicasId.Value);
                            if (pf != null)
                            {
                                atividade.PessoasFisicasId = pf.Id;
                                _atividadeServico.Atualizar(atividade);
                                ListaCliente = _clienteServico.ObterSugestoes(pf.Nome, pf.Cpf, null, null);
                                viewModel.Popular(statusAtividade, retornoAtendimento.Protocolo, ListaCliente,
                                    retornoAtendimento.Id,
                                    atividade.PessoasFisicasId.Value, null, pf.Nome);
                            }
                        }
                        else
                            viewModel.Popular(statusAtividade, retornoAtendimento.Protocolo, ListaCliente,
                                retornoAtendimento.Id, null,
                                null, null);
                    }
                    else
                        viewModel.Popular(statusAtividade, retornoAtendimento.Protocolo, ListaCliente,
                            retornoAtendimento.Id, null, null, null);
                }
                else
                    viewModel.ValidationResult.Add(
                        new ValidationError("Não possui StatusAtividade Cadastrado."));
            }
            else if (statusAtividade.Any() && tipoAtividade != null)
            {
                var Atendimento = new Atendimento(userId, _atendimentoServico.GerarNumeroProtocolo(DateTime.Now), null,
                    null);
                var firstOrDefault = canal.FirstOrDefault();
                if (firstOrDefault != null) Atendimento.CanalOrigemId = firstOrDefault.Id;
                var AtendimentoAux = _atendimentoServico.Adicionar(Atendimento);
                if (!AtendimentoAux.IsValid) return viewModel;

                if (atividade.Id > 0)
                {
                    atividade.AtendimentoId = Atendimento.Id;
                    _atividadeServico.Atualizar(atividade);
                }

                IEnumerable<Cliente> ListaCliente = new List<Cliente>();
                var pj = new PessoaJuridica();
                var pf = new PessoaFisica();

                if (atividade != null)
                {
                    if (atividade.PessoasJuridicasId.HasValue)
                    {
                        pj = _pessoaJuridicaServico.ObterPorId(atividade.PessoasJuridicasId.Value);
                        if (pj != null)
                        {
                            atividade.PessoasJuridicasId = pj.Id;
                            _atividadeServico.Atualizar(atividade);
                            ListaCliente = _clienteServico.ObterSugestoes(pj.NomeFantasia, pj.Cnpj, null, null);
                            viewModel.Popular(statusAtividade, Atendimento.Protocolo, ListaCliente, Atendimento.Id,
                                null,
                                atividade.PessoasJuridicasId.Value, pj.NomeFantasia);
                        }
                    }

                    if (atividade.PessoasFisicasId.HasValue)
                    {
                        pf = _pessoaFisicaServico.ObterPorId(atividade.PessoasFisicasId.Value);
                        if (pf != null)
                        {
                            atividade.PessoasFisicasId = pf.Id;
                            _atividadeServico.Atualizar(atividade);
                            ListaCliente = _clienteServico.ObterSugestoes(pf.Nome, pf.Cpf, null, null);
                            viewModel.Popular(statusAtividade, Atendimento.Protocolo, ListaCliente, Atendimento.Id,
                                atividade.PessoasFisicasId.Value, null, pf.Nome);
                        }
                    }
                    else
                        viewModel.Popular(statusAtividade, Atendimento.Protocolo, ListaCliente, Atendimento.Id, null,
                            null, null);
                }
                else
                    viewModel.Popular(statusAtividade, Atendimento.Protocolo, ListaCliente, Atendimento.Id, null, null,
                        null);
            }
            else
                viewModel.ValidationResult.Add(
                    new ValidationError("Não possui StatusAtividade Cadastrado."));

            return viewModel;
        }

        public ChatViewModel BuscarMsg(long chatId)
        {
            var viewModel = new ChatViewModel();
            var chatMsg = _chatMensagensServico.ObterMensagensChat(chatId);

            if (chatMsg.Any())
            {
                foreach (var mensagem in chatMsg)
                {
                    var nomeEnvolvido = mensagem.Nome;
                    var ehAgente = false;

                    if (mensagem.AtividadeParteEnvolvida != null)
                    {
                        nomeEnvolvido = mensagem.AtividadeParteEnvolvida.Nome.ToUpper();

                        if (!string.IsNullOrEmpty(mensagem.AtividadeParteEnvolvida.AspNetUsersId))
                        {
                            ehAgente = true;
                        }
                    }

                    mensagem.Mensagem = viewModel.FormatarMsgChat(nomeEnvolvido, mensagem.Mensagem, mensagem.CriadoEm,
                        ehAgente, mensagem.ArquivoId);
                }

                viewModel.ChatMsg = new List<ChatMensagemViewModel>();
                viewModel.ChatMsg.AddRange(chatMsg.Select(c => new ChatMensagemViewModel
                {
                    Id = c.Id,
                    ChatId = c.ChatId,
                    mensagem = c.Mensagem,
                    //sentido = c.Sentido,
                    tipo = c.Tipo,
                    ArquivoID = c.ArquivoId,
                    criadoEm = c.CriadoEm,
                    //conectorCodigo = c.ConectorCodigo,
                    dataHora = c.CriadoEm.ToString("dd/MM/yyyy HH:mm")
                }));
            }
            else
                viewModel.ValidationResult.Add(
                    new ValidationError("Não possui Mensagens trocadas."));

            return viewModel;
        }

        public ChatMensagemUraViewModel BuscarChatUraPadrao(long atividadeId)
        {
            //var chatUra = _chatUraServico.ObterUraPadrao(atividadeId).FirstOrDefault();
            var chatUra = _chatUraServico.ObterUra(atividadeId, null, null);

            if (chatUra == null)
                return new ChatMensagemUraViewModel();

            return new ChatMensagemUraViewModel(chatUra);
        }

        public ChatMensagemUraViewModel BuscarChatUra(long atividadeId, long chatUraId, int ordem)
        {
            //var chatUra = _chatUraServico.ObterUra(atividadeId, chatUraId, ordem).FirstOrDefault();
            var chatUra = _chatUraServico.ObterUra(atividadeId, chatUraId, ordem);

            if (chatUra == null)
                return new ChatMensagemUraViewModel();

            return new ChatMensagemUraViewModel(chatUra);
        }

        public AtendimentoChatViewModel Carregar(long atividadeId, string usuarioId)
        {
            var viewModel = new AtendimentoChatViewModel();
            var atividade = _atividadeServico.ObterPorId(atividadeId);

            if (atividade == null)
            {
                viewModel.ValidationResult.Add(
                    new ValidationError(string.Format("Nenhuma atividade encontrada com o Id {0}.", atividadeId)));
                return viewModel;
            }

            var canal = _canalServico.ObterPorNome("CHAT").FirstOrDefault();
            viewModel.AtividadeId = atividadeId;
            viewModel.PessoaFisicaId = atividade.PessoasFisicasId;
            viewModel.PessoaJuridicaId = atividade.PessoasJuridicasId;
            viewModel.ListaStatus = _statusAtividadeServico.ObterPor(canal.Id, "E", null).ToList();
            viewModel.Midias = new SelectList(_midiaServico.ObterPor(null, canal.Id), "id", "nome");

            if (!atividade.AtendimentoId.HasValue) return viewModel;

            var atendimento = _atendimentoServico.ObterPorId((long) atividade.AtendimentoId);
            viewModel.Protocolo = atendimento.Protocolo;
            viewModel.AtendimentoId = atendimento.Id;
            var chat = _chatServico.ObterPorAtividadeId(atividadeId);

            if (chat != null)
            {
                viewModel.Mensagens = _chatMensagensServico.ObterMensagensChat(chat.Id);
            }

            return viewModel;
        }

        public ChatClienteViewModel RegistrarChatRequisicao(ChatClienteViewModel viewModel)
        {
            var chatRequisicao = _chatServico.RegistrarSolicitacao(viewModel.CampanhaId, viewModel.FilaId,
                viewModel.ConexaoClienteId, viewModel.Nome, viewModel.Documento);

            if (!chatRequisicao.ValidationResult.IsValid)
            {
                viewModel.ValidationResult = chatRequisicao.ValidationResult;
                return viewModel;
            }

            viewModel.ChatRequisicaoId = chatRequisicao.Id;

            return viewModel;
        }

        public long ObterEntidadeChatId()
        {
            var retorno = _entidadeServico.ObterPorNomeLogico("chat");
            return retorno != null ? retorno.Id : 0;
        }

        public AtendimentoFormViewModel CarregarChat(long? chatId, long? atividadeId)
        {
            Chat chat = null;
            if (!chatId.HasValue)
            {
                if (atividadeId.HasValue)
                {
                    chat = _chatServico.ObterPorAtividadeId((long) atividadeId);

                    if (chat != null)
                        chatId = chat.Id;
                }
            }

            var model = new AtendimentoFormViewModel
            {
                CanalId = (int) CanalValueObjects.Chat,
                NomeCanal = "Chat",
                ChatId = chatId,
                AtendimentoChat = true
            };

            if (chat == null)
                chat = _chatServico.ObterPorId((long) chatId);

            if (chat == null)
            {
                model.ValidationResult.Add(new ValidationError("Nenhum Chat encontrado com o Id Informado"));
                return model;
            }

            var atividade = _atividadeServico.ObterPorId(chat.AtividadeId);
            if (atividade == null)
            {
                model.ValidationResult.Add(
                    new ValidationError("Nenhuma Atividade encontrado com o Id: " + chat.AtividadeId));
                return model;
            }


            var statusAtividade = _statusAtividadeServico.ObterPorId(atividade.StatusAtividadeId);


            var atendimento = _atendimentoServico.ObterPorId(atividade.AtendimentoId.Value);
            if (atendimento == null)
            {
                model.ValidationResult.Add(
                    new ValidationError("Nenhum Atendimento encontrado com o Id: " + atividade.AtendimentoId));
                return model;
            }

            var chatSolicitacao = _chatSolicitacaoServico.ObterPorId(chat.ChatSolicitacaoId);

            if (chatSolicitacao != null)
            {
                model.Documento = chatSolicitacao.Documento;
            }

            model.ListaStatus = _statusAtividadeServico.ObterPor(model.CanalId, model.Sentido ?? "E", null).ToList();
            model.Midias = new SelectList(_midiaServico.ObterPor(null, model.CanalId), "id", "nome");
            model.Procotolo = atendimento.Protocolo;
            model.AtendimentoId = atendimento.Id;
            model.AtividadeId = atividade.Id;
            model.MidiaId = atendimento.MidiasId;
            model.PessoaFisicaId = atividade.PessoasFisicasId;
            model.PessoaJuridicaId = atividade.PessoasJuridicasId;
            model.AtendimentoFinalizado = atividade.FinalizadoEm.HasValue;
            model.Status = statusAtividade != null ? statusAtividade.Descricao : null;
            return model;
        }

        public bool ChatOnline(int? filaId)
        {
            return _chatServico.Online(filaId);
        }

        public ICollection<ChatMensagem> ListarMensagens(long chatId)
        {
            return _chatMensagensServico.ObterMensagensChat(chatId);
        }

        public bool MensagemNaoLidaAgente(long chatId, string usuarioId)
        {
            var retorno = false;
            var ultimaMensagemChat = _chatMensagensServico.UltimaMensagemChat(chatId);

            if (ultimaMensagemChat == null ||
                ultimaMensagemChat.AtividadeParteEnvolvida == null) return retorno;

            if (ultimaMensagemChat.AtividadeParteEnvolvida.AspNetUsersId != usuarioId || string.IsNullOrEmpty(
                    ultimaMensagemChat.AtividadeParteEnvolvida.AspNetUsersId))
                retorno = true;

            return retorno;
        }
    }
}
