using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Especificacoes.PotenciaisClientes;

namespace BizPRO.CRM.V2.Dominio.Validacoes.PotenciaisClientes
{
    public class PotenciaisClienteValidacoes : Validator<PotenciaisCliente>
    { 
        public PotenciaisClienteValidacoes()
        {
            var DocumentoCliente = new ClienteDeveTerDocumentoValido();
            base.Add("DocumentoCliente", new Rule<PotenciaisCliente>(DocumentoCliente, "Documento Invalido"));
        }
    }
}
