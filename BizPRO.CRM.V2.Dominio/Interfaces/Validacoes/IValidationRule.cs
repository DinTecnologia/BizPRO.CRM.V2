namespace BizPRO.CRM.V2.Dominio.Interfaces.Validacoes
{
    public interface IValidationRule<in TEntity>
    {
        string ErrorMessage { get; }
        bool Valid(TEntity entity);
    }
}
