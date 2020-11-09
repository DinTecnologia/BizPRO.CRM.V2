using DomainValidation.Interfaces.Specification;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using DapperExtensions;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Especificacoes.PessoasFisica
{
    class ClienteDevePossuirCNPJUnicoPorIDEspecificacao : ISpecification<PessoaJuridica>
    {
        private readonly IPessoaJuridicaRepositorio _repositorio;

        public ClienteDevePossuirCNPJUnicoPorIDEspecificacao(IPessoaJuridicaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public bool IsSatisfiedBy(PessoaJuridica entidade)
        {
            var pg = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            pg.Predicates.Add(Predicates.Field<PessoaJuridica>(f => f.Cnpj, Operator.Eq, entidade.Cnpj));
            var validarCnpjPorId = _repositorio.ObterPor(pg).Where(c => c.Id != entidade.Id);
            return !validarCnpjPorId.Any();
        }
    }
}
