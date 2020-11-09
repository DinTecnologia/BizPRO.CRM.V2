using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{    
    public class LocalTipoAtendimentoRepositorio : Repositorio<LocalTipoAtendimento>, ILocalTipoAtendimentoRepositorio
    {
        public LocalTipoAtendimentoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<LocalTipoAtendimento> ObterLocalTiposAtendimentoPorLocalId(long localId)
        {
            var where = new DynamicParameters();
            where.Add("@localID", localId);
            return ObterPorProcedimento("usp_front_sel_TipoAtendimento", where);
        }
    }
}
