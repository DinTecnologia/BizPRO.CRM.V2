using Camadas.Infra.Repositorio.Dapper.Comum;
using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class RelatorioRepositorio : Repositorio<Relatorio>, IRelatorioRepositorio
    {

        public RelatorioRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Relatorio> HistoricoCronologia(DateTime? Dt_Inicio, DateTime? Dt_Fim)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Relatorio> RelatorioAtendimento(DateTime? Dt_Inicio, DateTime? Dt_Fim)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Relatorio> RelatorioOcorrencia(DateTime? Dt_Inicio, DateTime? Dt_Fim)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Relatorio> RelatorioLigacoes(DateTime? Dt_Inicio, DateTime? Dt_Fim)
        {
            throw new NotImplementedException();
        }
    }
}
