using DomainValidation.Interfaces.Specification;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using DapperExtensions;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Especificacoes.PotenciaisClientes
{
    public class PotencialClienteDevePossuirDocumentoUnicoEspecificacao : ISpecification<PotenciaisCliente>
    {

        private readonly IPotenciaisClienteRepositorio _repositorio;
        public PotencialClienteDevePossuirDocumentoUnicoEspecificacao(IPotenciaisClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public bool IsSatisfiedBy(Dominio.Entidades.PotenciaisCliente entidade)
        {
            if (string.IsNullOrEmpty(entidade.documento)) return true;
            var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pg.Predicates.Add(Predicates.Field<PotenciaisCliente>(f => f.documento, Operator.Eq, entidade.documento));
            return _repositorio.ObterPor(pg).Count() == 0;
        }


    }
}