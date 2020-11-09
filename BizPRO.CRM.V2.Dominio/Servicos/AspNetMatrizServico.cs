using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DapperExtensions;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AspNetMatrizServico : IAspNetMatrizServico
    {
        private readonly IAspNetMatrizRepositorio _repositorio;

        public AspNetMatrizServico(IAspNetMatrizRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public IEnumerable<AspNetMatriz> ObterPor(string sentido)
        {
            var where = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            where.Predicates.Add(Predicates.Field<AspNetMatriz>(f => f.Sentido, Operator.Eq, sentido));
            return _repositorio.ObterPor(where);
        }
        public IEnumerable<AspNetMatriz> ObterPor(string claimId, string sentido)
        {
            return _repositorio.ObterPor(claimId, sentido);
        }
    }
}
