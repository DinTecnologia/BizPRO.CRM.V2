using BizPRO.CRM.V2.Core.ValueObjects;
using DomainValidation.Interfaces.Specification;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Especificacoes.PotenciaisClientes
{
    public class ClienteDeveTerDocumentoValido : ISpecification<PotenciaisCliente>
    {
        public bool IsSatisfiedBy(PotenciaisCliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.documento)) return true;
            if (string.IsNullOrEmpty(cliente.tipo)) return false;

            return cliente.tipo.ToUpper() == "PJ"
                ? CnpjObjeto.Validar(cliente.documento)
                : CpfObjeto.Validar(cliente.documento);
        }
    }
}
