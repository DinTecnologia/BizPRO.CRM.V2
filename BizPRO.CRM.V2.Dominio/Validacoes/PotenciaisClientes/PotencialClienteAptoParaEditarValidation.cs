using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Especificacoes.PotenciaisClientes;


namespace BizPRO.CRM.V2.Dominio.Validacoes.PotenciaisClientes
{
    public class PotencialClienteAptoParaEditarValidation : Validator<PotenciaisCliente>
    {
       public PotencialClienteAptoParaEditarValidation(IPotenciaisClienteRepositorio repositorio)
       {
           var cpfDuplicado = new PotencialClienteDevePossuirDocumentoUnicoPorIDEspecificacao(repositorio);
           base.Add("cpfDuplicado", new Rule<PotenciaisCliente>(cpfDuplicado, "Documento já cadastrado."));
       }
    }
}
