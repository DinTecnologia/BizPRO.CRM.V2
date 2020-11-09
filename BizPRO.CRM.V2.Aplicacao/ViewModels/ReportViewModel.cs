using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ReportViewModel
    {
        public ReportFiltroViewModel Filtro { get; set; }
        public IEnumerable<dynamic> Dados { get; set; }
        public string TituloRelatorio { get; set; }
        public string NomeArquivoRelatorio { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public DataSet DataSet { get; set; }
        public bool EhDataSet { get; set; }

        public ReportViewModel()
        {
            EhDataSet = false;
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
        public ReportViewModel(string nomeRelatorio)
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            EhDataSet = false;

            if (string.IsNullOrEmpty(nomeRelatorio))
            {
                ValidationResult.Add(new DomainValidation.Validation.ValidationError("Nome do relatorio não informado."));
            }
            else
            {
                switch (nomeRelatorio.ToLower())
                {
                    case "consolidadocontato":
                        NomeArquivoRelatorio = nomeRelatorio;
                        TituloRelatorio = "Relatório Consolidado Contato";
                        break;
                    case "detalhecontato":
                        NomeArquivoRelatorio = nomeRelatorio;
                        TituloRelatorio = "Relatório Detalhe Contato";
                        break;
                    case "detalheocorrencia":
                        NomeArquivoRelatorio = nomeRelatorio;
                        TituloRelatorio = "Relatório Detalhe Ocorrência";
                        break;
                    case "consolidadofilaatividade":
                        NomeArquivoRelatorio = nomeRelatorio;
                        TituloRelatorio = "Relatório Consolidado Fila";
                        break;
                    case "detalheatividade":
                        NomeArquivoRelatorio = nomeRelatorio;
                        TituloRelatorio = "Relatório Detalhe Atividade";
                        break;
                    case "cronologiaatendimento":
                        NomeArquivoRelatorio = nomeRelatorio;
                        TituloRelatorio = "Relatório Detalhe Atividade";
                        break;
                    case "ocorrencia":
                        NomeArquivoRelatorio = nomeRelatorio;
                        TituloRelatorio = "Relatório Ocorrências";
                        break;
                    case "ligacao":
                        NomeArquivoRelatorio = nomeRelatorio;
                        TituloRelatorio = "Relatório Ligações";
                        break;
                    case "consolidadoocorrencia":
                        NomeArquivoRelatorio = nomeRelatorio;
                        TituloRelatorio = "Relatório Consolidado Ocorrência";
                        break;
                    case "atendimento":
                        NomeArquivoRelatorio = nomeRelatorio;
                        TituloRelatorio = "Relatório de Atendimentos";
                        break;
                    case "fluxodeatendimentos":
                        NomeArquivoRelatorio = nomeRelatorio;
                        TituloRelatorio = "Relatório de Fluxo de Atendimentos";
                        EhDataSet = true;
                        break;
                    case "fluxodeatendimentosprodutivos":
                        EhDataSet = true;
                        NomeArquivoRelatorio = "FluxoDeAtendimentosProdutivos";
                        TituloRelatorio = "Relatório de Fluxo de Atendimentos Produtivos";
                        break;
                    case "aig-fluxodeatendimentosprodutivosresolve":
                        EhDataSet = true;
                        NomeArquivoRelatorio = "AIG-FluxoDeAtendimentosProdutivosResolve";
                        TituloRelatorio = "Relatório de Fluxo de Atendimentos Produtivos - Resolve";
                        break;
                    case "fluxodeatendimentosporoperador":
                        EhDataSet = true;
                        NomeArquivoRelatorio = "FluxoDeAtendimentosPorOperador";
                        TituloRelatorio = "Relatório de Fluxo de Atendimentos Por Operador";
                        break;
                    case "fluxodeatendimentosrechamadas":
                        EhDataSet = true;
                        NomeArquivoRelatorio = "FluxoDeAtendimentosRechamadas";
                        TituloRelatorio = "Relatório de Fluxo de Atendimentos Rechamadas";
                        break;
                    case "tempoatendimentos":
                        EhDataSet = true;
                        NomeArquivoRelatorio = "TempoAtendimentos";
                        TituloRelatorio = "Relatório de Tempos de Atendimento";
                        break;

                    default:
                        TituloRelatorio = "Relatório Não Identificado";
                        break;
                }
            }

            Filtro = new ReportFiltroViewModel(nomeRelatorio);
            Dados = new List<dynamic>();
        }
    }

    public class ReportFiltroViewModel
    {
        //Propiedades utilizadas para carregar os componentes da View _FILTRO
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public SelectList AtividadesTipo { get; set; }
        public SelectList StatusAtividades { get; set; }
        public SelectList Midias { get; set; }
        public SelectList StatusEntidade { get; set; }
        public SelectList ListaUsuarios { get; set; }
        public SelectList OcorrenciaTipos { get; set; }
        public SelectList ListaTratativa { get; set; }
        public SelectList ListaFilas { get; set; }
        public SelectList Canais { get; set; }
        public SelectList Produtos { get; set; }

        //Propiedades utilizadas para setar quais filtros irão dever aparecer conforme o Relatorio
        public bool MostrarDataInicio { get; set; }
        public bool MostrarDataFim { get; set; }
        public bool MostrarCriadoPor { get; set; }
        public bool MostrarAtividadesTipo { get; set; }
        public bool MostrarStatusAtividades { get; set; }
        public bool MostrarMidias { get; set; }
        public bool MostrarStatusEntidade { get; set; }
        public bool MostrarBuscaDeCliente { get; set; }
        public bool MostrarSentido { get; set; }
        public bool MostrarCliente { get; set; }
        public bool MostrarOcorrenciaTipo { get; set; }
        public bool MostrarOcorrenciaTratativa { get; set; }
        public bool MostrarFila { get; set; }
        public bool MostrarCanal { get; set; }
        public bool MostrarAtividadeNoPrazo { get; set; }
        public bool MostrarProduto { get; set; }
        public bool MostrarMotivoRechamadaCliente { get; set; }

        //Propiedade passada para os proc's. (Incluindo DataInicio and DataFim)
        public int? AtividadeTipoId { get; set; }
        public int? StatusAtividadeId { get; set; }
        public int? StatusEntidadeId { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public long? PotenciaisClientesId { get; set; }
        public long? AtendimentoId { get; set; }
        public string CriadoPor { get; set; }
        public int? MidiaId { get; set; }
        public string Sentido { get; set; }
        public long? OcorrenciaId { get; set; }
        public int? OcorrenciaTipoId { get; set; }
        public string OcorrenciaTratativa { get; set; }
        public long? AtividadeId { get; set; }
        public string AcaoOcorrencia { get; set; }
        public long? FilaId { get; set; }
        public int? CanalId { get; set; }
        public string OcorrenciaTipoEstrutura { get; set; }
        public string UsuarioId { get; set; }
        public bool FilhosTambem { get; set; }
        public bool? AtividadesNoPrazo { get; set; }
        public int? ProdutoId { get; set; }
        public bool? ExibirRechamadaCliente { get; set; }
        public bool LinkExterno { get; set; }

        //Propiedades utilizadas para alimentar os filtros respectivos dos text's do .rdl
        public string DsSentido { get; set; }
        public string DsAtividadeTipo { get; set; }
        public string DsStatusAtividade { get; set; }
        public string DsStatusEntidade { get; set; }
        public string DsMidia { get; set; }
        public string DsCliente { get; set; }
        public string DsCriadoPor { get; set; }
        public string DsCanal { get; set; }
        public string DsOcorrenciaTratativa { get; set; }
        public string DsProtocolo { get; set; }
        public string DsOcorrenciaTipo { get; set; }
        public string DsFila { get; set; }
        public string DsAtividadesNoPrazo { get; set; }
        public string DsProduto { get; set; }

        //Propiedade que será setada conforme o Relatorio
        public Dictionary<string, string> ParametrosVisualizacao { get; set; }

        public ReportFiltroViewModel()
        {
            ParametrosVisualizacao = new Dictionary<string, string>();
            LinkExterno = false;
        }

        public ReportFiltroViewModel(string nomeRelatorio)
        {
            DataInicio = DateTime.Now.AddDays(-1);
            DataFim = DateTime.Now;
            MostrarDataInicio = true;
            MostrarDataFim = true;
            MostrarCriadoPor = true;
            MostrarAtividadesTipo = true;
            MostrarStatusAtividades = true;
            MostrarMidias = true;
            MostrarStatusEntidade = true;
            MostrarBuscaDeCliente = true;
            MostrarSentido = true;
            MostrarCliente = true;
            MostrarOcorrenciaTratativa = false;
            MostrarOcorrenciaTipo = true;
            MostrarFila = true;
            MostrarCanal = true;
            MostrarProduto = true;
            MostrarAtividadeNoPrazo = true;
            MostrarMotivoRechamadaCliente = false;

            ParametrosVisualizacao = new Dictionary<string, string>();
            AtividadesTipo = new SelectList(new List<AtividadeTipo>(), "id", "nome");
            StatusAtividades = new SelectList(new List<StatusAtividade>(), "id", "nome");
            Midias = new SelectList(new List<Midia>(), "id", "nome");
            StatusEntidade = new SelectList(new List<StatusEntidade>(), "id", "nome");
            ListaUsuarios = new SelectList(new List<Usuario>(), "id", "nome");
            OcorrenciaTipos = new SelectList(new List<OcorrenciaTipo>(), "id", "nome");
            ListaTratativa = new SelectList(new List<OcorrenciaTipo>(), "id", "nome");
            ListaFilas = new SelectList(new List<Fila>(), "id", "nome");
            Canais = new SelectList(new List<Canal>(), "id", "nome");
            Produtos = new SelectList(new List<Produto>(), "id", "nome");
        }

        public void SetarParametrosConformeRelatorio(string nomeRelatorio)
        {
            if (string.IsNullOrEmpty(nomeRelatorio))
                return;

            string ocorrenciaTipoAlterado;
            switch (nomeRelatorio.ToLower())
            {
                case "consolidadocontato":
                    ParametrosVisualizacao.Add("sentido", DsSentido);
                    ParametrosVisualizacao.Add("midia", DsMidia);
                    ParametrosVisualizacao.Add("status", DsStatusAtividade);
                    ParametrosVisualizacao.Add("canal", DsAtividadeTipo);
                    ParametrosVisualizacao.Add("cliente", DsCliente);
                    ParametrosVisualizacao.Add("usuario", DsCriadoPor);

                    ParametrosVisualizacao.Add("dataInicio", DataInicio.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("dataFim", DataFim.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("atividadeTipoID",
                        AtividadeTipoId != null ? AtividadeTipoId.ToString() : null);
                    ParametrosVisualizacao.Add("statusAtividadeID",
                        StatusAtividadeId != null ? StatusAtividadeId.ToString() : null);
                    ParametrosVisualizacao.Add("userID", CriadoPor);
                    ParametrosVisualizacao.Add("pessoaFisicaID",
                        PessoaFisicaId != null ? PessoaFisicaId.ToString() : null);
                    ParametrosVisualizacao.Add("pessoaJuridicaID",
                        PessoaJuridicaId != null ? PessoaJuridicaId.ToString() : null);
                    ParametrosVisualizacao.Add("potenciaisClienteID",
                        PotenciaisClientesId != null ? PotenciaisClientesId.ToString() : null);

                    MostrarStatusEntidade = false;
                    MostrarOcorrenciaTratativa = false;
                    MostrarOcorrenciaTipo = false;
                    MostrarFila = false;
                    MostrarProduto = false;
                    MostrarAtividadeNoPrazo = false;
                    break;
                case "detalhecontato":

                    ParametrosVisualizacao.Add("dsSentido", DsSentido);
                    ParametrosVisualizacao.Add("dsMidia", DsMidia);
                    ParametrosVisualizacao.Add("dsStatusAtividade", DsStatusAtividade);
                    ParametrosVisualizacao.Add("dsCanal", DsCanal);
                    ParametrosVisualizacao.Add("dsCliente", DsCliente);
                    ParametrosVisualizacao.Add("dsCriadoPor", DsCriadoPor);
                    ParametrosVisualizacao.Add("dsStatusEntidade", DsStatusEntidade);
                    ParametrosVisualizacao.Add("dsOcorrenciaTipo", DsOcorrenciaTipo);

                    ParametrosVisualizacao.Add("dataInicio", DataInicio.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("dataFim", DataFim.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("sentido", Sentido);
                    ParametrosVisualizacao.Add("pessoaFisicaID",
                        PessoaFisicaId != null ? PessoaFisicaId.ToString() : null);
                    ParametrosVisualizacao.Add("pessoaJuridicaID",
                        PessoaJuridicaId != null ? PessoaJuridicaId.ToString() : null);
                    ParametrosVisualizacao.Add("potenciaisClienteID",
                        PotenciaisClientesId != null ? PotenciaisClientesId.ToString() : null);
                    ParametrosVisualizacao.Add("midiaID", MidiaId != null ? MidiaId.ToString() : null);
                    ParametrosVisualizacao.Add("atividadeTipoID",
                        AtividadeTipoId != null ? AtividadeTipoId.ToString() : null);
                    ParametrosVisualizacao.Add("criadoPor", string.IsNullOrEmpty(CriadoPor) ? null : CriadoPor);
                    MostrarStatusEntidade = false;
                    MostrarOcorrenciaTratativa = false;
                    MostrarOcorrenciaTipo = false;
                    MostrarFila = false;
                    MostrarProduto = false;
                    MostrarAtividadeNoPrazo = false;
                    break;
                case "detalheocorrencia":

                    ParametrosVisualizacao.Add("dsSentido", DsSentido);
                    ParametrosVisualizacao.Add("dsMidia", DsMidia);
                    ParametrosVisualizacao.Add("dsStatusAtividade", DsStatusAtividade);
                    ParametrosVisualizacao.Add("dsCanal", DsCanal);
                    ParametrosVisualizacao.Add("dsCliente", DsCliente);
                    ParametrosVisualizacao.Add("dsCriadoPor", DsCriadoPor);
                    ParametrosVisualizacao.Add("dsStatusEntidade", DsStatusEntidade);
                    ParametrosVisualizacao.Add("dsProtocolo", DsProtocolo);
                    ParametrosVisualizacao.Add("dsOcorrenciaTipo", DsOcorrenciaTipo);
                    ParametrosVisualizacao.Add("dsOcorrenciaTratativa", DsOcorrenciaTratativa);

                    ParametrosVisualizacao.Add("dataInicio", DataInicio.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("dataFim", DataFim.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("sentido", Sentido);
                    ParametrosVisualizacao.Add("pessoaFisicaID",
                        PessoaFisicaId != null ? PessoaFisicaId.ToString() : null);
                    ParametrosVisualizacao.Add("pessoaJuridicaID",
                        PessoaJuridicaId != null ? PessoaJuridicaId.ToString() : null);
                    ParametrosVisualizacao.Add("potenciaisClienteID",
                        PotenciaisClientesId != null ? PotenciaisClientesId.ToString() : null);
                    ParametrosVisualizacao.Add("statusEntidadeID",
                        StatusEntidadeId != null ? StatusEntidadeId.ToString() : null);
                    ParametrosVisualizacao.Add("midiaID", MidiaId != null ? MidiaId.ToString() : null);
                    ParametrosVisualizacao.Add("atividadeTipoID",
                        AtividadeTipoId != null ? AtividadeTipoId.ToString() : null);
                    ParametrosVisualizacao.Add("ocorrenciaID", OcorrenciaId != null ? OcorrenciaId.ToString() : null);
                    ParametrosVisualizacao.Add("criadoPor", string.IsNullOrEmpty(CriadoPor) ? null : CriadoPor);

                    MostrarMidias = false;
                    MostrarSentido = false;
                    MostrarStatusAtividades = false;
                    MostrarAtividadesTipo = false;
                    MostrarOcorrenciaTratativa = true;
                    MostrarFila = false;
                    MostrarProduto = false;
                    MostrarAtividadeNoPrazo = false;
                    break;
                case "consolidadofilaatividade":
                    MostrarAtividadesTipo = false;
                    MostrarBuscaDeCliente = false;
                    MostrarCliente = false;
                    MostrarCriadoPor = false;
                    MostrarMidias = false;
                    MostrarOcorrenciaTipo = false;
                    MostrarOcorrenciaTratativa = false;
                    MostrarSentido = false;
                    MostrarStatusAtividades = false;
                    MostrarStatusEntidade = false;
                    MostrarProduto = false;
                    MostrarAtividadeNoPrazo = false;

                    ParametrosVisualizacao.Add("dsFila", DsFila);
                    ParametrosVisualizacao.Add("dataInicio", DataInicio.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("dataFim", DataFim.ToString(CultureInfo.CurrentCulture));
                    break;
                case "detalheatividade":
                    MostrarAtividadesTipo = false;
                    MostrarBuscaDeCliente = false;
                    MostrarCliente = false;
                    MostrarCriadoPor = false;
                    //MostrarDataFim = false;
                    //MostrarDataInicio = false;
                    MostrarMidias = false;
                    MostrarOcorrenciaTipo = false;
                    MostrarOcorrenciaTratativa = false;
                    MostrarSentido = false;
                    MostrarStatusAtividades = false;
                    MostrarStatusEntidade = false;
                    MostrarProduto = false;
                    MostrarAtividadeNoPrazo = false;

                    ParametrosVisualizacao.Add("dsFila", DsFila);
                    ParametrosVisualizacao.Add("dsStatusAtividade", DsStatusAtividade);
                    ParametrosVisualizacao.Add("dataInicio", DataInicio.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("dataFim", DataFim.ToString(CultureInfo.CurrentCulture));
                    MostrarFila = false;
                    break;
                case "cronologiaatendimento":
                    MostrarAtividadesTipo = false;
                    MostrarBuscaDeCliente = false;
                    MostrarCliente = false;
                    MostrarCriadoPor = false;
                    MostrarDataFim = true;
                    MostrarDataInicio = true;
                    MostrarMidias = false;
                    MostrarOcorrenciaTipo = false;
                    MostrarOcorrenciaTratativa = false;
                    MostrarSentido = false;
                    MostrarStatusAtividades = false;
                    MostrarStatusEntidade = false;
                    MostrarFila = false;
                    MostrarProduto = false;
                    MostrarAtividadeNoPrazo = false;
                    break;
                case "ocorrencia":
                    MostrarFila = false;
                    MostrarAtividadesTipo = false;
                    MostrarBuscaDeCliente = false;
                    MostrarCliente = false;
                    MostrarCriadoPor = false;
                    MostrarDataFim = true;
                    MostrarDataInicio = true;
                    MostrarMidias = false;
                    MostrarOcorrenciaTipo = false;
                    MostrarOcorrenciaTratativa = false;
                    MostrarSentido = false;
                    MostrarStatusAtividades = false;
                    MostrarStatusEntidade = false;
                    MostrarProduto = false;
                    MostrarAtividadeNoPrazo = false;
                    DataInicio = DataInicio != DateTime.MinValue ? DataInicio : DateTime.Now.AddDays(-90);
                    DataFim = DataFim != DateTime.MinValue ? DataFim : DateTime.Now;
                    ParametrosVisualizacao.Add("dataInicioPeriodo", DataInicio.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("dataFimPeriodo", DataFim.ToString(CultureInfo.CurrentCulture));
                    break;
                case "ligacao":

                    MostrarFila = false;
                    MostrarAtividadesTipo = false;
                    MostrarBuscaDeCliente = false;
                    MostrarCliente = false;
                    MostrarCriadoPor = false;
                    MostrarDataFim = true;
                    MostrarDataInicio = true;
                    MostrarMidias = false;
                    MostrarOcorrenciaTipo = false;
                    MostrarOcorrenciaTratativa = false;
                    MostrarSentido = false;
                    MostrarStatusAtividades = false;
                    MostrarStatusEntidade = false;
                    MostrarProduto = false;
                    MostrarAtividadeNoPrazo = false;
                    DataInicio = DataInicio != DateTime.MinValue ? DataInicio : DateTime.Now;
                    DataFim = DataFim != DateTime.MinValue ? DataFim : DateTime.Now;
                    ParametrosVisualizacao.Add("dataInicioPeriodo", DataInicio.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("dataFimPeriodo", DataFim.ToString(CultureInfo.CurrentCulture));
                    break;

                case "consolidadoocorrencia":
                    MostrarFila = false;
                    MostrarAtividadesTipo = false;
                    MostrarBuscaDeCliente = false;
                    MostrarCliente = false;
                    MostrarCriadoPor = true;
                    MostrarDataFim = true;
                    MostrarDataInicio = true;
                    MostrarMidias = false;
                    MostrarOcorrenciaTipo = true;
                    MostrarOcorrenciaTratativa = false;
                    MostrarSentido = false;
                    MostrarStatusAtividades = false;
                    MostrarStatusEntidade = true;
                    MostrarProduto = false;
                    MostrarAtividadeNoPrazo = false;
                    DataInicio = DataInicio != DateTime.MinValue ? DataInicio : DateTime.Now;
                    DataFim = DataFim != DateTime.MinValue ? DataFim : DateTime.Now;
                    ParametrosVisualizacao.Add("inicio", DataInicio.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("fim", DataFim.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("usuario", string.IsNullOrEmpty(CriadoPor) ? null : CriadoPor);
                    ParametrosVisualizacao.Add("status", DsStatusEntidade);
                    ParametrosVisualizacao.Add("TipoPai", DsOcorrenciaTipo);
                    break;
                case "atendimento":

                    MostrarFila = false;
                    MostrarAtividadesTipo = false;
                    MostrarBuscaDeCliente = false;
                    MostrarCliente = false;
                    MostrarCriadoPor = false;
                    MostrarDataFim = true;
                    MostrarDataInicio = true;
                    MostrarMidias = false;
                    MostrarOcorrenciaTipo = false;
                    MostrarOcorrenciaTratativa = false;
                    MostrarSentido = false;
                    MostrarStatusAtividades = false;
                    MostrarStatusEntidade = false;
                    MostrarProduto = false;
                    MostrarAtividadeNoPrazo = false;
                    DataInicio = DataInicio != DateTime.MinValue ? DataInicio : DateTime.Now;
                    DataFim = DataFim != DateTime.MinValue ? DataFim : DateTime.Now;
                    ParametrosVisualizacao.Add("Data_Inicial", DataInicio.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("Data_Final", DataFim.ToString(CultureInfo.CurrentCulture));
                    break;
                case "fluxodeatendimentos":
                    MostrarAtividadesTipo = false;
                    MostrarBuscaDeCliente = false;
                    MostrarCliente = false;
                    MostrarCriadoPor = true;
                    MostrarMidias = false;
                    MostrarOcorrenciaTratativa = false;
                    MostrarStatusEntidade = false;
                    MostrarFila = false;
                    MostrarStatusAtividades = false;
                    MostrarProduto = false;
                    MostrarAtividadeNoPrazo = false;
                    MostrarCanal = false;
                    MostrarOcorrenciaTipo = false;

                    ParametrosVisualizacao.Add("dataInicioPesquisa", DataInicio.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("dataFinalPesquisa", DataFim.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("usuarioID", string.IsNullOrEmpty(CriadoPor) ? null : CriadoPor);
                    ParametrosVisualizacao.Add("usuarioIDNomeExibicao", DsCriadoPor);
                    ParametrosVisualizacao.Add("SentidoAtendimento", Sentido);
                    ParametrosVisualizacao.Add("Atendimento_canalID", CanalId != null ? CanalId.ToString() : null);
                    ocorrenciaTipoAlterado = OcorrenciaTipoId.HasValue
                        ? string.Format("{0}{1}", OcorrenciaTipoId, FilhosTambem ? ">" : "")
                        : null;
                    ParametrosVisualizacao.Add("Ocorrencia_ocorrenciasTiposEstrutura", ocorrenciaTipoAlterado);
                    ParametrosVisualizacao.Add("Ocorrencia_statusEntidade",
                        StatusEntidadeId != null ? StatusEntidadeId.ToString() : null);
                    ParametrosVisualizacao.Add("linkExterno", LinkExterno.ToString());


                    break;
                case "fluxodeatendimentosprodutivos":
                    MostrarAtividadesTipo = false;
                    MostrarBuscaDeCliente = false;
                    MostrarCliente = false;
                    MostrarCriadoPor = true;
                    MostrarMidias = false;
                    MostrarOcorrenciaTratativa = false;
                    MostrarStatusEntidade = false;
                    MostrarFila = false;
                    MostrarStatusAtividades = false;
                    MostrarProduto = false;
                    MostrarAtividadeNoPrazo = false;

                    ocorrenciaTipoAlterado = OcorrenciaTipoId.HasValue
                        ? string.Format("{0}{1}", OcorrenciaTipoId, FilhosTambem ? ">" : "")
                        : null;
                    ParametrosVisualizacao.Add("dataInicioPesquisa", DataInicio.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("dataFinalPesquisa", DataFim.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("CanalID", CanalId != null ? CanalId.ToString() : null);
                    ParametrosVisualizacao.Add("OcorrenciasTiposEstrutura", ocorrenciaTipoAlterado);
                    ParametrosVisualizacao.Add("StatusEntidadeIDs",
                        StatusEntidadeId != null ? StatusEntidadeId.ToString() : null);
                    ParametrosVisualizacao.Add("CanalNomeExibicao", DsCanal);
                    ParametrosVisualizacao.Add("OcorrenciasTiposEstruturaNomeExibicao", DsOcorrenciaTipo);
                    ParametrosVisualizacao.Add("StatusEntidadeIDsNomeExibicao", DsStatusEntidade);
                    ParametrosVisualizacao.Add("usuarioID", string.IsNullOrEmpty(CriadoPor) ? null : CriadoPor);
                    ParametrosVisualizacao.Add("usuarioIDNomeExibicao", DsCriadoPor);
                    ParametrosVisualizacao.Add("Atendimento_sentido", Sentido);
                    ParametrosVisualizacao.Add("OcorrenciaNExibicao", DsOcorrenciaTipo);

                    break;
                case "aig-fluxodeatendimentosprodutivosresolve":
                    MostrarAtividadesTipo = false;
                    MostrarBuscaDeCliente = false;
                    MostrarCliente = false;
                    MostrarCriadoPor = true;
                    MostrarMidias = false;
                    MostrarOcorrenciaTratativa = false;
                    MostrarStatusEntidade = false;
                    MostrarFila = false;
                    MostrarStatusAtividades = false;
                    MostrarSentido = false;

                    ocorrenciaTipoAlterado = OcorrenciaTipoId.HasValue
                        ? string.Format("{0}{1}", OcorrenciaTipoId, FilhosTambem ? ">" : "")
                        : null;
                    ParametrosVisualizacao.Add("dataInicioPesquisa", DataInicio.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("dataFinalPesquisa", DataFim.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("CanalID", CanalId != null ? CanalId.ToString() : null);
                    ParametrosVisualizacao.Add("OcorrenciasTiposEstrutura", ocorrenciaTipoAlterado);
                    ParametrosVisualizacao.Add("StatusEntidadeIDs",
                        StatusEntidadeId != null ? StatusEntidadeId.ToString() : null);
                    ParametrosVisualizacao.Add("CanalNomeExibicao", DsCanal);
                    ParametrosVisualizacao.Add("OcorrenciasTiposEstruturaNomeExibicao", DsOcorrenciaTipo);
                    ParametrosVisualizacao.Add("StatusEntidadeIDsNomeExibicao", DsStatusEntidade);
                    ParametrosVisualizacao.Add("usuarioID", string.IsNullOrEmpty(CriadoPor) ? null : CriadoPor);
                    ParametrosVisualizacao.Add("usuarioIDNomeExibicao", DsCriadoPor);
                    ParametrosVisualizacao.Add("NoPrazoNomeExibicao", DsAtividadesNoPrazo);
                    ParametrosVisualizacao.Add("ProdutoNomeExibicao", DsProduto);
                    ParametrosVisualizacao.Add("NoPrazo",
                        AtividadesNoPrazo.HasValue ? AtividadesNoPrazo.Value.ToString() : null);
                    ParametrosVisualizacao.Add("ProdutoID", ProdutoId.HasValue ? ProdutoId.ToString() : null);
                    break;
                case "fluxodeatendimentosporoperador":

                    MostrarAtividadesTipo = false;
                    MostrarBuscaDeCliente = false;
                    MostrarCliente = false;
                    MostrarCriadoPor = true;
                    MostrarMidias = false;
                    MostrarOcorrenciaTratativa = false;
                    MostrarStatusEntidade = false;
                    MostrarFila = false;
                    MostrarStatusAtividades = false;
                    MostrarProduto = false;
                    MostrarAtividadeNoPrazo = false;

                    ocorrenciaTipoAlterado = OcorrenciaTipoId.HasValue
                        ? string.Format("{0}{1}", OcorrenciaTipoId, FilhosTambem ? ">" : "")
                        : null;
                    ParametrosVisualizacao.Add("dataInicioPesquisa", DataInicio.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("dataFinalPesquisa", DataFim.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("usuarioID", string.IsNullOrEmpty(CriadoPor) ? null : CriadoPor);
                    ParametrosVisualizacao.Add("usuarioIDNomeExibicao", DsCriadoPor);
                    ParametrosVisualizacao.Add("SentidoAtendimento", Sentido);
                    ParametrosVisualizacao.Add("Ocorrencia_ocorrenciasTiposEstrutura", ocorrenciaTipoAlterado);
                    ParametrosVisualizacao.Add("Ocorrencia_statusEntidade",
                        StatusEntidadeId != null ? StatusEntidadeId.ToString() : null);
                    ParametrosVisualizacao.Add("CanalID", CanalId != null ? CanalId.ToString() : null);
                    ParametrosVisualizacao.Add("CanalNomeExibicao", DsCanal);

                    break;

                case "fluxodeatendimentosrechamadas":

                    MostrarAtividadesTipo = false;
                    MostrarBuscaDeCliente = false;
                    MostrarCliente = false;
                    MostrarCriadoPor = true;
                    MostrarMidias = false;
                    MostrarOcorrenciaTratativa = false;
                    MostrarStatusEntidade = false;
                    MostrarFila = false;
                    MostrarStatusAtividades = false;
                    MostrarProduto = false;
                    MostrarAtividadeNoPrazo = false;
                    MostrarMotivoRechamadaCliente = true;

                    ocorrenciaTipoAlterado = OcorrenciaTipoId.HasValue
                        ? string.Format("{0}{1}", OcorrenciaTipoId, FilhosTambem ? ">" : "")
                        : null;
                    ParametrosVisualizacao.Add("dataInicioPesquisa", DataInicio.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("dataFinalPesquisa", DataFim.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("usuarioID", string.IsNullOrEmpty(CriadoPor) ? null : CriadoPor);
                    ParametrosVisualizacao.Add("usuarioIDNomeExibicao", DsCriadoPor);
                    ParametrosVisualizacao.Add("SentidoAtendimento", Sentido);
                    ParametrosVisualizacao.Add("Ocorrencias_ocorrenciasTiposEstrutura", ocorrenciaTipoAlterado);
                    ParametrosVisualizacao.Add("Ocorrencia_statusEntidade",
                        StatusEntidadeId != null ? StatusEntidadeId.ToString() : null);
                    ParametrosVisualizacao.Add("CanalID", CanalId != null ? CanalId.ToString() : null);
                    ParametrosVisualizacao.Add("CanalNomeExibicao", DsCanal);
                    ParametrosVisualizacao.Add("Ocorrencia_ocorrenciasTiposEstruturaNomeExibicao", DsOcorrenciaTipo);
                    ParametrosVisualizacao.Add("exibirMotivoRechamadaCliente",
                        ExibirRechamadaCliente.HasValue ? ExibirRechamadaCliente.Value.ToString() : null);
                    break;
                case "tempoatendimentos":
                    MostrarAtividadesTipo = false;
                    MostrarBuscaDeCliente = false;
                    MostrarCliente = false;
                    MostrarCriadoPor = true;
                    MostrarMidias = false;
                    MostrarOcorrenciaTratativa = false;
                    MostrarStatusEntidade = false;
                    MostrarFila = false;
                    MostrarStatusAtividades = false;
                    MostrarSentido = false;
                    MostrarProduto = false;
                    MostrarAtividadeNoPrazo = false;                    

                    ocorrenciaTipoAlterado = OcorrenciaTipoId.HasValue
                        ? string.Format("{0}{1}", OcorrenciaTipoId, FilhosTambem ? ">" : "")
                        : null;
                    ParametrosVisualizacao.Add("dataInicioPesquisa", DataInicio.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("dataFinalPesquisa", DataFim.ToString(CultureInfo.CurrentCulture));
                    ParametrosVisualizacao.Add("usuarioID", string.IsNullOrEmpty(CriadoPor) ? null : CriadoPor);
                    ParametrosVisualizacao.Add("usuarioIDNomeExibicao", DsCriadoPor);
                    ParametrosVisualizacao.Add("SentidoAtendimento", Sentido);
                    ParametrosVisualizacao.Add("Atendimento_canalID", CanalId != null ? CanalId.ToString() : null);
                    ParametrosVisualizacao.Add("Ocorrencia_ocorrenciasTiposEstrutura", ocorrenciaTipoAlterado);
                    ParametrosVisualizacao.Add("Ocorrencia_statusEntidade",
                        StatusEntidadeId != null ? StatusEntidadeId.ToString() : null);
                    ParametrosVisualizacao.Add("CanalID", CanalId != null ? CanalId.ToString() : null);
                    ParametrosVisualizacao.Add("CanalIDNome", DsCanal);
                    break;
            }
        }
    }

    public class ReportDados
    {
        public IEnumerable<dynamic> Dados { get; set; }
    }
}
