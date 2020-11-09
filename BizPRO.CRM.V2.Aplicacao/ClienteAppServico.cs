using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Aplicacao.Adaptadores;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class ClienteAppServico : AppServicoDapper, IClienteAppServico
    {
        private readonly IClienteServico _servicoCliente;
        private readonly IPessoaFisicaServico _servicoPessoaFisica;
        private readonly IPessoaJuridicaServico _servicoPessoaJuridica;
        private readonly ITelefoneServico _servicoTelefone;
        private readonly ICidadeServico _servicoCidade;
        private readonly IAtividadeServico _servicoAtividade;
        private readonly IAtendimentoServico _servicoAtendimento;
        private readonly IAtividadeParteEnvolvidaServico _servicoAtividadeParteEnvolvidaServico;
        private readonly IConfiguracaoServico _configuracaoServico;
        private readonly IIntegracaoAppServico _integracaoAppServico;
        private readonly IIntegracaoControleServico _integracaoControleServico;
        private readonly ILigacaoServico _servicoLigacao;

        public ClienteAppServico(IClienteServico servicoCliente, IPessoaFisicaServico servicoPessoaFisica,
            IPessoaJuridicaServico servicoPessoaJuridica, ITelefoneServico servicoTelefone, ICidadeServico servicoCidade,
            IAtividadeServico servicoAtividade, IAtendimentoServico servicoAtendimento,
            IAtividadeParteEnvolvidaServico servicoAtividadeParteEnvolvidaServico,
            IConfiguracaoServico configuracaoServico, IIntegracaoAppServico integracaoAppServico,
            IIntegracaoControleServico integracaoControleServico, ILigacaoServico servicoLigacao)
        {
            _servicoCliente = servicoCliente;
            _servicoPessoaFisica = servicoPessoaFisica;
            _servicoPessoaJuridica = servicoPessoaJuridica;
            _servicoTelefone = servicoTelefone;
            _servicoCidade = servicoCidade;
            _servicoAtividade = servicoAtividade;
            _servicoAtendimento = servicoAtendimento;
            _servicoAtividadeParteEnvolvidaServico = servicoAtividadeParteEnvolvidaServico;
            _configuracaoServico = configuracaoServico;
            _integracaoAppServico = integracaoAppServico;
            _integracaoControleServico = integracaoControleServico;
            _servicoLigacao = servicoLigacao;
        }

        public ClienteBuscaViewModel PesquisarCliente(ClienteBuscaViewModel model)
        {
            var listaPesquisaCliente = _servicoCliente.Buscar(model.Nome, model.Documento, model.Telefone,
                model.NumeroProtocolo, model.Susep);

            if (_integracaoAppServico.ConsultarIntegracao())
            {
                //var clientesJaIntegrados = _integracaoControleServico.ObterClientesJaIntegrados(null);

                var retornoClientesIntegracao = _integracaoAppServico.ObterClientesIntegracaoPor(model.Nome,
                    model.Telefone,
                    model.Documento, null, model.CriadoPor);

                if (retornoClientesIntegracao.PessoasFisicas.Any())
                {
                    foreach (var pfIntegracao in retornoClientesIntegracao.PessoasFisicas)
                    {
                        var clienteJaExiste = listaPesquisaCliente.FirstOrDefault(x => x.Documento == pfIntegracao.Cpf);

                        if (clienteJaExiste != null)
                        {
                            clienteJaExiste.RegistroJaIntegradao = true;
                        }
                        else
                        {
                            var clientesMesmoDocumento = _servicoPessoaFisica.PesquisarPessoaFisica(null,
                                pfIntegracao.Cpf, null, null, null);

                            if (clientesMesmoDocumento != null && clientesMesmoDocumento.Any())
                            {
                                var clienteMesmoDocumento = clientesMesmoDocumento.FirstOrDefault();

                                ((List<Cliente>) listaPesquisaCliente).Add(new Cliente(clienteMesmoDocumento.Id,
                                    clienteMesmoDocumento.Nome + " " + clienteMesmoDocumento.Sobrenome,
                                    clienteMesmoDocumento.DataNascimento, "PF",
                                    clienteMesmoDocumento.Cpf, null, true, false));
                            }
                            else
                            {
                                ((List<Cliente>) listaPesquisaCliente).Add(new Cliente(0,
                                    pfIntegracao.Nome + " " + pfIntegracao.Sobrenome, pfIntegracao.DataNascimento, "PF",
                                    pfIntegracao.Cpf,
                                    pfIntegracao.IdentificadorIntegracao, pfIntegracao.JaIntegrado, true));
                            }
                        }
                    }
                }


                if (retornoClientesIntegracao.PessoasJuridicas.Any())
                {
                    var listaPessoaJuridicaIntegracaoLimpa = new List<PessoaJuridica>();

                    foreach (var pjIntegracao in retornoClientesIntegracao.PessoasJuridicas)
                    {

                        var clienteJaExiste = listaPesquisaCliente.FirstOrDefault(x => x.Documento == pjIntegracao.Cnpj);

                        if (clienteJaExiste != null)
                        {
                            clienteJaExiste.RegistroJaIntegradao = true;
                        }
                        else
                        {
                            var clientesMesmoDocumento = _servicoPessoaJuridica.PesquisarPessoaJuridica(null,
                                pjIntegracao.Cnpj, null, null, null);

                            if (clientesMesmoDocumento != null && clientesMesmoDocumento.Any())
                            {
                                var clienteMesmoDocumento = clientesMesmoDocumento.FirstOrDefault();

                                ((List<Cliente>) listaPesquisaCliente).Add(new Cliente(0,
                                    clienteMesmoDocumento.RazaoSocial,
                                    clienteMesmoDocumento.DataDeConstituicao, "PJ",
                                    clienteMesmoDocumento.Cnpj, clienteMesmoDocumento.IdentificadorIntegracao,
                                    clienteMesmoDocumento.RegistroJaIntegrado,
                                    false));
                            }
                            else
                            {
                                ((List<Cliente>) listaPesquisaCliente).Add(new Cliente(0, pjIntegracao.RazaoSocial,
                                    pjIntegracao.DataDeConstituicao, "PJ",
                                    pjIntegracao.Cnpj, pjIntegracao.IdentificadorIntegracao,
                                    pjIntegracao.RegistroJaIntegrado,
                                    true));
                            }
                        }
                    }
                }
            }

            model = ClienteAdaptador.ParaAplicacaoViewModel(model.Nome, model.Documento, model.Telefone,
                listaPesquisaCliente);
            return model;
        }

        public ClientePerfilViewModel Carregar(long? pessoaFisicaId, long? pessoaJuridicaId, bool trocarCliente)
        {
            var viewModel = new ClientePerfilViewModel();
            Cidade cidade = null;

            if (pessoaFisicaId != null)
            {
                var pessoaFisica = _servicoPessoaFisica.ObterPorId((long) pessoaFisicaId);
                if (pessoaFisica != null)
                {
                    if (pessoaFisica.CidadeId != null)
                        cidade = _servicoCidade.ObterPorId((long) pessoaFisica.CidadeId);

                    viewModel = new ClientePerfilViewModel(pessoaFisica, null, cidade, trocarCliente)
                    {
                        Telefones = _servicoTelefone.ObterTelefonePessoaFisica((long) pessoaFisicaId)
                    };
                }
            }

            if (pessoaJuridicaId != null)
            {
                var pessoaJuridica = _servicoPessoaJuridica.ObterPorId((long) pessoaJuridicaId);
                if (pessoaJuridica != null)
                {
                    if (pessoaJuridica.CidadeId != null)
                        cidade = _servicoCidade.ObterPorId((long) pessoaJuridica.CidadeId);

                    viewModel = new ClientePerfilViewModel(pessoaJuridica, null, cidade, trocarCliente)
                    {
                        Telefones = _servicoTelefone.ObterTelefonePessoaJuridica((long) pessoaJuridicaId)
                    };
                }
            }
            viewModel.Visualizar = true;
            return viewModel;
        }

        public ClienteBuscaViewModel AtualizarClienteAtividade(long atividadeId, long novoClienteId,
            string novoClienteTipo, string userId, bool clienteSomenteContato, long? atualClienteId,
            string atualClienteTipo, long? clienteTipoContato)
        {
            var retorno = new ClienteBuscaViewModel();
            long? pessoaFisicaId = null;
            long? pessoaJuridicaId = null;
            long? atualPessoaFisicaId = null;
            long? atualPessoaJuridicaId = null;

            if (string.IsNullOrEmpty(novoClienteTipo))
            {
                retorno.ValidationResult.Add(
                    new DomainValidation.Validation.ValidationError(
                        "O tipo (pf= pessoa física / pj= pessoa jurídica) não foi informado."));
                return retorno;
            }

            if (atualClienteId.HasValue)
            {
                if (string.IsNullOrEmpty(atualClienteTipo))
                {
                    retorno.ValidationResult.Add(
                        new DomainValidation.Validation.ValidationError(
                            "O tipo (pf= pessoa física / pj= pessoa jurídica) do cliente atual não foi informado."));
                    return retorno;
                }

                if (atualClienteTipo.ToUpper().Trim() == "PF")
                    atualPessoaFisicaId = atualClienteId;
                else if (atualClienteTipo.ToUpper().Trim() == "PJ")
                    atualPessoaJuridicaId = atualClienteId;
                else
                {
                    retorno.ValidationResult.Add(
                        new DomainValidation.Validation.ValidationError(
                            "O tipo informado do cliente atual não corresponde com os valores esperados:  (pf= pessoa física / pj= pessoa jurídica)"));
                    return retorno;
                }
            }


            if (novoClienteTipo.ToUpper().Trim() == "PF")
                pessoaFisicaId = novoClienteId;
            else if (novoClienteTipo.ToUpper().Trim() == "PJ")
                pessoaJuridicaId = novoClienteId;
            else
            {
                retorno.ValidationResult.Add(
                    new DomainValidation.Validation.ValidationError(
                        "O tipo informado não corresponde com os valores esperados:  (pf= pessoa física / pj= pessoa jurídica)"));
                return retorno;
            }

            // Aqui vou deletar o cliente atual do ParteEnvolvidas
            if (atualPessoaFisicaId.HasValue || atualPessoaJuridicaId.HasValue)
            {
                _servicoAtividadeParteEnvolvidaServico.Excluir(atividadeId, atualPessoaFisicaId, atualPessoaJuridicaId);
            }

            var atividade = _servicoAtividade.ObterPorId(atividadeId);
            if (atividade.AtividadeTipoId == 6)
            {
                var atividadeParteEnvolvidaCliente =
                    _servicoAtividadeParteEnvolvidaServico.ObterPorAtividadeId(atividadeId);

                foreach (var parteEnvolvidada in atividadeParteEnvolvidaCliente)
                {
                    if (parteEnvolvidada.TipoParteEnvolvida.ToLower().Trim() == "r")
                    {
                        parteEnvolvidada.SetarPessoaFisicaId(pessoaFisicaId);
                        parteEnvolvidada.SetarPessoaJuridicaId(pessoaJuridicaId);
                        _servicoAtividadeParteEnvolvidaServico.Atualizar(parteEnvolvidada);
                    }
                }

                _servicoAtividade.AtualizarCliente(atividadeId, pessoaFisicaId, pessoaJuridicaId, userId,
                    TipoParteEnvolvida.ClienteTratado.Value, false);
            }
            else
            {
                if (_servicoAtividadeParteEnvolvidaServico.PossuiClienteContato(atividadeId))
                {
                    _servicoAtividadeParteEnvolvidaServico.Adicionar(new AtividadeParteEnvolvida(atividadeId,
                        pessoaFisicaId,
                        pessoaJuridicaId, null, userId, TipoParteEnvolvida.ClienteTratado.Value, null, null));
                }
                else
                {
                    if (clienteSomenteContato)
                    {
                        _servicoAtividade.AtualizarCliente(atividadeId, pessoaFisicaId, pessoaJuridicaId, userId,
                            TipoParteEnvolvida.ClienteContato.Value);

                        if (atividade != null)
                            if (atividade.AtendimentoId.HasValue)
                                _servicoAtendimento.AtualizarClienteSomenteContato((long) atividade.AtendimentoId, true,
                                    clienteTipoContato);
                    }
                    else
                    {
                        _servicoAtividade.AtualizarCliente(atividadeId, pessoaFisicaId, pessoaJuridicaId, userId,
                            TipoParteEnvolvida.ClienteTratado.Value);
                    }
                }
            }

            retorno.PessoaJuridicaId = pessoaJuridicaId;
            retorno.PessoaFisicaId = pessoaFisicaId;
            retorno.AtividadeId = atividadeId;
            return retorno;
        }

        public IEnumerable<ClienteListaViewModel> ObterSugestoes(string nome, string documento, string telefone,
            string email, string informacaoUra, string criadoPor, bool registroComTodosCamposFornecidos = true)
        {
            var retorno = new List<ClienteListaViewModel>();
            var listaPesquisaCliente = _servicoCliente.ObterSugestoes(nome, documento, telefone, email,
                registroComTodosCamposFornecidos);

            if (_integracaoAppServico.ConsultarIntegracao())
            {

                if (telefone == "Não Identificado")
                    telefone = null;

                var retornoClientesIntegracao = _integracaoAppServico.ObterClientesIntegracaoPor(nome, telefone,
                    documento, null, criadoPor);

                if (retornoClientesIntegracao.PessoasFisicas.Any())
                {
                    var listaPessoaFisicaIntegracaoLimpa = new List<PessoaFisica>();

                    foreach (var pfIntegracao in retornoClientesIntegracao.PessoasFisicas)
                    {
                        var clienteJaExiste = listaPesquisaCliente.FirstOrDefault(x => x.Documento == pfIntegracao.Cpf);

                        if (clienteJaExiste != null)
                        {
                            clienteJaExiste.RegistroJaIntegradao = true;
                        }
                        else
                        {
                            var clientesMesmoDocumento = _servicoPessoaFisica.PesquisarPessoaFisica(null,
                                pfIntegracao.Cpf, null, null, null);

                            if (clientesMesmoDocumento != null && clientesMesmoDocumento.Any())
                            {
                                var clienteMesmoDocumento = clientesMesmoDocumento.FirstOrDefault();

                                //retorno.Add(new ClienteListaViewModel(clienteMesmoDocumento.Id,
                                //    clienteMesmoDocumento.Nome + " " + clienteMesmoDocumento.Sobrenome, "PF",
                                //    clienteMesmoDocumento.Cpf, clienteMesmoDocumento.DataNascimento,
                                //    clienteMesmoDocumento.IdentificadorIntegracao, true, false));

                                ((List<Cliente>) listaPesquisaCliente).Add(new Cliente(clienteMesmoDocumento.Id,
                                    clienteMesmoDocumento.Nome + " " + clienteMesmoDocumento.Sobrenome,
                                    clienteMesmoDocumento.DataNascimento, "PF",
                                    clienteMesmoDocumento.Cpf, null, true, false));
                            }
                            else
                            {
                                //retorno.Add(new ClienteListaViewModel(pfIntegracao.Id,
                                //    pfIntegracao.Nome + " " + pfIntegracao.Sobrenome, "PF",
                                //    pfIntegracao.Cpf, pfIntegracao.DataNascimento,
                                //    pfIntegracao.IdentificadorIntegracao, true, true));

                                ((List<Cliente>) listaPesquisaCliente).Add(new Cliente(0,
                                    pfIntegracao.Nome + " " + pfIntegracao.Sobrenome, pfIntegracao.DataNascimento, "PF",
                                    pfIntegracao.Cpf,
                                    pfIntegracao.IdentificadorIntegracao, pfIntegracao.JaIntegrado, true));
                            }
                        }



                        //var jaIntegrado = false;
                        //foreach (var clienteJaIntegrado in clientesJaIntegrados)
                        //{
                        //    if (pfIntegracao.IdentificadorIntegracao == clienteJaIntegrado.IdentificadorIntegracao)
                        //    {
                        //        jaIntegrado = true;
                        //    }
                        //}

                        //if (!jaIntegrado)
                        //    listaPessoaFisicaIntegracaoLimpa.Add(pfIntegracao);
                    }

                    //retorno.AddRange(
                    //    listaPessoaFisicaIntegracaoLimpa.Select(pfIntegracao => new ClienteListaViewModel
                    //    {
                    //        EntidadeIntegracao = true,
                    //        IdentificadorIntegracao = pfIntegracao.IdentificadorIntegracao,
                    //        Nome = pfIntegracao.Nome,
                    //        Documento = pfIntegracao.Cpf,
                    //        TipoCliente = "PF"
                    //    }));
                }


                //if (retornoClientesIntegracao.PessoasJuridicas.Any())
                //{
                //    var listaPessoaJuridicaIntegracaoLimpa = new List<PessoaJuridica>();

                //    foreach (var pjIntegracao in retornoClientesIntegracao.PessoasJuridicas)
                //    {
                //        var jaIntegrado = false;
                //        foreach (var clienteJaIntegrado in clientesJaIntegrados)
                //        {
                //            if (pjIntegracao.IdentificadorIntegracao == clienteJaIntegrado.IdentificadorIntegracao)
                //            {
                //                jaIntegrado = true;
                //            }
                //        }

                //        if (!jaIntegrado)
                //            listaPessoaJuridicaIntegracaoLimpa.Add(pjIntegracao);
                //    }


                //    retorno.AddRange(
                //        listaPessoaJuridicaIntegracaoLimpa.Select(pjIntegracao => new ClienteListaViewModel
                //        {
                //            EntidadeIntegracao = true,
                //            IdentificadorIntegracao = pjIntegracao.IdentificadorIntegracao,
                //            Nome = pjIntegracao.RazaoSocial,
                //            Documento = pjIntegracao.Cnpj,
                //            TipoCliente = "PJ"
                //        }));
                //}
            }

            if (listaPesquisaCliente == null) return retorno;

            retorno.AddRange(
                listaPesquisaCliente.Select(
                    cliente =>
                        new ClienteListaViewModel(cliente.Id, cliente.Nome, cliente.TipoCliente, cliente.Documento,
                            cliente.DataNascimento, cliente.IdentificadorIntegracao, cliente.RegistroJaIntegradao,
                            cliente.EntidadeIntegracao)));

            return retorno;
        }

        public ClienteBuscaViewModel PesquisarGenerico(long? atividadeId, bool? carregarComPost, string nomeAction,
            string nomeController, long? atualClienteId, string atualClienteTipo, bool? clienteContato, string criadoPor)
        {
            var model = new ClienteBuscaViewModel
            {
                AtividadeId = atividadeId,
                CarregarComPost = (bool) carregarComPost,
                Action = nomeAction,
                Controller = nomeController,
                AtualClienteId = atualClienteId,
                AtualClienteTipo = atualClienteTipo,
                ClienteContato = clienteContato
            };

            if (clienteContato != null && clienteContato != true) return model;

            var permitirAtendimentoTerceiro = false;
            var configuracao = new Configuracao();
            configuracao.SetarAtendimentoTerceiros();
            configuracao = _configuracaoServico.ObterPorSigla(configuracao.Sigla);

            if (configuracao != null)
                permitirAtendimentoTerceiro = configuracao.Valor == "1";

            if (permitirAtendimentoTerceiro)
            {
                model.ClienteContato = null;

                if (atividadeId.HasValue && clienteContato == null)
                {
                    if (_servicoAtividadeParteEnvolvidaServico.PossuiClienteContato((long) atividadeId))
                        model.ClienteContato = false;
                }
                else
                    model.ClienteContato = clienteContato;
            }
            else
                model.ClienteContato = false;

            return model;
        }

        public ClienteNovoViewModel NovoGenerico(long? atividadeId, bool? carregarComPost, string nomeAction,
            string nomeController, long? atualClienteId, string atualClienteTipo, bool? clienteContato)
        {
            string documento = null;

            if (atividadeId.HasValue)
            {
                var ligacao = _servicoLigacao.ObterPor(null, atividadeId.Value);

                if (ligacao != null)
                    documento = ligacao.Documento;
            }

            var model = new ClienteNovoViewModel
            {
                AtividadeId = atividadeId,
                CarregarComPost = (bool) carregarComPost,
                Action = nomeAction,
                Controller = nomeController,
                AtualClienteId = atualClienteId,
                AtualClienteTipo = atualClienteTipo,
                ClienteContato = clienteContato,
                Documento = documento
            };

            if (!atividadeId.HasValue || clienteContato != null) return model;

            if (_servicoAtividadeParteEnvolvidaServico.PossuiClienteContato((long) atividadeId))
                model.ClienteContato = false;

            return model;
        }

        public bool AbrirOcorrenciaIframe()
        {
            var retorno = false;

            /*Regra colocada em 25/10/2018 de forma emergencial para abrir ocorrência dentro de um iframe somente para a AIG....*/
            var tipoAberturaOcorrencia = _configuracaoServico.ObterTipoAberturaOcorrencia();
            if (tipoAberturaOcorrencia != null)
                if (tipoAberturaOcorrencia.Valor == "IFRAME")
                    retorno = true;

            return retorno;
        }

        public bool DocumentoPossuiCadastro(string documento, string tipoCliente)
        {
            if (string.IsNullOrEmpty(tipoCliente))
                return false;

            var retorno = false;
            documento = documento.Replace(".", "").Replace("-", "").Replace("/", "").Replace("\\", "");

            switch (tipoCliente.ToLower())
            {
                case "pf":
                    retorno = _servicoPessoaFisica.PesquisarPessoaFisica(null, documento, null, null, null).Any();
                    break;
                case "pj":
                    retorno = _servicoPessoaJuridica.PesquisarPessoaJuridica(null, documento, null, null, null).Any();
                    break;
            }

            return retorno;
        }
    }
}
