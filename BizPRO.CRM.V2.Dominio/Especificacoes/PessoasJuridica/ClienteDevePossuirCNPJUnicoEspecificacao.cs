using DomainValidation.Interfaces.Specification;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using DapperExtensions;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Especificacoes.PessoasJuridica
{
    public class ClienteDevePossuirCNPJUnicoEspecificacao : ISpecification<PessoaJuridica>
    {
        private readonly IPessoaJuridicaRepositorio _repositorio;

        public ClienteDevePossuirCNPJUnicoEspecificacao(IPessoaJuridicaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public bool IsSatisfiedBy(PessoaJuridica entidade)
        {
            var pg = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            pg.Predicates.Add(Predicates.Field<PessoaJuridica>(f => f.Cnpj, Operator.Eq, entidade.Cnpj));
            return !_repositorio.ObterPor(pg).Any();
        }
    }
}
