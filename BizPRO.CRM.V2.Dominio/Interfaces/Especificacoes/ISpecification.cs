namespace BizPRO.CRM.V2.Dominio.Interfaces.Especificacoes
{
    public interface ISpecification<in TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}