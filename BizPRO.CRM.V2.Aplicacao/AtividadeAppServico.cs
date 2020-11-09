using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class AtividadeAppServico : IAtividadeAppServico
    {
        private readonly IAtendimentoServico _atendimentoServico;
        private readonly IAtividadeServico _atividadeServico;
        private readonly ILigacaoServico _ligacaoServico;
        private readonly IStatusAtividadeServico _statusAtividadeServico;
        private readonly IAtividadeFilaServico _atividadeFilaServico;
        private readonly IAtividadeTipoServico _atividadeTipoServico;
        private readonly IFilaServico _filaServico;
        private readonly IMidiaServico _midiaServico;
        private readonly ITelefoneServico _telefoneServico;
        private readonly ITarefaServico _tarefaServico;
        private readonly IOcorrenciaServico _ocorrenciaServico;
        private readonly IOcorrenciaTipoServico _ocorrenciaTipoServico;
        private readonly IUsuarioServico _usuarioServico;
        private readonly IEmailServico _emailServico;
        private readonly IAtividadeParteEnvolvidaServico _atividadeParteEnvolvidaServico;
        private readonly ICanalServico _canalServico;
        private readonly IChatServico _chatServico;
        private readonly IAtendimentoAtividadeServico _atendimentoAtividadeServico;
        private readonly IAtividadeApoioServico _atividadeApoioServico;
        private readonly IAtividadeParteEnvolvidaServico _servicoAtividadeParteEnvolvidaServico;
        private readonly IAtividadeRepositorio _atividadeRepositorio;

        public AtividadeAppServico(IAtividadeRepositorio atividadeRepositorio, IAtendimentoServico atendimentoServico, IAtividadeServico atividadeServico,
            ILigacaoServico ligacaoServico, IStatusAtividadeServico statusAtividadeServico,
            IAtividadeFilaServico atividadeFilaServico, IFilaServico filaServico, IMidiaServico midiaServico,
            ITelefoneServico telefoneServico, ITarefaServico tarefaServico, IOcorrenciaServico ocorrenciaServico,
            IOcorrenciaTipoServico ocorrenciaTipoServico, IUsuarioServico usuarioServico, IEmailServico emailServico,
            IAtividadeParteEnvolvidaServico atividadeParteEnvolvidaServico, ICanalServico canalServico,
            IChatServico chatServico, IAtividadeTipoServico atividadeTipoServico,
            IAtendimentoAtividadeServico atendimentoAtividadeServico, IAtividadeApoioServico atividadeApoioServico, IAtividadeParteEnvolvidaServico servicoAtividadeParteEnvolvidaServico)
        {
            _atividadeRepositorio = atividadeRepositorio;
            _atendimentoServico = atendimentoServico;
            _atividadeServico = atividadeServico;
            _ligacaoServico = ligacaoServico;
            _statusAtividadeServico = statusAtividadeServico;
            _atividadeFilaServico = atividadeFilaServico;
            _filaServico = filaServico;
            _midiaServico = midiaServico;
            _telefoneServico = telefoneServico;
            _tarefaServico = tarefaServico;
            _ocorrenciaServico = ocorrenciaServico;
            _ocorrenciaTipoServico = ocorrenciaTipoServico;
            _usuarioServico = usuarioServico;
            _emailServico = emailServico;
            _atividadeParteEnvolvidaServico = atividadeParteEnvolvidaServico;
            _canalServico = canalServico;
            _chatServico = chatServico;
            _atividadeTipoServico = atividadeTipoServico;
            _atendimentoAtividadeServico = atendimentoAtividadeServico;
            _atividadeApoioServico = atividadeApoioServico;
            _servicoAtividadeParteEnvolvidaServico = servicoAtividadeParteEnvolvidaServico;
        }

        public AtividadeViewModel SalvarAtendimentoLigacao(AtividadeViewModel view)
        {
            var entidade = _atividadeServico.ObterPorId(view.id);

            entidade.PrevisaoDeExecucao = view.previsaoDeExecucao;
            entidade.Descricao = view.descricao;
            entidade.Titulo = view.titulo ?? "";
            _atividadeServico.Atualizar(entidade);
            entidade = _atividadeServico.ObterPorId(view.id);

            if (view.filaID != null)
            {
                _atividadeServico.AtualizarResponsavel(entidade.Id, null, null);
                var listaAtividadeFila =
                    _atividadeFilaServico.ObterPorAtividadeId(entidade.Id).Where(c => c.SaiuDaFilaEm == null);

                foreach (var item in listaAtividadeFila)
                {
                    _atividadeFilaServico.AtualizaSaiuDaFilaEm(item.Id);
                }
                _atividadeFilaServico.Adicionar(new AtividadeFila(entidade.Id, Convert.ToInt32(view.filaID)));
            }


            var ligacao = _ligacaoServico.ObterPorId(view.LigacaoViewModel.id);

            ligacao.PessoaFisicaId = view.LigacaoViewModel.pessoaFisicaID;
            ligacao.PessoaJuridicaId = view.LigacaoViewModel.pessoaJuridicaID == 0
                ? null
                : view.LigacaoViewModel.pessoaJuridicaID;
            ligacao.TelefoneId = view.LigacaoViewModel.telefoneID;
            ligacao.Sentido = view.LigacaoViewModel.sentido;

            var retornoLigacao = _ligacaoServico.Atualizar(ligacao);

            return new AtividadeViewModel(entidade.Id, entidade.AtividadeTipoId, view.LigacaoViewModel.pessoaFisicaID,
                view.LigacaoViewModel.pessoaJuridicaID);
        }

        public AtividadeViewModel CarregarAtividadeLigacao(AtividadeViewModel view, string userId)
        {
            var atividade = new Atividade(
                view.id
                , view.atividadeTipoID
                , view.criadoEm
                , view.criadoPorUserID
                , view.responsavelPorUserID
                , view.statusAtividadeID
                , view.ocorrenciaID
                , view.contratoID
                , view.atendimentoID
                , view.previsaoDeExecucao
                , view.finalizadoEm
                , view.finalizadoPorUserID
                , view.titulo
                , view.descricao
                , view.pessoaFisicaID
                , view.pessoaJuridicaID
                , view.potenciaisClientesID);

            var retorno = _atividadeServico.Adicionar(atividade);

            return new AtividadeViewModel(atividade.Id, atividade.AtividadeTipoId, atividade.PessoasFisicasId,
                atividade.PessoasJuridicasId);
        }

        public AtividadeViewModel ObterPorId(long atividadeId)
        {
            var entidade = _atividadeServico.ObterPorId(atividadeId);
            return new AtividadeViewModel(entidade.Id, entidade.AtividadeTipoId);
        }

        public AtividadeNewViewModel Carregar(string userId, long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potencialClientesId, long? ocorrenciaId)
        {
            var model = new AtividadeNewViewModel
            {
                pessoaFisicaID = pessoaFisicaId,
                pessoaJuridicaID = pessoaJuridicaId,
                potencialClienteID = potencialClientesId,
                ocorrenciaID = ocorrenciaId,
                criadoPor = userId
            };

            var statusAtividadeLigacao = _statusAtividadeServico.ObterStatusAtividadeLigacaoReceptiva();
            if (statusAtividadeLigacao != null)
                model.listaStatusAtividade = statusAtividadeLigacao.ToList();

            var filas = _filaServico.ObterFilasLigacao();
            if (filas != null)
                model.listaFila = new SelectList(filas, "id", "nome");

            var canal = _canalServico.ObterCanalTelefone();
            model.listaMidia = new SelectList(_midiaServico.ObterPor(null, canal.Id), "id", "nome");

            return model;
        }

        public AtividadeNewViewModel SalvarAtividade(AtividadeNewViewModel model, string userId)
        {
            switch (model.atividadeTipoID)
            {
                case 3:
                    SalvarAtividadeLigacao(model, userId);
                    break;
                case 4:
                    SalvarAtividadeEmail(model, userId);
                    break;
                case 5:
                    SalvarAtividadeTarefa(model, userId);
                    break;
            }

            return model;
        }

        protected void SalvarAtividadeLigacao(AtividadeNewViewModel model, string userId)
        {
            if (model.id == null) // Adicionar
            {
                if (model.statusAtividadeID == null)
                {
                    model.statusAtividadeID = _statusAtividadeServico.ObterStatusAtividadePadraoParaLigacao().Id;
                }

                int? canalId = null;
                var canal = _canalServico.ObterCanalTelefone();
                if (canal.ValidationResult.IsValid)
                    canalId = canal.Id;

                if (model.atendimentoID == null)
                {
                    var atendimento = _atendimentoServico.AdicionarNovoAtendimento(canalId, userId, null);

                    if (atendimento.ValidationResult.IsValid)
                    {
                        model.atendimentoID = atendimento.Id;
                    }
                }

                var atividade = new Atividade(userId, (int)model.statusAtividadeID, model.atividadeTipoID, model.titulo,
                    model.pessoaFisicaID, model.pessoaJuridicaID, model.potencialClienteID, model.ocorrenciaID,
                    model.descricao, model.atendimentoID, model.midiaID, null, null, null, model.previsaoDeExecucao,
                    canalId, userId) { PrevisaoDeExecucao = model.previsaoDeExecucao };
                model.ValidationResult = _atividadeServico.Adicionar(atividade);

                if (model.ValidationResult.IsValid)
                {
                    model.id = atividade.Id;
                    var ligacao = new Ligacao(atividade.PessoasFisicasId, atividade.PessoasJuridicasId,
                        atividade.PotenciaisClientesId, userId, model.Ligacao.sentido, atividade.Id,
                        model.Ligacao.telefoneID, null, null, null);
                    model.ValidationResult = _ligacaoServico.Adicionar(ligacao);

                    if (model.ValidationResult.IsValid)
                    {
                        if (model.filaID != null)
                        {
                            ColocarAtividadeFila((int)model.filaID, atividade.Id);
                        }
                    }

                    _servicoAtividadeParteEnvolvidaServico.Adicionar(new AtividadeParteEnvolvida(atividade.Id,
                        atividade.PessoasFisicasId, atividade.PessoasJuridicasId, null, userId,
                        TipoParteEnvolvida.ClienteTratado.Value, null, null));
                }
            }
            else //Atualizar
            {
                var atividade = _atividadeServico.ObterPorId((long)model.id);

                if (atividade != null && atividade.FinalizadoEm == null)
                {
                    if (model.statusAtividadeID != null)
                    {
                        var statusAtividade = _statusAtividadeServico.ObterPorId((long)model.statusAtividadeID);

                        if (statusAtividade != null)
                        {
                            if (statusAtividade.FinalizaAtividade)
                            {
                                atividade.FinalizadoEm = DateTime.Now;
                                atividade.FinalizadoPorUserId = userId;
                            }
                        }
                        atividade.StatusAtividadeId = (int)model.statusAtividadeID;
                    }

                    atividade.Descricao = model.descricao;

                    if (model.atendimentoID != null)
                        atividade.AtendimentoId = (long)model.atendimentoID;

                    _atividadeServico.Atualizar(atividade);
                }

                if (model.dataAgendamento != null)
                {
                    if (model.statusAtividadeID == null)
                    {
                        model.statusAtividadeID =
                            _statusAtividadeServico.ObterStatusAtividadeLigacaoReceptiva().FirstOrDefault().Id;
                    }

                    var novaAtividade = new Atividade()
                    {
                        PessoasFisicasId = atividade.PessoasFisicasId,
                        PessoasJuridicasId = atividade.PessoasJuridicasId,
                        PotenciaisClientesId = atividade.PotenciaisClientesId,
                        OcorrenciaId = atividade.OcorrenciaId,
                        CriadoPorUserId = userId,
                        ContratoId = atividade.ContratoId,
                        Descricao = model.descricao,
                        MidiasId = atividade.MidiasId,
                        StatusAtividadeId = _statusAtividadeServico.ObterStatusAtividadePadraoParaLigacao().Id,
                        AtividadeTipoId = 3,
                        Titulo = atividade.Titulo,
                        //atendimentoID = model.atendimentoID,
                        PrevisaoDeExecucao = model.dataAgendamento
                    };

                    if (model.agendamentoPrivado != null)
                        if ((bool)model.agendamentoPrivado)
                        {
                            novaAtividade.ResponsavelPorUserId = novaAtividade.CriadoPorUserId;
                        }

                    model.ValidationResult = _atividadeServico.Adicionar(novaAtividade);

                    if (model.ValidationResult.IsValid)
                    {
                        var ligacao = _ligacaoServico.BuscarPorAtividadeId(atividade.Id);

                        model.id = novaAtividade.Id;
                        var novaligacao = new Ligacao(novaAtividade.PessoasFisicasId, novaAtividade.PessoasJuridicasId,
                            novaAtividade.PotenciaisClientesId, userId, "S", novaAtividade.Id, ligacao.TelefoneId,
                            ligacao.NumeroOriginal, null, null);
                        model.ValidationResult = _ligacaoServico.Adicionar(novaligacao);

                        if (model.ValidationResult.IsValid)
                        {
                            var filaID = _atividadeFilaServico.ObterUltimoVinculoPraAtividade(atividade.Id);

                            if (filaID != null)
                                ColocarAtividadeFila(filaID.FilaId, novaAtividade.Id, novaAtividade.ResponsavelPorUserId);
                        }
                    }
                }
            }
        }

        protected void SalvarAtividadeEmail(AtividadeNewViewModel model, string userId)
        {
            //Ainda não implementado;
        }

        protected void SalvarAtividadeTarefa(AtividadeNewViewModel model, string userId)
        {
            //Ainda não implementado;
        }

        protected void ColocarAtividadeFila(int filaId, long atividadeId, string userId = null)
        {
            _atividadeServico.AtualizarResponsavel(atividadeId, userId, null);
            var listaAtividadeFila =
                _atividadeFilaServico.ObterPorAtividadeId(atividadeId).Where(c => c.SaiuDaFilaEm == null);

            foreach (var item in listaAtividadeFila)
            {
                _atividadeFilaServico.AtualizaSaiuDaFilaEm(item.Id);
            }

            _atividadeFilaServico.Adicionar(new AtividadeFila(atividadeId, filaId));
        }

        public AtividadeNewViewModel Editar(long id, string userId, bool linkFila)
        {
            if (linkFila) //Limpando Atividade da Fila atual
                _atividadeServico.AtualizarDadosAtividadeEAtividadeFila(userId, id);

            var model = new AtividadeNewViewModel();
            var atividade = _atividadeServico.ObterPorIdDal(id);

            if (atividade != null)
            {
                if (atividade.AtividadeTipoId == 3)
                {
                    var clienteTratativa = _atividadeParteEnvolvidaServico.BuscarUltimoClienteTratativa(atividade.Id);
                    if (clienteTratativa != null)
                    {
                        atividade.PessoasFisicasId = clienteTratativa.PessoasFisicasId;
                        atividade.PessoasJuridicasId = clienteTratativa.PessoasJuridicasId;
                    }
                    else
                    {
                        atividade.PessoasFisicasId = null;
                        atividade.PessoasJuridicasId = null;
                    }
                }

                model = Carregar(atividade.CriadoPorUserId, atividade.PessoasFisicasId, atividade.PessoasJuridicasId,
                    atividade.PotenciaisClientesId, atividade.OcorrenciaId);

                var clienteContato = _atividadeParteEnvolvidaServico.BuscarClienteContato(atividade.Id);
                if (clienteContato != null)
                {
                    if (clienteContato.PessoasFisicasId.HasValue)
                    {
                        model.ContatoPessoaFisicaId = (long)clienteContato.PessoasFisicasId;
                    }
                    else if (clienteContato.PessoasJuridicasId.HasValue)
                    {
                        model.ContatoPessoaJuridicaId = (long)clienteContato.PessoasJuridicasId;
                    }
                }

                model.id = atividade.Id;
                model.atendimentoID = atividade.AtendimentoId;
                model.atividadeFinalizada = atividade.FinalizadoEm != null;
                model.atividadeTipoID = (int)atividade.AtividadeTipoId;
                model.contratoID = atividade.ContratoId;
                model.criadoEm = atividade.CriadoEm;
                model.descricao = atividade.Descricao;
                model.midiaID = atividade.MidiasId;
                model.previsaoDeExecucao = atividade.PrevisaoDeExecucao;
                model.statusAtividadeID = atividade.StatusAtividadeId;
                model.titulo = atividade.Titulo;
                model.UsuarioId = atividade.UsuarioId;
                model.finalizadoEm = atividade.FinalizadoEm;

                CarregarAtividadeLigacao(model, atividade.Id);
                CarregarAtividadeTarefa(model, atividade.Id);
                CarregarAtividadeEmail(model, atividade, userId);
                CarregarAtividadeChat(model, atividade, userId);

                if (model.Ligacao.sentido.ToLower().Contains("ativa"))
                    model.listaStatusAtividade = _statusAtividadeServico.ObterStatusAtividadeLigacaoAtiva();

                var listaAtividadesFilas =
                    _atividadeFilaServico.ObterPorAtividadeId(atividade.Id).Where(c => c.SaiuDaFilaEm == null);
                if (listaAtividadesFilas.Any())
                    model.filaID = listaAtividadesFilas.OrderByDescending(c => c.EntrouNaFilaEm).FirstOrDefault().FilaId;

                if (atividade.AtendimentoId != null)
                {
                    var atendimento = _atendimentoServico.ObterPorId((long)atividade.AtendimentoId);
                    if (atendimento != null)
                    {
                        model.protocolo = atendimento.Protocolo;

                        if (atendimento.MidiasId.HasValue && atendimento.MidiasId != 0)
                        {
                            var midia = _midiaServico.ObterPorId((int)atendimento.MidiasId);
                            if (midia != null)
                            {
                                model.midia = midia.Nome;
                                model.midiaID = (int)midia.Id;
                            }
                        }
                    }
                }

                if (atividade.MidiasId != null && !model.midiaID.HasValue)
                {
                    var midia = _midiaServico.ObterPorId((int)atividade.MidiasId);
                    if (midia != null)
                        model.midia = midia.Nome;
                }

                if (atividade.OcorrenciaId != null)
                {
                    var ocorrencia = _ocorrenciaServico.ObterPorId((long)atividade.OcorrenciaId);
                    if (ocorrencia != null)
                    {
                        if (!model.pessoaFisicaID.HasValue)
                            model.pessoaFisicaID = ocorrencia.PessoaFisicaId;

                        if (!model.pessoaJuridicaID.HasValue)
                            model.pessoaJuridicaID = ocorrencia.PessoaJuridicaId;

                        var ocorrenciaTipo = _ocorrenciaTipoServico.ObterPorId(ocorrencia.OcorrenciasTiposId);
                        if (ocorrenciaTipo != null)
                            model.referente = ocorrenciaTipo.NomeExibicao;
                    }
                }

                var statusAtividade = _statusAtividadeServico.ObterPorId(atividade.StatusAtividadeId);
                if (statusAtividade != null)
                {
                    model.nomeStatusAtividade = statusAtividade.Descricao;
                    model.atividadeFinalizada = statusAtividade.FinalizaAtividade;
                }

                var criadoPor = _usuarioServico.ObterPorUserId(atividade.CriadoPorUserId);
                if (criadoPor != null)
                    model.criadoPor = criadoPor.Nome.ToUpper();

                var responsavel =
                    _usuarioServico.ObterPorUserId(string.IsNullOrEmpty(atividade.ResponsavelPorUserId)
                        ? atividade.CriadoPorUserId
                        : atividade.ResponsavelPorUserId);
                if (responsavel != null)
                    model.responsavel = responsavel.Nome.ToUpper();

                model.podeEditar = string.IsNullOrEmpty(atividade.ResponsavelPorUserId)
                    ? atividade.CriadoPorUserId == userId
                    : atividade.ResponsavelPorUserId == userId;


                if (!string.IsNullOrEmpty(atividade.FinalizadoPorUserId))
                {
                    var usuarioFinalizador = _usuarioServico.ObterPorUserId(atividade.FinalizadoPorUserId);
                    if (usuarioFinalizador != null)
                    {
                        model.UsuarioFinalizador = usuarioFinalizador.Nome;
                    }
                }
            }
            else
                model.ValidationResult.Add(
                    new DomainValidation.Validation.ValidationError(
                        "Não foram encontradas atividades para o ID informado."));

            return model;
        }

        protected void CarregarAtividadeLigacao(AtividadeNewViewModel model, long atividadeId)
        {
            var ligacao = _ligacaoServico.BuscarPorAtividadeId(atividadeId);

            if (ligacao != null)
            {
                if (!string.IsNullOrEmpty(ligacao.NumeroOriginal))
                    model.Ligacao.numeroOriginal = ligacao.NumeroOriginal;

                model.Ligacao.sentido = ligacao.Sentido == "E" ? "Ligação Receptiva" : "Ligação Ativa";
                model.Ligacao.telefoneID = ligacao.TelefoneId;
                model.Ligacao.ligacaoID = ligacao.Id;

                if (ligacao.TelefoneId != null)
                {
                    var telefone = _telefoneServico.ObterPorId((long)ligacao.TelefoneId);
                    if (telefone != null)
                        model.Ligacao.telefoneFormatado = telefone.ToString();
                }
                else
                    model.Ligacao.telefoneFormatado = model.Ligacao.numeroOriginal;
            }
        }

        protected void CarregarAtividadeTarefa(AtividadeNewViewModel model, long atividadeId)
        {
            var tarefa = _tarefaServico.BuscarPorAtividadeId(atividadeId);

            if (tarefa != null)
            {
                model.Tarefa.TarefaId = tarefa.Id;
                model.Tarefa.CriadoEm = tarefa.CriadoEm;
                model.Tarefa.AtividadeId = tarefa.AtividadeId;
                model.Tarefa.Descricao = tarefa.Descricao;
                model.Tarefa.ResponsavelPorUserId = tarefa.ResponsavelPorUserId;
                model.listaStatusAtividade = _statusAtividadeServico.ObterStatusAtividadeTarefa();
            }
        }

        protected void CarregarAtividadeChat(AtividadeNewViewModel model, Atividade atividade, string userId)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<Chat>(f => f.AtividadeId, Operator.Eq, atividade.Id));
            var chatAtividade = _chatServico.ObterPor(where);

            if (!chatAtividade.Any()) return;

            var chat = _chatServico.ObterPorId(chatAtividade.FirstOrDefault().Id);
            if (chat.Id <= 0) return;
            model.Chat = new ChatViewModel(atividade.Id, chat.Id, atividade.AtendimentoId,
                atividade.PessoasJuridicasId, atividade.PessoasFisicasId, atividade.StatusAtividadeId);
            model.listaStatusAtividade = _statusAtividadeServico.ObterStatusAtividadeChat();

            if (atividade.AtendimentoId != null) return;
            var canal = _canalServico.ObterPorNome("CHAT");
            var atendimento = new Atendimento(userId, _atendimentoServico.GerarNumeroProtocolo(DateTime.Now),
                canal != null ? canal.FirstOrDefault().Id : (int?) null, null);
            _atendimentoServico.Adicionar(atendimento);
            atividade.Atendimento = atendimento;

            atividade.AtendimentoId = atendimento.Id;
            model.atendimentoID = atendimento.Id;
            _atividadeServico.Atualizar(atividade);
        }

        protected void CarregarAtividadeEmail(AtividadeNewViewModel model, Atividade atividade, string userId)
        {
            var email = _emailServico.ObterEmailCompletoPor(null, atividade.Id);

            if (email == null) return;

            var envolvidos = _atividadeParteEnvolvidaServico.ObterPorAtividadeId(atividade.Id);
            model.Email = new EmailViewModel(email.AtividadeId, email.Id, email.CorpoDoEmail, email.Texto,
                email.Assunto, email.CriadoEm, email.Atividade.CriadoEm, envolvidos, email.Sentido);

            if (!string.IsNullOrEmpty(email.Sentido))
            {
                model.listaStatusAtividade = email.Sentido.Trim().ToLower() == "s" ? _statusAtividadeServico.ObterStatusAtividadeEmailEnviado() : _statusAtividadeServico.ObterStatusAtividadeEmailRecebido();
            }

            var canal = _canalServico.ObterPorNome("email");
            if (canal != null)
            {
                model.listaMidia = new SelectList(_midiaServico.ObterPor(null, canal.FirstOrDefault().Id), "id",
                    "nome");
            }

            if (email.Atividade.AtendimentoId != null) return;

            var atendimento = new Atendimento(userId, _atendimentoServico.GerarNumeroProtocolo(DateTime.Now),
                canal != null ? canal.FirstOrDefault().Id : (int?)null, null);
            _atendimentoServico.Adicionar(atendimento);
            atividade.Atendimento = atendimento;

            atividade.AtendimentoId = atendimento.Id;
            model.atendimentoID = atendimento.Id;
            _atividadeServico.Atualizar(atividade);

            var atendimentoAtividade = new AtendimentoAtividade(atividade.Id, atendimento.Id);
            _atendimentoAtividadeServico.Adicionar(atendimentoAtividade);
        }

        public StatusAtividade ObterStatusAtividade(long id)
        {
            return _statusAtividadeServico.ObterPorId(id);
        }

        public long ObterAtividadeTipoPorNome(string nome)
        {
            var atividadeTipoEntity = _atividadeTipoServico.BuscarPorNome(nome);
            if (atividadeTipoEntity == null) return 0;
            var firstOrDefault = atividadeTipoEntity;
            return firstOrDefault != null ? firstOrDefault.Id : 0;
        }

        public long ObterAtividadeStatusPorNome(string nome, string atividadeValida)
        {
            var atividadeStatusEntity = _statusAtividadeServico.ObterStatusAtividade(nome, atividadeValida);
            if (!atividadeStatusEntity.Any()) return 0;
            var firstOrDefault = atividadeStatusEntity.FirstOrDefault();
            return firstOrDefault != null ? firstOrDefault.Id : 0;
        }

        public IEnumerable<AtividadeListaViewModel> ObterPor(AtividadeFilterViewModel viewModel)
        {
            var retorno = new List<AtividadeListaViewModel>();
            var atividades = _atividadeApoioServico.ObterPor(viewModel.AtividadeTipoId, viewModel.DataInicio,
                viewModel.CriadoPorId, viewModel.StatusAtividadeId, viewModel.OcorrenciaId, viewModel.ContratoId,
                viewModel.AtendimentoId, viewModel.PrevisaoDeExecucao, viewModel.PessoaFisicaId,
                viewModel.PessoaJuridicaId, viewModel.PotencialClienteId, viewModel.CanalId, viewModel.MidiaId,
                viewModel.ResponsavelPorId, viewModel.FilaId, viewModel.Protocolo, viewModel.SituacaoId,
                viewModel.AtividadeEmFila, viewModel.DepartamentoId);

            if (atividades == null)
                return retorno;

            retorno.AddRange(
                atividades.Select(
                    atividade =>
                        new AtividadeListaViewModel(atividade.AtividadeId, atividade.Fila, atividade.Tipo,
                            atividade.Referente, atividade.Cliente, atividade.Responsavel, atividade.Titulo,
                            atividade.Status, atividade.CriadoEm, atividade.PrevisaoDeExecucao,
                            atividade.PossuiSlaAtribuicao, atividade.PossuiSlaFechamento, atividade.AtrasadoAtribuicao,
                            atividade.AtrasadoFechamento, atividade.MotivoOcorrencia, atividade.AtividadeFinalizada)));

            return retorno;
        }

        public IEnumerable<ContatoViewModel> ObterContatos(long? pessoaFisicaId, long? pessoaJuridicaId, int? quantidade)
        {
            var retorno = new List<ContatoViewModel>();
            var atividades = _atividadeServico.ObterAtividadesPorCliente(pessoaFisicaId, pessoaJuridicaId, quantidade);

            if (atividades == null) return retorno;

            foreach (var atividade in atividades)
            {
                atividade.StatusAtividade = _statusAtividadeServico.ObterPorId(atividade.StatusAtividadeId);
                if (atividade.AtividadeTipoId != null)
                    atividade.AtividadeTipo = _atividadeTipoServico.ObterPorId((long)atividade.AtividadeTipoId);
                retorno.Add(new ContatoViewModel(atividade));
            }

            return retorno;
        }

        public AtividadeViewModel AlteraDataPrevisaoAtividade(DateTime data, long atividadeId)
        {
            var retorno = Mapper.Map<AtividadeViewModel>(_atividadeRepositorio.AlteraDataPrevisaoAtividade(data, atividadeId));
            return retorno;
        }
    }
}

