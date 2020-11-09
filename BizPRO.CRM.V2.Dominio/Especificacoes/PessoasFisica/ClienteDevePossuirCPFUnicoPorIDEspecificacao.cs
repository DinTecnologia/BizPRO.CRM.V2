using DomainValidation.Interfaces.Specification;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using DapperExtensions;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Especificacoes.PessoasFisica
{
    class ClienteDevePossuirCPFUnicoPorIDEspecificacao : ISpecification<PessoaFisica>
    {
        private readonly IPessoaFisicaRepositorio _repositorio;
        public ClienteDevePossuirCPFUnicoPorIDEspecificacao(IPessoaFisicaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public bool IsSatisfiedBy(PessoaFisica entidade)
        {
            var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pg.Predicates.Add(Predicates.Field<PessoaFisica>(f => f.Cpf, Operator.Eq, entidade.Cpf));
            var validarCpfPorId = _repositorio.ObterPor(pg).Where(c => c.Id != entidade.Id);
            return !validarCpfPorId.Any();
        }
    }
}
