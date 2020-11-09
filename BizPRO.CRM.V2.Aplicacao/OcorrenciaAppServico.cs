using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using BizPRO.CRM.V2.Aplicacao.Adaptadores;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class OcorrenciaAppServico : AppServicoDapper, IOcorrenciaAppServico
    {
        private readonly IOcorrenciaServico _servicoOcorrencia;
        private readonly IOcorrenciaTipoServico _servicoOcorrenciaTipo;
        private readonly IContratoServico _servicoContrato;
        private readonly IStatusEntidadeServico _servicoStatusEntidade;
        private readonly IOcorrenciaTiposXOcorrenciaServico _ocorrenciaTiposXOcorrenciaServico;
        private readonly IPessoaFisicaServico _servicoPessoaFisica;
        private readonly IPessoaJuridicaServico _servicoPessoaJuridica;
        private readonly ICidadeServico _servicoCidadeServico;
        private readonly IAnotacaoServico _servicoAnotacao;
        private readonly IAtendimentoOcorrenciaServico _servicoAtendimentoOcorrencia;
        private readonly IUsuarioServico _servicoUsuario;
        private readonly IOcorrenciaLocalTipoAtendimentoServico _servicoOcorrenciaLocalTipoAtendimento;
        private readonly ICampoDinamicoServico _servicoCampoDinamico;
        private readonly ICampoDinamicoPreenchidoServico _servicoCampoDinamicoPreenchido;
        private readonly ILocalServico _servicoLocal;
        private readonly IAtendimentoServico _servicoAtendimento;
        private readonly IConfiguracaoServico _servicoConfiguracao;
        private readonly IOcorrenciaAcompanhamentoServico _servicoOcorrenciaAcompanhamento;
        private readonly IDepartamentoServico _departamentoServico;

        private string _camposFilhos = "";
        readonly IViewDinamicaAppServico _viewDinamicaAppServico;

        private ClientePerfilViewModel _cliente;

        public OcorrenciaAppServico
        (
            IOcorrenciaServico servicoOcorrencia
            , IOcorrenciaTipoServico servicoOcorrenciaTipo
            , IContratoServico servicoContrato
            , IStatusEntidadeServico servicoStatusEntidade
            , IOcorrenciaTiposXOcorrenciaServico ocorrenciaTiposXOcorrenciaServico
            , IPessoaFisicaServico servicoPessoaFisica
            , IPessoaJuridicaServico servicoPessoaJuridica
            , ICidadeServico servicoCidadeServico
            , IAnotacaoServico servicoAntacao, IAtendimentoOcorrenciaServico servicoAtendimentoOcorrencia
            , IUsuarioServico servicoUsuario
            , IViewDinamicaAppServico viewDinamicaAppServico
            , IOcorrenciaLocalTipoAtendimentoServico servicoOcorrenciaLocalTipoAtendimento
            , ICampoDinamicoServico servicoCampoDinamico
            , ICampoDinamicoPreenchidoServico servicoCampoDinamicoPreenchido
            , ILocalServico servicoLocal
            , IAtendimentoServico servicoAtendimento
            , IConfiguracaoServico servicoConfiguracao
            , IOcorrenciaAcompanhamentoServico servicoOcorrenciaAcompanhamento
            , IDepartamentoServico departamentoServico
        )
        {
            _servicoOcorrencia = servicoOcorrencia;
            _servicoOcorrenciaTipo = servicoOcorrenciaTipo;
            _servicoContrato = servicoContrato;
            _servicoStatusEntidade = servicoStatusEntidade;
            _ocorrenciaTiposXOcorrenciaServico = ocorrenciaTiposXOcorrenciaServico;
            _servicoPessoaFisica = servicoPessoaFisica;
            _servicoPessoaJuridica = servicoPessoaJuridica;
            _servicoCidadeServico = servicoCidadeServico;
            _servicoAnotacao = servicoAntacao;
            _servicoAtendimentoOcorrencia = servicoAtendimentoOcorrencia;
            _servicoUsuario = servicoUsuario;
            _viewDinamicaAppServico = viewDinamicaAppServico;
            _servicoOcorrenciaLocalTipoAtendimento = servicoOcorrenciaLocalTipoAtendimento;
            _servicoCampoDinamico = servicoCampoDinamico;
            _servicoCampoDinamicoPreenchido = servicoCampoDinamicoPreenchido;
            _servicoLocal = servicoLocal;
            _servicoAtendimento = servicoAtendimento;
            _servicoConfiguracao = servicoConfiguracao;
            _servicoOcorrenciaAcompanhamento = servicoOcorrenciaAcompanhamento;
            _departamentoServico = departamentoServico;
        }

        public OcorrenciaFormViewModel Carregar(long? pessoaFisicaId, long? pessoaJuridicaId, long? atendimentoId,
            long? contratoId)
        {
            var listaOcorrenciaTipo = _servicoOcorrenciaTipo.ObterOcorrenciasPai().Where(w => w.Ativo);
            var listaContrato = _servicoContrato.ObterContratosNovaOcorrencia(pessoaFisicaId, pessoaJuridicaId);
            var viewDinamicaModel = _viewDinamicaAppServico.Carregar("OCORRENCIA", "padrão", null, null, true);
            var nomeCampoChave1 = _servicoConfiguracao.ObterNomeCampoChave1Ocorrencia();
            var valorCampoChave1 = _servicoConfiguracao.ObterValorPadraoCampoChave1Ocorrencia();
            var model = new OcorrenciaFormViewModel(listaOcorrenciaTipo, listaContrato, pessoaFisicaId, pessoaJuridicaId,
                null, atendimentoId, null, null, viewDinamicaModel, null, valorCampoChave1, nomeCampoChave1,
                string.IsNullOrEmpty(valorCampoChave1), contratoId);

            if (atendimentoId == null) return model;

            var atendimento = _servicoAtendimento.ObterPorId((long)atendimentoId);
            model.NumeroProtocolo = atendimento.Protocolo;

            ///*Regra colocada em 25/10/2018 de forma emergencial para abrir ocorrência dentro de um iframe somente para a AIG....*/
            //var tipoAberturaOcorrencia = _servicoConfiguracao.ObterTipoAberturaOcorrencia();
            //if (tipoAberturaOcorrencia != null)
            //    if (tipoAberturaOcorrencia.Valor == "IFRAME")
            //        model.CarregadaEmIframe = true;

            return model;
        }

        public OcorrenciaFormViewModel Adicionar(OcorrenciaFormViewModel model, string usuarioId)
        {
            var ocorrencia = OcorrenciaAdaptador.ParaDominioModelo(model);

            if (model.statusEntidadeID.HasValue)
            {
                ocorrencia.StatusEntidadesId = (long)model.statusEntidadeID;
            }
            else
            {
                var statusEntidades = _servicoStatusEntidade.ObterStatusEntidadeNovaOcorrencia();

                if (statusEntidades.Any())
                    ocorrencia.StatusEntidadesId = statusEntidades.FirstOrDefault().id;
                else
                {
                    model.ValidationResult.Add(
                        new ValidationError(
                            "Não foi possível cadastrar a Ocorrência, StatusEntidadeNovaOcorrencia não cadastrado"));
                    return model;
                }
            }

            _servicoOcorrencia.Adicionar(ocorrencia);
            model.OcorrenciaID = ocorrencia.Id;

            if (ocorrencia.Id > 0 && model.atendimentoID != null)
                _servicoAtendimentoOcorrencia.Adicionar((long)model.atendimentoID, ocorrencia.Id);

            if (ocorrencia.Id > 0)
            {
                //Inserir Ocorrência Endereço
                if (model.EnderecoProduto != null)
                {
                    if (model.EnderecoProduto.LocaisTiposAtendimentoId != null)
                    {
                        var entidade = new OcorrenciaLocalTipoAtendimento(ocorrencia.Id,
                            (int)model.EnderecoProduto.LocaisId, (int)model.EnderecoProduto.LocaisTiposAtendimentoId,
                            model.EnderecoProduto.Logradouro, model.EnderecoProduto.Numero, model.EnderecoProduto.Cep,
                            model.EnderecoProduto.Bairro, model.EnderecoProduto.CidadesId, model.criadoPorUserID,
                            model.EnderecoProduto.Complemento);
                        _servicoOcorrenciaLocalTipoAtendimento.Adicionar(entidade);
                    }
                }

                //Campos Dinamicos
                if (model.ViewDinamica != null)
                {
                    model.ViewDinamica.ChaveEntidadeId = ocorrencia.Id;
                    _viewDinamicaAppServico.Atualizar(model.ViewDinamica, usuarioId);
                }
            }

            return model;
        }

        public OcorrenciaFormViewModel CarregarListas(OcorrenciaFormViewModel viewModel, long? pessoaFisicaId,
            long? pessoaJuridicaId)
        {
            viewModel.ListaOcorrenciaTipo = _servicoOcorrenciaTipo.ObterOcorrenciasPai();
            viewModel.ListaContrato = _servicoContrato.ObterContratosNovaOcorrencia(pessoaFisicaId, pessoaJuridicaId);
            return viewModel;
        }

        public OcorrenciaFormViewModel CarregarVisualizar(long ocorrenciaId)
        {
            var ocorrencia = _servicoOcorrencia.ObterPorId(ocorrenciaId);

            if (ocorrencia != null)
            {
                var pessoaFisica = new PessoaFisica();
                var pessoaJuridica = new PessoaJuridica();
                var Cidade = new Cidade();
                var statusEntidade = new StatusEntidade();

                var viewModel = new OcorrenciaFormViewModel
                {
                    OcorrenciaID = ocorrenciaId,
                    OcorrenciaTiposXOcorrencia =
                        _ocorrenciaTiposXOcorrenciaServico.ObterDadosOcorrenciaTiposXOcorrencia(ocorrenciaId),
                    atualizadoEm = ocorrencia.AtualizadoEm,
                    criadoEm = ocorrencia.CriadoEm,
                    StatusEntidade = _servicoStatusEntidade.ObterPorId(ocorrencia.StatusEntidadesId)
                };

                statusEntidade = ocorrencia.StatusEntidadesId > 0
                    ? _servicoStatusEntidade.ObterPorId(ocorrencia.StatusEntidadesId)
                    : null;

                viewModel.StatusEntidade = statusEntidade;
                viewModel.criadoEm = ocorrencia.CriadoEm;
                viewModel.atualizadoEm = ocorrencia.AtualizadoEm;

                if (ocorrencia.PessoaFisicaId != null)
                {
                    pessoaFisica = _servicoPessoaFisica.ObterPorId((long)ocorrencia.PessoaFisicaId);

                    if (pessoaFisica.CidadeId != null)
                    {
                        Cidade = _servicoCidadeServico.ObterPorId((long)pessoaFisica.CidadeId);
                    }

                    _cliente = new ClientePerfilViewModel(pessoaFisica, "", Cidade, false);
                    pessoaJuridica = null;
                }
                else if (ocorrencia.PessoaJuridicaId != null)
                {
                    pessoaJuridica = _servicoPessoaJuridica.ObterPorId((long)ocorrencia.PessoaJuridicaId);
                    if (pessoaJuridica.CidadeId != null)
                    {
                        Cidade = _servicoCidadeServico.ObterPorId((long)pessoaJuridica.CidadeId);
                    }
                    _cliente = new ClientePerfilViewModel(pessoaJuridica, "", Cidade, false);
                    pessoaFisica = null;
                }

                _cliente.Visualizar = true;
                viewModel.Cliente = _cliente;

                //Carregar Local
                var local = _servicoLocal.ObterLocalPorOcorrenciaId(ocorrencia.Id);
                if (local != null)
                {
                    string nomeCidade = "";
                    string nomeEstado = "";

                    if (local.LocalOcorrencia.CidadesId != null)
                    {
                        var cidade = _servicoCidadeServico.ObterPorId((int)local.LocalOcorrencia.CidadesId);
                        if (cidade != null)
                        {
                            nomeCidade = cidade.Nome;
                            nomeEstado = cidade.Uf;
                        }
                    }

                    var enderecoProduto = new EnderecoProdutoViewModel(local.LocalOcorrencia.Logradouro,
                        local.LocalOcorrencia.Numero, local.LocalOcorrencia.Cep, local.LocalOcorrencia.Bairro,
                        nomeCidade, nomeEstado, local.LocalOcorrencia.Complemento);
                    var local2 = new LocalViewModel(local.nome, local.LocalTipo.Nome, local.logradouro, local.numero,
                        local.bairro, local.cidade, local.estado, local.cep, local.telefone01, local.telefone02,
                        local.telefone03, local.email01, local.email02, local.webSite, enderecoProduto.EnderecoCompleto,
                        local.LocalOcorrencia.LocalTipoAtendimento.nome);
                    viewModel.Local = local2;
                }

                return viewModel;
            }
            var validacaoRetorno = new ValidationResult();
            validacaoRetorno.Add(new ValidationError("Nenhuma ocorrência encontrada com os parâmetros informados."));
            return new OcorrenciaFormViewModel { ValidationResult = validacaoRetorno };
        }

        public IEnumerable<OcorrenciaTipoDdlViewModel> CarregarOcorrenciaTipoGravadas(long id)
        {
            return ObterOcorrenciaTipoDdlViewModelEdicao(id);
        }

        public OcorrenciaFormViewModel ObterPorId(long id, string userId, long? atendimentoId)
        {
            var ocorrencia = _servicoOcorrencia.ObterOcorrenciaCompletaPorId(id);

            if (ocorrencia != null)
            {
                var listaAnotacao = _servicoAnotacao.ObterPorOcorrenciaId(id);
                var listaContrato = _servicoContrato.ObterContratosNovaOcorrencia(ocorrencia.PessoaFisicaId,
                    ocorrencia.PessoaJuridicaId);
                var ddLsOcorrenciaTipo = ObterOcorrenciaTipoDdlViewModel(ocorrencia.OcorrenciasTiposId);
                var ocorrenciaTipo = _servicoOcorrenciaTipo.ObterPorId(ocorrencia.OcorrenciasTiposId);
                var podeEditar = string.IsNullOrEmpty(ocorrencia.ResponsavelPorAspNetUserId)
                    ? ocorrencia.CriadoPorUserId == userId
                    : ocorrencia.ResponsavelPorAspNetUserId == userId;

                if (podeEditar)
                {
                    if (ocorrencia.StatusEntidade != null)
                    {
                        if (ocorrencia.StatusEntidade.finalizador)
                            podeEditar = false;
                    }
                }

                var viewDinamicaModel = _viewDinamicaAppServico.Carregar("OCORRENCIA", "padrão", null, ocorrencia.Id,
                    podeEditar);
                var statusEntidade = ocorrencia.StatusEntidadesId > 0
                    ? _servicoStatusEntidade.ObterPorId(ocorrencia.StatusEntidadesId)
                    : null;

                //DateTime? previsao = null;

                //if (ocorrenciaTipo != null)
                //{
                //    if (ocorrenciaTipo.TempoPrevistoAtendimento > 0)
                //    {
                //        previsao = ocorrencia.CriadoEm.AddMinutes(ocorrenciaTipo.TempoPrevistoAtendimento);
                //    }
                //}

                var usuarioFinalizador = string.Empty;

                if (!string.IsNullOrEmpty(ocorrencia.FinalizadoPorUserId))
                {
                    var finalizadoPor = _servicoUsuario.ObterPorUserId(ocorrencia.FinalizadoPorUserId);

                    if (finalizadoPor != null)
                    {
                        usuarioFinalizador = finalizadoPor.Nome;
                    }
                }


                var nomeCampoChave1 = _servicoConfiguracao.ObterNomeCampoChave1Ocorrencia();
                var valorCampoChave1 = _servicoConfiguracao.ObterValorPadraoCampoChave1Ocorrencia();
                var retorno = new OcorrenciaFormViewModel(null, listaContrato, ocorrencia, listaAnotacao, statusEntidade,
                    atendimentoId, ddLsOcorrenciaTipo, null, ocorrenciaTipo.VincularLocal, viewDinamicaModel, podeEditar,
                    ocorrencia.PrevisaoInicial, ocorrencia.CampoChave1, nomeCampoChave1,
                    string.IsNullOrEmpty(valorCampoChave1),
                    usuarioFinalizador);


                ///*Regra colocada em 25/10/2018 de forma emergencial para abrir ocorrência dentro de um iframe somente para a AIG....*/
                //var tipoAberturaOcorrencia = _servicoConfiguracao.ObterTipoAberturaOcorrencia();
                //if (tipoAberturaOcorrencia != null)
                //    if (tipoAberturaOcorrencia.Valor == "IFRAME")
                //        retorno.CarregadaEmIframe = true;

                //Carregar Local
                var local = _servicoLocal.ObterLocalPorOcorrenciaId(ocorrencia.Id);
                if (local == null) return retorno;

                var nomeCidade = "";
                var nomeEstado = "";

                if (local.LocalOcorrencia.CidadesId != null)
                {
                    var cidade = _servicoCidadeServico.ObterPorId((int)local.LocalOcorrencia.CidadesId);
                    if (cidade != null)
                    {
                        nomeCidade = cidade.Nome;
                        nomeEstado = cidade.Uf;
                    }
                }

                var enderecoProduto = new EnderecoProdutoViewModel(local.LocalOcorrencia.Logradouro,
                    local.LocalOcorrencia.Numero, local.LocalOcorrencia.Cep, local.LocalOcorrencia.Bairro,
                    nomeCidade, nomeEstado, local.LocalOcorrencia.Complemento);
                var local2 = new LocalViewModel(local.nome, local.LocalTipo.Nome, local.logradouro, local.numero,
                    local.bairro, local.cidade, local.estado, local.cep, local.telefone01, local.telefone02,
                    local.telefone03, local.email01, local.email02, local.webSite, enderecoProduto.EnderecoCompleto,
                    local.LocalOcorrencia.LocalTipoAtendimento.nome);
                retorno.Local = local2;

                return retorno;
            }
            var validacaoRetorno = new ValidationResult();
            validacaoRetorno.Add(new ValidationError("Nenhuma ocorrência encontrada com os parâmetros informados."));
            return new OcorrenciaFormViewModel { ValidationResult = validacaoRetorno };
        }

        public OcorrenciaFormViewModel Atualizar(OcorrenciaFormViewModel model, string usuarioId)
        {
            var ocorrencia = _servicoOcorrencia.ObterPorId((long)model.OcorrenciaID);
            ocorrencia.OcorrenciasTiposId = (long)model.ocorrenciasTiposID;
            ocorrencia.ContratoId = model.contratoID;
            ocorrencia.DecritivoDeAbertura = model.decritivoDeAbertura;
            ocorrencia.AtualizadoEm = DateTime.Now;
            ocorrencia.AtualizadoPorAspNetUserId = model.atualizadoPorAspNetUserID;
            var resultado = _servicoOcorrencia.Atualizar(ocorrencia);

            if (resultado.IsValid)
            {
                var ocorrenciaTipo = _servicoOcorrenciaTipo.ObterPorId(ocorrencia.OcorrenciasTiposId);

                if (model.LocalExcluido || (ocorrenciaTipo.VincularLocal == false))
                {
                    _servicoOcorrenciaLocalTipoAtendimento.DeletarTodosLocaisDaOcorrencia(ocorrencia.Id);
                }

                //Campos Dinamicos
                if (model.ViewDinamica != null)
                {
                    model.ViewDinamica.ChaveEntidadeId = ocorrencia.Id;
                    _viewDinamicaAppServico.Atualizar(model.ViewDinamica, usuarioId);
                }

                /// Inserir e/ou Atualizar Endereço Local
                if (model.EnderecoProduto != null)
                {
                    if (model.EnderecoProduto.LocaisTiposAtendimentoId != null)
                    {
                        var entidade = new OcorrenciaLocalTipoAtendimento(ocorrencia.Id,
                            (int)model.EnderecoProduto.LocaisId, (int)model.EnderecoProduto.LocaisTiposAtendimentoId,
                            model.EnderecoProduto.Logradouro, model.EnderecoProduto.Numero, model.EnderecoProduto.Cep,
                            model.EnderecoProduto.Bairro, model.EnderecoProduto.CidadesId,
                            model.atualizadoPorAspNetUserID, model.EnderecoProduto.Complemento);
                        _servicoOcorrenciaLocalTipoAtendimento.DeletarTodosLocaisDaOcorrencia(ocorrencia.Id);
                        _servicoOcorrenciaLocalTipoAtendimento.Adicionar(entidade);
                    }
                }
            }

            return model;
        }

        public OcorrenciaFormViewModel CarregarDadosMinhasOcorrencia(string userId)
        {
            var view = new OcorrenciaFormViewModel
            {
                dataInicio = DateTime.Now,
                dataFim = DateTime.Now,
                ListarOcorrenciaTipo = ListarOcorrenciaTipoOcorrencia(userId)
            };

            return view;
        }

        public IEnumerable<OcorrenciaTipoViewModel> ListarOcorrenciaTipoOcorrencia(string userId)
        {
            var lista = _servicoOcorrenciaTipo.ListarOcorrenciaTipoOcorrencia(userId);

            return
                lista.Select(
                    item =>
                        new OcorrenciaTipoViewModel(item.Id, item.Nome, item.OcorrenciasTiposPaiId, item.CriadoEm,
                            item.NomeExibicao, item.Ativo, item.AtrasadoAtendimento)).ToList();
        }

        public OcorrenciaFormViewModel ObterOcorrenciasHistoricoCliente(long? pessoaFisicaId, long? pessoaJuridicaId)
        {
            var minhaLista = new List<OcorrenciaListaItemViewModel>();
            var view = new OcorrenciaFormViewModel();
            var listaOcorrencia = _servicoOcorrencia.BuscarOcorrenciasCliente(pessoaFisicaId, pessoaJuridicaId, null);
            var vincularOcorrenciaAtendimentoManual = _servicoConfiguracao.VincularOcorrenciaAtendimentoManual();

            if (listaOcorrencia != null)
                minhaLista.AddRange(
                    listaOcorrencia.Select(
                        ocorrencia =>
                            new OcorrenciaListaItemViewModel(ocorrencia, null, null, vincularOcorrenciaAtendimentoManual,
                                false, pessoaFisicaId, pessoaJuridicaId, ocorrencia.Finalizada)));
            view.ListaOcorrenciaCliente = minhaLista;
            return view;
        }

        public SelectList ObterOcorrenciasTipo(long ocorrenciasTipoPaiId)
        {
            return new SelectList(_servicoOcorrenciaTipo.ObterPor(ocorrenciasTipoPaiId), "id", "nome");
        }

        protected IEnumerable<OcorrenciaTipoDdlViewModel> ObterOcorrenciaTipoDdlViewModel(long ocorrenciaTipoId)
        {
            var retorno = new List<OcorrenciaTipoDdlViewModel>();
            var ocorrenciaTipo = _servicoOcorrenciaTipo.ObterPorId(ocorrenciaTipoId);
            var contador = 1;

            foreach (var item in ocorrenciaTipo.EstruturaDeIDs.Split('|'))
            {
                long id;
                long.TryParse(item, out id);

                if (id > 0)
                {
                    ocorrenciaTipo = _servicoOcorrenciaTipo.ObterPorId(id);
                    if (ocorrenciaTipoId == 0) break;
                    IEnumerable<OcorrenciaTipo> listaOpcao;

                    if (contador == 1)
                    {
                        var listaOpcaoItem = _servicoOcorrenciaTipo.ObterOcorrenciasPai().ToList();
                        if (listaOpcaoItem.FirstOrDefault(w => w.Id == ocorrenciaTipo.Id) == null)
                        {
                            listaOpcaoItem.Add(ocorrenciaTipo);
                        }
                        listaOpcao = listaOpcaoItem;
                    }
                    else
                    {
                        if (ocorrenciaTipo.OcorrenciasTiposPaiId != null)
                        {
                            var listaOpcaoItem =
                                _servicoOcorrenciaTipo.ObterPor((long)ocorrenciaTipo.OcorrenciasTiposPaiId).ToList();
                            if (listaOpcaoItem.FirstOrDefault(w => w.Id == ocorrenciaTipo.Id) == null)
                            {
                                listaOpcaoItem.Add(ocorrenciaTipo);
                            }
                            listaOpcao = listaOpcaoItem;
                        }
                        else
                            listaOpcao = null;
                    }

                    retorno.Add(new OcorrenciaTipoDdlViewModel(contador,
                        new SelectList(listaOpcao, "id", "nome", id.ToString()), id.ToString()));
                }
                contador++;
            }
            return retorno;
        }

        public bool VincularLocal(long ocorrenciasTipoId)
        {
            var ocorrenciaTipo = _servicoOcorrenciaTipo.ObterPorId(ocorrenciasTipoId);
            return ocorrenciaTipo.VincularLocal;
        }

        public IEnumerable<OcorrenciaListaItemViewModel> ObterOcorrenciasLocalPorUserId(string userId)
        {
            var ocorrencias = _servicoOcorrencia.ObterOcorrenciasLocalPorUserId(userId);
            var retorno = new List<OcorrenciaListaItemViewModel>();
            var vincularOcorrenciaAtendimentoManual = _servicoConfiguracao.VincularOcorrenciaAtendimentoManual();

            if (ocorrencias == null) return retorno.ToArray();

            retorno.AddRange(
                ocorrencias.Select(
                    ocorrencia =>
                        new OcorrenciaListaItemViewModel(ocorrencia, null, null, vincularOcorrenciaAtendimentoManual,
                            false, null, null, ocorrencia.Finalizada)));

            return retorno.ToArray();
        }

        protected IEnumerable<OcorrenciaTipoDdlViewModel> ObterOcorrenciaTipoDdlViewModelEdicao(long ocorrenciaTipoId)
        {
            var retorno = new List<OcorrenciaTipoDdlViewModel>();
            var ocorrenciaTipo = _servicoOcorrenciaTipo.ObterPorId(ocorrenciaTipoId);
            var contador = 1;

            foreach (var item in ocorrenciaTipo.EstruturaDeIDs.Split('|'))
            {
                long id;
                long.TryParse(item, out id);


                if (id > 0)
                {
                    ocorrenciaTipo = _servicoOcorrenciaTipo.ObterPorId(id);
                    IEnumerable<OcorrenciaTipo> listaOpcao;

                    if (contador == 1)
                    {
                        var listaOpcaoItem = _servicoOcorrenciaTipo.ObterOcorrenciasPai().ToList();
                        if (listaOpcaoItem.FirstOrDefault(w => w.Id == ocorrenciaTipo.Id) == null)
                        {
                            listaOpcaoItem.Add(ocorrenciaTipo);
                        }
                        listaOpcao = listaOpcaoItem.Where(c => c.Id != ocorrenciaTipoId);
                    }
                    else
                    {
                        if (ocorrenciaTipo.OcorrenciasTiposPaiId != null)
                        {
                            var listaOpcaoItem =
                                _servicoOcorrenciaTipo.ObterPor((long)ocorrenciaTipo.OcorrenciasTiposPaiId).ToList();
                            if (listaOpcaoItem.FirstOrDefault(w => w.Id == ocorrenciaTipo.Id) == null)
                            {
                                listaOpcaoItem.Add(ocorrenciaTipo);
                            }
                            listaOpcao = listaOpcaoItem.Where(c => c.Id != ocorrenciaTipoId);
                        }
                        else
                            listaOpcao = null;
                    }

                    retorno.Add(new OcorrenciaTipoDdlViewModel(contador,
                        new SelectList(listaOpcao, "id", "nome", id.ToString()), id.ToString()));
                }
                contador++;
            }
            return retorno;
        }

        public void AdicionarOcorrenciaAtendimento(long atendimentoId, long ocorrenciaId)
        {
            _servicoAtendimentoOcorrencia.Adicionar(atendimentoId, ocorrenciaId);
        }

        public object SelectDinamicoExportacaoOcorrencia(string campos, string[] dinamicos, string[] dinamicosContrato,
            string userId, string dataInicial, string dataFinal, string status, string cliente, long? ocorrenciaTipoId)
        {
            DateTime data;
            DateTime? dataInicio;
            DateTime? dataFim;

            if (DateTime.TryParse(dataInicial, out data))
                dataInicio = data;
            else
                dataInicio = null;

            if (DateTime.TryParse(dataFinal, out data))
                dataFim = data;
            else
                dataFim = null;

            var ocorrencias = _servicoOcorrencia.SelectDinamicoExportacaoOcorrencia(campos, userId, dataInicio, dataFim,
                status, cliente, ocorrenciaTipoId);
            var dt = ocorrencias.Tables[0];

            foreach (var dados in dinamicos)
            {
                if (dados == "")
                    break;

                var campo =
                    ListarCamposDinamicos()
                        .CamposDinamicosOcorrencia.FirstOrDefault(c => c.id == Convert.ToInt64(dados));

                dt = GeraTabela(dt, campo, ocorrencias, dados);
            }

            foreach (var dados in dinamicosContrato)
            {
                if (dados == "")
                    break;

                var campo =
                    ListarCamposDinamicos().CamposDinamicosContrato.FirstOrDefault(c => c.id == Convert.ToInt64(dados));
                dt = GeraTabela(dt, campo, ocorrencias, dados);
            }
            return dt;
        }

        private DataTable GeraTabela(DataTable dt, camposDinamicosViewModel campo, DataSet data, string dados)
        {
            var nomeColuna = campo.nome;
            dt.Columns.Add(nomeColuna, typeof(object));

            foreach (DataRow item in data.Tables[0].Rows)
            {
                var idCampoDinamico = item["id"].ToString();

                _camposFilhos = "";
                var filho =
                    _servicoCampoDinamicoPreenchido.ObterRespostasCamposDinamicosPorEntidade(Convert.ToInt64(dados),
                        Convert.ToInt64(idCampoDinamico));
                if (!filho.Any())
                {
                    _camposFilhos += "";
                }
                else
                {
                    foreach (var i in filho)
                    {
                        if (i.CampoDinamicoOpcao != null)
                        {
                            if (i.CampoDinamicoOpcao.Id > 0)
                                _camposFilhos += i.CampoDinamicoOpcao.Nome + ",";
                            else
                                _camposFilhos += i.ValorPreenchido;
                        }
                        else
                            _camposFilhos += "";
                    }
                }

                if (_camposFilhos != "")
                    if (_camposFilhos.Substring(_camposFilhos.Length - 1, 1) == ",")
                        item[nomeColuna] = _camposFilhos.Substring(0, _camposFilhos.Length - 1);
                    else
                        item[nomeColuna] = _camposFilhos;
                else
                    item[nomeColuna] = _camposFilhos;
            }

            return dt;
        }

        public OcorrenciaExportacaoCamposDinamicosViewModel ListarCamposDinamicos()
        {
            var dinamicosViewModel = new OcorrenciaExportacaoCamposDinamicosViewModel();
            var modal = _servicoCampoDinamico.ObterCamposDinamicosPorEntidade("OCORRENCIA");

            var camposDinamicosOcorrenciaViewModel =
                modal.Select(item => new camposDinamicosViewModel(item.Id, item.Nome, item.Ativo)).ToList();

            dinamicosViewModel.CamposDinamicosOcorrencia = camposDinamicosOcorrenciaViewModel;

            modal = _servicoCampoDinamico.ObterCamposDinamicosPorEntidade("CONTRATOS");

            var camposDinamicosContratoViewModel =
            (from item in modal
             where item.Id != 0
             select new camposDinamicosViewModel(item.Id, item.Nome, item.Ativo)).ToList();

            dinamicosViewModel.CamposDinamicosContrato = camposDinamicosContratoViewModel;

            return dinamicosViewModel;
        }

        public ValidationResult ExcluirLocalOcorrencia(long ocorrenciaId)
        {
            return _servicoOcorrenciaLocalTipoAtendimento.DeletarTodosLocaisDaOcorrencia(ocorrenciaId);
        }

        public string ObterNomeExibicaoOcorrenciaTipoSelecionado(long ocorrenciaTipoId)
        {
            return _servicoOcorrenciaTipo.ObterPorId(ocorrenciaTipoId).NomeExibicao;
        }

        public OcorrenciaLaudoViewModel OcorrenciaLaudo(string userId, string protocolo, string cliente,
            long? ocorrenciaTipoId)
        {
            var ocorrenciaLaudo = new OcorrenciaLaudoViewModel();
            var ocorrencias = _servicoOcorrencia.ObterOcorrenciasLocal(userId, "", "", null, null);
            var retorno = new List<OcorrenciaListaItemViewModel>();

            if (ocorrencias != null)
            {
                var vincularOcorrenciaAtendimentoManual = _servicoConfiguracao.VincularOcorrenciaAtendimentoManual();
                retorno.AddRange(
                    ocorrencias.Select(
                        ocorrencia =>
                            new OcorrenciaListaItemViewModel(ocorrencia, null, null, vincularOcorrenciaAtendimentoManual,
                                false, null, null, ocorrencia.Finalizada)));
            }
            ocorrenciaLaudo.OcorrenciaLaudoLista = retorno;
            return ocorrenciaLaudo;
        }

        public IEnumerable<OcorrenciaListaItemViewModel> ObterOcorrenciasLocal(string userId, string protocolo,
            string cliente, long? ocorrenciaTipoId, string documento)
        {
            var ocorrencias = _servicoOcorrencia.ObterOcorrenciasLocal(userId, protocolo, cliente, ocorrenciaTipoId,
                documento);
            var retorno = new List<OcorrenciaListaItemViewModel>();
            var vincularOcorrenciaAtendimentoManual = _servicoConfiguracao.VincularOcorrenciaAtendimentoManual();

            retorno.AddRange(
                ocorrencias.Select(
                    ocorrencia =>
                        new OcorrenciaListaItemViewModel(ocorrencia, null, null, vincularOcorrenciaAtendimentoManual,
                            false, null, null, ocorrencia.Finalizada)));

            return retorno.ToArray();
        }

        public OcorrenciaDetalheViewModel ObterOcorrenciaDetalhe(long id)
        {
            var model = new OcorrenciaDetalheViewModel();

            try
            {
                var ocorrencia = _servicoOcorrencia.ObterPorId(id);

                if (ocorrencia != null)
                {
                    var ocorrenciaTipo = _servicoOcorrenciaTipo.ObterPorId(ocorrencia.OcorrenciasTiposId);
                    var criadoPor = _servicoUsuario.ObterPorUserId(ocorrencia.CriadoPorUserId);
                    string finalizadoPor = null;

                    if (!string.IsNullOrEmpty(ocorrencia.AtualizadoPorAspNetUserId))
                        finalizadoPor = _servicoUsuario.ObterPorUserId(ocorrencia.AtualizadoPorAspNetUserId).Nome;

                    model.Popular(ocorrencia.CriadoEm, criadoPor.Nome, ocorrencia.AtualizadoEm, finalizadoPor,
                        ocorrenciaTipo.NomeExibicao, ocorrencia.Id);
                }
            }
            catch
            {
            }

            return model;
        }

        public IEnumerable<OcorrenciaListaItemViewModel> BuscarOcorrenciasCliente(long? pessoaFisicaId,
            long? pessoaJuridicaId, long? potencialClienteId, long? atendimentoId)
        {
            var retorno = new List<OcorrenciaListaItemViewModel>();
            if (pessoaFisicaId == null && pessoaJuridicaId == null && potencialClienteId == null)
                return retorno;

            var ocorrencias = _servicoOcorrencia.BuscarOcorrenciasCliente(pessoaFisicaId, pessoaJuridicaId,
                potencialClienteId);
            if (ocorrencias == null) return retorno;

            var vincularOcorrenciaAtendimentoManual = _servicoConfiguracao.VincularOcorrenciaAtendimentoManual();

            IEnumerable<AtendimentoOcorrencia> ocorrenciasAtendimento = new List<AtendimentoOcorrencia>();

            if (atendimentoId.HasValue)
                ocorrenciasAtendimento =
                    _servicoAtendimentoOcorrencia.ObterOcorrenciasVinculadasAoAtendimento(atendimentoId.Value);


            foreach (var ocorrencia in ocorrencias)
            {
                //var possuiVinculoAtendimentoId = false;

                ////if (atendimentoId != null)
                ////    possuiVinculoAtendimentoId = _servicoAtendimentoOcorrencia.PossuiVinculo((long) atendimentoId,
                ////        ocorrencia.Id);

                var possuiVinculoAtendimentoId = ocorrenciasAtendimento.Any(x => x.OcorrenciasId == ocorrencia.Id);

                retorno.Add(new OcorrenciaListaItemViewModel(ocorrencia, atendimentoId, null,
                    vincularOcorrenciaAtendimentoManual, possuiVinculoAtendimentoId, pessoaFisicaId, pessoaJuridicaId,
                    ocorrencia.Finalizada));
            }
            return retorno;
        }

        public OcorrenciaViewModel Index(string usuarioId)
        {
            var listaDepartamento = _departamentoServico.ObterTodos();

            if (string.IsNullOrEmpty(usuarioId))
            {
                var listaUsuarios = _servicoUsuario.ObterUsuariosOcorrencia();
                var listaOcorrenciaTipo = _servicoOcorrenciaTipo.ListarOcorrenciaTipoOcorrencia(null);
                var model = new OcorrenciaViewModel(new SelectList(listaOcorrenciaTipo, "id", "nomeExibicao"),
                    new SelectList(listaUsuarios, "id", "nome"), new SelectList(listaDepartamento, "id", "nome"));
                return model;
            }
            else
            {
                var listaUsuarios = _servicoUsuario.ObterUsuariosOcorrencia().Where(w => w.Id == usuarioId).ToList();
                var listaOcorrenciaTipo = _servicoOcorrenciaTipo.ListarOcorrenciaTipoOcorrencia(usuarioId);
                var model = new OcorrenciaViewModel(new SelectList(listaOcorrenciaTipo, "id", "nomeExibicao"),
                    new SelectList(listaUsuarios, "id", "nome"), new SelectList(listaDepartamento, "id", "nome"));
                return model;
            }
        }

        public IEnumerable<OcorrenciaAcompanhamento> BuscarOcorrenciaSupervisao(OcorrenciaViewModel model)
        {
            return _servicoOcorrenciaAcompanhamento.ObterAcompanhamentoPadrao(model.DataInicio, model.DataFinal,
                model.CriadoPorId, model.ResponsavelId, model.SlaAtrasado, model.Cliente, model.StatusIds,
                model.OcorrenciaTipoId, model.DepartamentoId);
        }

        public object SelectDinamicoExportacaoOcorrencia2(string campos, string[] dinamicos, string[] dinamicosContrato,
            string usuarioId, string dataInicial, string dataFinal, string status, string cliente,
            long? ocorrenciaTipoId, string camposDinamicosOcorrenciaId, string camposDinamicosContratoId)
        {
            DateTime data;
            DateTime? dataInicio;
            DateTime? dataFim;

            if (DateTime.TryParse(dataInicial, out data))
            {
                dataInicio = data;
            }
            else
            {
                dataInicio = null;
            }

            if (DateTime.TryParse(dataFinal, out data))
            {
                dataFim = data;
            }
            else
            {
                dataFim = null;
            }

            var ocorrencias = _servicoOcorrencia.ObterOcorrenciaExportar(campos, usuarioId, dataInicio,
                dataFim,
                status, cliente, ocorrenciaTipoId, camposDinamicosOcorrenciaId, camposDinamicosContratoId);

            var dt = ocorrencias.Tables[0];

            return dt;
        }


        public AlterarMotivoViewModel CarregarAlterarMotivo(long ocorrenciaId)
        {
            var listaOcorrenciaTipo = _servicoOcorrenciaTipo.ObterOcorrenciasPai().Where(w => w.Ativo);
            var motivoAtual = _servicoOcorrenciaTipo.ObterPorOcorrenciaId(ocorrenciaId);

            var retorno = new AlterarMotivoViewModel
            {
                ListaOcorrenciaTipo = listaOcorrenciaTipo,
                NomeMotivoAtual = motivoAtual.NomeExibicao,
                OcorrenciaId = ocorrenciaId
            };

            return retorno;
        }

        public ValidationResult AtualizarMotivo(long ocorrenciaId, long ocorrenciaTipoId, string usuarioId)
        {
            return _servicoOcorrencia.AtualizarMotivoOcorrencia(ocorrenciaId, ocorrenciaTipoId, usuarioId);
        }

        public AlterarContratoViewModel CarregarAlterarContrato(long ocorrenciaId)
        {
            var ocorrencia = _servicoOcorrencia.ObterPorId(ocorrenciaId);
            var listaContrato = _servicoContrato.ObterContratosPorCliente(ocorrencia.PessoaFisicaId,
                ocorrencia.PessoaJuridicaId);

            var contratoAtual = _servicoContrato.ObterPorId(ocorrencia.ContratoId.Value);

            var retorno = new AlterarContratoViewModel
            {
                ListaContrato = listaContrato,
                NomeContratoAtual = contratoAtual.NomeCombo,
                OcorrenciaId = ocorrenciaId
            };

            return retorno;
        }

        public ValidationResult AtualizarContrato(long ocorrenciaId, long contratoId, string usuarioId)
        {
            return _servicoOcorrencia.AtualizarContratoOcorrencia(ocorrenciaId, contratoId, usuarioId);
        }

    }

    public class OcorrenciaTipoDdlViewModel
    {
        public int Contador { get; set; }
        public SelectList Opcoes { get; set; }
        public string ValorSecionado { get; set; }

        public OcorrenciaTipoDdlViewModel(int contador, SelectList opcoes, string valorSelecionado)
        {
            Contador = contador;
            Opcoes = opcoes;
            ValorSecionado = valorSelecionado;
        }
     
    }
}
