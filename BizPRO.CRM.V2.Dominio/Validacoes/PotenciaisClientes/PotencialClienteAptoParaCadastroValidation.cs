using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Especificacoes.PotenciaisClientes;

namespace BizPRO.CRM.V2.Dominio.Validacoes.PotenciaisClientes
{
    public class PotencialClienteAptoParaCadastroValidation : Validator<Dominio.Entidades.PotenciaisCliente>
    {
        public PotencialClienteAptoParaCadastroValidation(IPotenciaisClienteRepositorio repositorio)
        {
            var cnpjDuplicado = new PotencialClienteDevePossuirDocumentoUnicoEspecificacao(repositorio);
            base.Add("cnpjDuplicado", new Rule<Dominio.Entidades.PotenciaisCliente>(cnpjDuplicado, "CNPJ já cadastrado."));
        }
    }
}
