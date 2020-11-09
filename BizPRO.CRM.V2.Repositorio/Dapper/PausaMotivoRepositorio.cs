using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class PausaMotivoRepositorio : Repositorio<PausaMotivo>, IPausaMotivoRepositorio
    {
        public PausaMotivoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<PausaMotivo> ObterPorCanalIds(string canalIds)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@CanalIds", canalIds);
            return ObterPorProcedimento("usp_front_sel_MotivoPausa", parametros);
        }
    }
}
