using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IRelatorioRepositorio : IRepositorio<Relatorio>
    {
        IEnumerable<Relatorio> HistoricoCronologia(DateTime? Dt_Inicio, DateTime? Dt_Fim);

        IEnumerable<Relatorio> RelatorioAtendimento(DateTime? Dt_Inicio, DateTime? Dt_Fim);

        IEnumerable<Relatorio> RelatorioOcorrencia(DateTime? Dt_Inicio, DateTime? Dt_Fim);

        IEnumerable<Relatorio> RelatorioLigacoes(DateTime? Dt_Inicio, DateTime? Dt_Fim);
        
        
    }
}
