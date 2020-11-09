using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Data;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IReportAppServico
    {
        ReportViewModel CarregarRelatorio(string nomeRelatorio, ReportFiltroViewModel filtroModel, bool carregarDados = false);
        DataSet ObterDadosRelatorioAdo(string nomeRelatorio, ReportFiltroViewModel filtroModel);
        ReportFiltroViewModel CarregarFiltrosPorExtenso(ReportFiltroViewModel model);
    }
}
