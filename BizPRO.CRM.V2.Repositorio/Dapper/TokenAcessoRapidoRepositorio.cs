using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using DapperExtensions;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class TokenAcessoRapidoRepositorio : Repositorio<TokenAcessoRapido>, ITokenAcessoRapidoRepositorio
    {
        public TokenAcessoRapidoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public TokenAcessoRapido ObterPorId(string id)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<TokenAcessoRapido>(f => f.Id, Operator.Eq, id));
            return ObterPor(where).FirstOrDefault();
        }
    }
}
