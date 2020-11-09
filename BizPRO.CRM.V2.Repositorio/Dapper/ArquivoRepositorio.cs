using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using DapperExtensions;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class ArquivoRepositorio : Repositorio<Arquivo>, IArquivoRepositorio
    {
        public ArquivoRepositorio(IDapperContexto context) : base(context)
        {

        }

        public IEnumerable<Arquivo> ObterPor(long chaveEntidadeId, long entidadeId)
        {
            var pg = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            pg.Predicates.Add(Predicates.Field<Arquivo>(f => f.ChaveEntidadeId, Operator.Eq, chaveEntidadeId));
            pg.Predicates.Add(Predicates.Field<Arquivo>(f => f.EntidadeId, Operator.Eq, entidadeId));
            return ObterPor(pg);
        }
    }
}
