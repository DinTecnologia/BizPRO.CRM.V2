using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class TimelineApoioRepositorio : Repositorio<TimelineApoio>, ITimelineApoioRepositorio
    {
        public TimelineApoioRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<TimelineApoio> ObterPor(long? pessoaFisicaId, long? pessoaJuridicaId)
        {   
            var where = new DynamicParameters();
            where.Add("@pessoaFisicaID", pessoaFisicaId);
            where.Add("@pessoaJuridicaID", pessoaJuridicaId);
            return Conn.Query<TimelineApoio>("usp_front_sel_Timeline", where, commandType: CommandType.StoredProcedure);
        }
    }
}
