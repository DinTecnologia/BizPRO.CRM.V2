namespace BizPRO.CRM.V2.Contexto.Interfaces
{
    public interface IUnitOfWorkEntity
    {
        void BeginTransaction();
        void Commit();
    }
}
