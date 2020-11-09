using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;


namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IRelatorioServico : IServico<Relatorio>
    {
        IEnumerable<Relatorio> HistoricoCronologia(DateTime? Dt_Inicio, DateTime? Dt_Fim);
        IEnumerable<Relatorio> RelatorioAtendimento(DateTime? Dt_Inicio, DateTime? Dt_Fim);
        IEnumerable<Relatorio> RelatorioOcorrencia(DateTime? Dt_Inicio, DateTime? Dt_Fim);
        IEnumerable<Relatorio> RelatorioLigacoes(DateTime? Dt_Inicio, DateTime? Dt_Fim);
        IEnumerable<Relatorio> RelatorioLigacoesStatus(DateTime? Dt_Inicio, DateTime? Dt_Fim);
        IEnumerable<Relatorio> RelatorioRateio(DateTime? Dt_Inicio, DateTime? Dt_Fim);
        IEnumerable<Relatorio> RelatorioLigacoesOperadorStatus(DateTime? Dt_Inicio, DateTime? Dt_Fim, string UsuarioID);

        IEnumerable<Relatorio> RelatorioVendasStatus(DateTime? Dt_Inicio, DateTime? Dt_Fim, string UsuarioID,
            int? StatusID);

        IEnumerable<Relatorio> RelatorioOcorrenciaConsolidada(DateTime? Dt_Inicio, DateTime? Dt_Fim, string UsuarioID,
            long? Status, long? TipoPai);

        IEnumerable<Relatorio> RelatorioContatoDetalhado(DateTime? Dt_Inicio, DateTime? Dt_Fim, string UsuarioID,
            long? Status, long? PessoaFisicaID, long? PessoaJuridicaID, long? CanalID, long? MidiaID, string Sentido);

        IEnumerable<Relatorio> ConsolidadoContatos(int? atividadeTipoID, DateTime? dataInicio, DateTime? dataFim,
            int? statusAtividadeID, string userID, string sentido, long? pessoaFisicaID, long? pessoaJuriciaID,
            long? potenciaisClienteID);
    }
}
