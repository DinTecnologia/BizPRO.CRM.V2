using System.Collections.Generic;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using DapperExtensions;
using System.Linq;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class EntidadeRepositorio : Repositorio<Entidade>, IEntidadeRepositorio
    {
        public EntidadeRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Entidade> ObterPorSigla(string sigla)
        {
            var pg = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            pg.Predicates.Add(Predicates.Field<Entidade>(f => f.Sigla, Operator.Eq, sigla));
            return Conn.GetList<Entidade>(pg);
        }

        public Entidade ObterEntidadePorNomeLogico(string nomeLogico)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<Entidade>(f => f.NomeLogico, Operator.Like, "%" + nomeLogico + "%"));
            return Conn.GetList<Entidade>(where).FirstOrDefault();
        }

        public Entidade ObterPorNomeLogico(string nomeLogico)
        {
            if (string.IsNullOrEmpty(nomeLogico))
                return null;

            var pg = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            pg.Predicates.Add(Predicates.Field<Entidade>(f => f.NomeLogico, Operator.Eq, nomeLogico));
            return this.Conn.GetList<Entidade>(pg).FirstOrDefault();
        }
    }
}
