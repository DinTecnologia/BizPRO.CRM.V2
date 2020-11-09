using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Validacoes
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}
