using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Collections.Generic;
using DapperExtensions;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class AplicacaoRepositorio : Repositorio<BizPRO.CRM.V2.Dominio.Entidades.Aplicacao>, IAplicacaoRepositorio
    {
        public AplicacaoRepositorio(IDapperContexto context)
            : base(context)
        {
        }

        public IEnumerable<BizPRO.CRM.V2.Dominio.Entidades.Aplicacao> BuscarAplicacao(string host)
        {
            var where = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            where.Predicates.Add(Predicates.Field<BizPRO.CRM.V2.Dominio.Entidades.Aplicacao>(f => f.Url, Operator.Like, "%" + host + "%"));
            return ObterPor(where);
        }

        public IEnumerable<BizPRO.CRM.V2.Dominio.Entidades.Aplicacao> ObterAplicacao(string nome)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<BizPRO.CRM.V2.Dominio.Entidades.Aplicacao>(f => f.Nome, Operator.Eq, nome));
            return ObterPor(where);
        }
    }
}
