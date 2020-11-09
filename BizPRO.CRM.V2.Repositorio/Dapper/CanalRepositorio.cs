using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Collections.Generic;
using DapperExtensions;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class CanalRepositorio : Repositorio<Canal>, ICanalRepositorio
    {
        public CanalRepositorio(IDapperContexto context)
            : base(context)
        {
        }

        public IEnumerable<Canal> ObterPorNome(string nome)
        {
            var where = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            where.Predicates.Add(Predicates.Field<Canal>(f => f.Nome, Operator.Like, "%" + nome + "%"));
            return ObterPor(where);
        }
    }
}
