using DomainValidation.Validation;
namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IContaAppServico
    {
        ValidationResult EnviarEmail(string url, string emailUsuario);
    }
}
