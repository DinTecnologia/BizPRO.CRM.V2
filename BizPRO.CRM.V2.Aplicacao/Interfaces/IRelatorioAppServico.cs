using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IRelatorioAppServico
    {
        IEnumerable<Relatorio> HistoricoCronologia(DateTime? dtInicio, DateTime? dtFim);
        IEnumerable<Relatorio> RelatorioAtendimento(DateTime? dtInicio, DateTime? dtFim);
        IEnumerable<Relatorio> RelatorioOcorrencia(DateTime? dtInicio, DateTime? dtFim);
        IEnumerable<Relatorio> RelatorioLigacoes(DateTime? dtInicio, DateTime? dtFim);
        IEnumerable<Relatorio> RelatorioLigacoesStatus(DateTime? dtInicio, DateTime? dtFim);
        IEnumerable<Relatorio> RelatorioLigacoesOperadorStatus(DateTime? dtInicio, DateTime? dtFim, string usuarioId);
        IEnumerable<Relatorio> RelatorioVendasStatus(DateTime? dtInicio, DateTime? dtFim, string usuarioId, int? status);

        IEnumerable<Relatorio> RelatorioOcorrenciaConsolidada(DateTime? dtInicio, DateTime? dtFim, string usuarioId,
            long? status, long? tipoPai);

        IEnumerable<Relatorio> RelatorioRateio(DateTime? dtInicio, DateTime? dtFim);
        IEnumerable<StatusEntidade> CarregarStatus();
        IEnumerable<Usuario> CarregarUsuariosVendas();
        IEnumerable<Usuario> CarregarUsuariosLigacoes();
        IEnumerable<Usuario> ObterUsuariosOcorrencia();
        IEnumerable<Relatorio> ObterDadosRelatorioConsolidadoContatos(RelatorioFiltrosSelecionadosViewModel filtro);
        RelatorioViewModel CarregarDados();
    }
}
