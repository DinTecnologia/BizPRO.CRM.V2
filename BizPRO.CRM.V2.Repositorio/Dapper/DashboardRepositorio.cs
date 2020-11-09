using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Collections.Generic;
using System;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class DashboardRepositorio : Repositorio<Dashboard>, IDashboardRepositorio
    {
        public DashboardRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Dashboard> ObterDaFila(int? filaId, DateTime? dataInicio, DateTime? dataFim, string userId,
            int? departamentoId)
        {
            var parametros = new DynamicParameters();

            if (dataInicio.HasValue)
                parametros.Add("@dataInicio", dataInicio);

            if (dataFim.HasValue)
                parametros.Add("@dataFim", dataFim);

            parametros.Add("@filaID", filaId);

            if (!string.IsNullOrEmpty(userId))
                parametros.Add("@userId", userId);

            parametros.Add("@departamentoId", departamentoId);

            return ObterPorProcedimento("usp_rpt_DashboardFilaGeral", parametros);
        }

        public IEnumerable<Dashboard> ObterChat(int? filaId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@filaID", filaId);
            return ObterPorProcedimento("usp_rpt_DashboardChat", parametros);
        }
    }
}
