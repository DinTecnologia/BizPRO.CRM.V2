using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Validacoes
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}
