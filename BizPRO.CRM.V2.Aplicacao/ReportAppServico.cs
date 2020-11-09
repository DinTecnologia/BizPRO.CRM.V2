using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using System.Linq;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class ReportAppServico : IReportAppServico
    {
        public readonly IReportServico _servicoReport;
        public readonly IAtividadeTipoServico _servidoAtividadetipo;
        public readonly IMidiaServico _servicoMidia;
        public readonly IStatusEntidadeServico _servicoStatusEntidade;
        public readonly IUsuarioServico _servicoUsuario;
        public readonly IStatusAtividadeServico _servicoStatusAtividade;
        public readonly IOcorrenciaTipoServico _servicoOcorrenciaTipo;
        public readonly IAtividadeTipoServico _servicoAtividadeTipo;
        public readonly IPessoaFisicaServico _servicoPessoaFisica;
        public readonly IPessoaJuridicaServico _servicoPessoaJuridica;
        public readonly IPotenciaisClienteServico _servicoPotenciaisCliente;
        public readonly IFilaServico _servicoFila;
        public readonly ICanalServico _canalServico;
        public readonly IProdutoServico _produtoServico;

        public ReportAppServico(IAtividadeTipoServico servidoAtividadetipo, IReportServico servicoReport,
            IMidiaServico servicoMidia, IStatusEntidadeServico servicoStatusEntidade, IUsuarioServico servicoUsuario,
            IStatusAtividadeServico servicoStatusAtividade, IOcorrenciaTipoServico servicoOcorrenciaTipo,
            IAtividadeTipoServico servicoAtividadeTipo, IPessoaFisicaServico servicoPessoaFisica,
            IPessoaJuridicaServico servicoPessoaJuridica, IPotenciaisClienteServico servicoPotenciaisCliente,
            IFilaServico servicoFila, ICanalServico canalServico, IProdutoServico produtoServico)
        {
            _servidoAtividadetipo = servidoAtividadetipo;
            _servicoReport = servicoReport;
            _servicoMidia = servicoMidia;
            _servicoStatusEntidade = servicoStatusEntidade;
            _servicoUsuario = servicoUsuario;
            _servicoStatusAtividade = servicoStatusAtividade;
            _servicoOcorrenciaTipo = servicoOcorrenciaTipo;
            _servicoAtividadeTipo = servicoAtividadeTipo;
            _servicoPessoaFisica = servicoPessoaFisica;
            _servicoPessoaJuridica = servicoPessoaJuridica;
            _servicoPotenciaisCliente = servicoPotenciaisCliente;
            _servicoFila = servicoFila;
            _canalServico = canalServico;
            _produtoServico = produtoServico;
        }

        public ReportViewModel CarregarRelatorio(string nomeRelatorio, ReportFiltroViewModel filtroModel, bool carregarDados = false)
        {
            var model = new ReportViewModel(nomeRelatorio);

            if (!model.ValidationResult.IsValid)
                return model;

            if (filtroModel == null)
            {
                //Primeiro Passo - Carregar os Filtros padrões
                model = CarregarFiltrosPadrão(model);
            }
            else
            {
                model.Filtro = filtroModel;
                model.Filtro = CarregarFiltrosPorExtenso(model.Filtro);
            }

            model.Filtro.SetarParametrosConformeRelatorio(nomeRelatorio);

            if (carregarDados)
                if (model.EhDataSet)
                {
                    model.DataSet = ObterDadosRelatorioAdo(model.NomeArquivoRelatorio, model.Filtro);
                }
                else
                {
                    model.Dados = ObterDadosRelatorio(model.NomeArquivoRelatorio, model.Filtro);
                }

            return model;
        }

        public ReportViewModel CarregarFiltrosPadrão(ReportViewModel model)
        {
            model.Filtro.AtividadesTipo = new SelectList(_servidoAtividadetipo.ObterTodos(), "id", "nome");
            model.Filtro.Midias = new SelectList(_servicoMidia.ObterTodos(), "id", "nome");

            if (model.Filtro.MostrarStatusEntidade)
            {
                ///Aqui irei precisar melhorar, pois conforme o relatório, deveremos carregar com status diferentes.
                ///Será precisa filtra sempre pela coluna "entidadesValidas"
                model.Filtro.StatusEntidade = new SelectList(_servicoStatusEntidade.ObterStatusEntidadeOcorrencia(),
                    "id", "nome");
            }

            if (model.Filtro.MostrarStatusAtividades)
            {
                ///Aqui irei precisar melhorar, pois conforme o relatório, deveremos carregar com status diferentes.
                ///Será precisa filtra sempre pela coluna "entidadesValidas"
                model.Filtro.StatusAtividades = new SelectList(_servicoStatusAtividade.ObterTodos(), "id", "descricao");
            }

            if (model.Filtro.MostrarCriadoPor)
                model.Filtro.ListaUsuarios = new SelectList(_servicoUsuario.ObterUsuariosContatos(), "id", "nome");

            if (model.Filtro.MostrarOcorrenciaTipo)
                model.Filtro.OcorrenciaTipos =
                    new SelectList(_servicoOcorrenciaTipo.ObterTodos().OrderBy(x => x.NomeExibicao), "id",
                        "nomeExibicao");

            if (model.Filtro.MostrarFila)
                model.Filtro.ListaFilas = new SelectList(_servicoFila.ObterTodos().OrderBy(x => x.Nome), "id", "nome");

            if (model.Filtro.MostrarCanal)
                model.Filtro.Canais = new SelectList(_canalServico.ObterTodos(), "id", "nome");

            if (model.Filtro.MostrarProduto)
                model.Filtro.Produtos = new SelectList(_produtoServico.ObterTodos(), "id", "nome");

            return model;
        }

        protected IEnumerable<dynamic> ObterDadosRelatorio(string nomeRelatorio, ReportFiltroViewModel filtroModel)
        {
            var dados = new List<dynamic>();

            if (string.IsNullOrEmpty(nomeRelatorio) || filtroModel == null)
                return dados;

            switch (nomeRelatorio.ToLower())
            {
                case "consolidadocontato":
                    dados =
                        ((IEnumerable<dynamic>)
                            _servicoReport.ObterDadosRelatorioConsolidadoContatos(filtroModel.AtividadeTipoId,
                                filtroModel.DataInicio, filtroModel.DataFim, filtroModel.StatusAtividadeId,
                                filtroModel.CriadoPor, filtroModel.Sentido, filtroModel.PessoaFisicaId,
                                filtroModel.PessoaJuridicaId, filtroModel.PotenciaisClientesId, filtroModel.MidiaId))
                        .ToList
                        ();
                    break;
                case "detalhecontato":
                    dados =
                    ((IEnumerable<dynamic>)
                        _servicoReport.ObterDadosRelatorioDetalheContato(filtroModel.AtividadeTipoId,
                            filtroModel.DataInicio, filtroModel.DataFim, filtroModel.StatusAtividadeId,
                            filtroModel.CriadoPor, filtroModel.Sentido, filtroModel.MidiaId, filtroModel.PessoaFisicaId,
                            filtroModel.PessoaJuridicaId, filtroModel.PotenciaisClientesId)).ToList();
                    break;
                case "detalheocorrencia":
                    dados =
                    ((IEnumerable<dynamic>)
                        _servicoReport.ObterDadosRelatorioDetalheOcorrencia(filtroModel.AtividadeTipoId,
                            filtroModel.DataInicio, filtroModel.DataFim, filtroModel.StatusEntidadeId,
                            filtroModel.CriadoPor, filtroModel.Sentido, filtroModel.MidiaId, filtroModel.PessoaFisicaId,
                            filtroModel.PessoaJuridicaId, filtroModel.PotenciaisClientesId, filtroModel.OcorrenciaId,
                            filtroModel.OcorrenciaTipoId, filtroModel.AtividadeId, filtroModel.AcaoOcorrencia,
                            filtroModel.AtendimentoId)).ToList();
                    break;
                case "consolidadofilaatividade":
                    dados =
                    ((IEnumerable<dynamic>)
                        _servicoReport.ObterDadosRelatorioConsolidadoFilaAtividade(filtroModel.FilaId,
                            filtroModel.DataInicio, filtroModel.DataFim)).ToList();
                    break;
                case "detalheatividade":
                    dados =
                    ((IEnumerable<dynamic>)
                        _servicoReport.ObterDadosRelatorioDetalheAtividade(filtroModel.FilaId,
                            filtroModel.StatusAtividadeId, filtroModel.DataInicio, filtroModel.DataFim)).ToList();
                    break;
                case "cronologiaatendimento":
                    dados =
                    ((IEnumerable<dynamic>)
                        _servicoReport.ObterDadosRelatorioCronologiaAtendimento(filtroModel.DataInicio,
                            filtroModel.DataFim)).ToList();
                    break;
                case "ocorrencia":
                    dados =
                    ((IEnumerable<dynamic>)
                        _servicoReport.ObterDadosRelatorioOcorrencia(filtroModel.DataInicio,
                            filtroModel.DataFim)).ToList();
                    break;
                case "ligacao":
                    dados =
                    ((IEnumerable<dynamic>)
                        _servicoReport.ObterDadosRelatorioLigacao(filtroModel.DataInicio,
                            filtroModel.DataFim)).ToList();
                    break;
                case "consolidadoocorrencia":
                    dados =
                    ((IEnumerable<dynamic>)
                        _servicoReport.ObterDadosRelatorioConsolidadoOcorrencia(filtroModel.DataInicio,
                            filtroModel.DataFim, filtroModel.CriadoPor, filtroModel.StatusAtividadeId,
                            filtroModel.OcorrenciaTipoId)).ToList();
                    break;
                case "atendimento":
                    dados =
                    ((IEnumerable<dynamic>)
                        _servicoReport.ObterDadosRelatorioAtendimento(filtroModel.DataInicio,
                            filtroModel.DataFim)).ToList();
                    break;
            }

            return dados;
        }

        public DataSet ObterDadosRelatorioAdo(string nomeRelatorio, ReportFiltroViewModel filtroModel)
        {
            if (string.IsNullOrEmpty(nomeRelatorio) || filtroModel == null)
                return null;

            switch (nomeRelatorio.ToLower())
            {
                case "fluxodeatendimentos":

                    return _servicoReport.ObterDadosRelatorioFluxoDeAtendimento(filtroModel.DataInicio,
                        filtroModel.DataFim,
                        filtroModel.CanalId, filtroModel.OcorrenciaTipoEstrutura, filtroModel.StatusEntidadeId,
                        filtroModel.Sentido, filtroModel.UsuarioId);

                case "fluxodeatendimentosprodutivos":
                    return _servicoReport.ObterDadosRelatorioFluxoDeAtendimentoProdutivo(filtroModel.DataInicio,
                        filtroModel.DataFim,
                        filtroModel.CanalId, filtroModel.OcorrenciaTipoEstrutura, filtroModel.StatusEntidadeId,
                        filtroModel.Sentido, filtroModel.UsuarioId);
            }

            return null;
        }

        public ReportFiltroViewModel CarregarFiltrosPorExtenso(ReportFiltroViewModel model)
        {
            //model.dsAtividadeTipo
            if (model.AtividadeTipoId != null && string.IsNullOrEmpty(model.DsAtividadeTipo))
                model.DsAtividadeTipo = _servicoAtividadeTipo.ObterPorId((int) model.AtividadeTipoId).Nome;

            //model.dsCanal
            if (model.AtividadeTipoId != null && string.IsNullOrEmpty(model.DsCanal))
                model.DsCanal = _servicoAtividadeTipo.ObterPorId((int) model.AtividadeTipoId).Nome;

            //model.dsCriadoPor
            if (!string.IsNullOrEmpty(model.CriadoPor) && string.IsNullOrEmpty(model.DsCriadoPor))
                model.DsCriadoPor = _servicoUsuario.ObterPorUserId(model.CriadoPor).Nome;

            //model.dsCliente
            if (model.PessoaFisicaId != null || model.PessoaJuridicaId != null ||
                model.PotenciaisClientesId != null && string.IsNullOrEmpty(model.DsCliente))
            {
                if (model.PessoaFisicaId != null)
                    model.DsCliente = _servicoPessoaFisica.ObterPorId((long) model.PessoaFisicaId).Nome;

                if (model.PessoaJuridicaId != null)
                    model.DsCliente = _servicoPessoaJuridica.ObterPorId((long) model.PessoaJuridicaId).RazaoSocial;

                if (model.PotenciaisClientesId != null)
                    model.DsCliente = _servicoPotenciaisCliente.ObterPorId((long) model.PotenciaisClientesId).nome;
            }

            //model.dsMidia
            if (model.MidiaId != null && string.IsNullOrEmpty(model.DsMidia) && model.MidiaId != 99999)
                model.DsMidia = _servicoMidia.ObterPorId((int) model.MidiaId).Nome;

            //model.dsOcorrenciaTipo
            if (model.OcorrenciaTipoId != null)
                model.DsOcorrenciaTipo = _servicoOcorrenciaTipo.ObterPorId((int) model.OcorrenciaTipoId).Nome;

            //model.dsOcorrenciaTratativa
            if (!string.IsNullOrEmpty(model.OcorrenciaTratativa) && string.IsNullOrEmpty(model.DsOcorrenciaTratativa))
            {
                model.DsOcorrenciaTratativa = model.OcorrenciaTratativa.ToLower() == "c" ? "Criado" : "Tratado";
            }

            //model.dsSentido
            if (!string.IsNullOrEmpty(model.Sentido) && string.IsNullOrEmpty(model.DsSentido))
            {
                model.DsSentido = model.Sentido.ToLower() == "e" ? "Receptivo" : "Ativo";
            }

            //model.dsStatusAtividade
            if (model.StatusAtividadeId != null && string.IsNullOrEmpty(model.DsStatusAtividade))
                model.DsStatusAtividade = _servicoStatusAtividade.ObterPorId((int) model.StatusAtividadeId).Descricao;

            //model.dsStatusEntidade
            if (model.StatusEntidadeId != null && string.IsNullOrEmpty(model.DsStatusEntidade))
                model.DsStatusEntidade = _servicoStatusEntidade.ObterPorId((int) model.StatusEntidadeId).nome;

            if (model.FilaId != null && string.IsNullOrEmpty(model.DsFila))
                model.DsFila = _servicoFila.ObterPorId((int) model.FilaId).Nome;


            if (model.CanalId.HasValue && string.IsNullOrEmpty(model.DsCanal))
                model.DsCanal = _canalServico.ObterPorId((int) model.CanalId).Nome;

            if (model.AtividadesNoPrazo.HasValue)
                model.DsAtividadesNoPrazo = model.AtividadesNoPrazo.Value ? "Sim" : "Não";

            if (model.ProdutoId.HasValue && string.IsNullOrEmpty(model.DsProduto))
                model.DsProduto = _produtoServico.ObterPorId(model.ProdutoId.Value).nome;

            return model;
        }
    }
}
