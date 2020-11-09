using BizPRO.CRM.V2.Core.ValueObjects;
using DomainValidation.Interfaces.Specification;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Especificacoes.PessoasFisica
{
    public class ClienteDeveTerCpfValidoSpecification : ISpecification<PessoaFisica>
    {
        public bool IsSatisfiedBy(PessoaFisica cliente)
        {
            return CpfObjeto.Validar(cliente.Cpf);
        }
    }
}
