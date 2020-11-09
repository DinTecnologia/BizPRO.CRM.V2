using BizPRO.CRM.V2.Core.ValueObjects;
using DomainValidation.Interfaces.Specification;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Especificacoes.PessoasJuridica
{
    public class ClienteDeveTerCnpjValidoSpecification : ISpecification<PessoaJuridica>
    {
        public bool IsSatisfiedBy(PessoaJuridica cliente)
        {
            return CnpjObjeto.Validar(cliente.Cnpj);
        }
    }
}
