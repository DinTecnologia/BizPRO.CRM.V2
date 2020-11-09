using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Core.Events;
using BizPRO.CRM.V2.Core.Interfaces;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class AppServico
    {
        private readonly IUnitOfWorkEntity _uow;
        protected readonly IHandler<DomainNotification> Notifications;

        public AppServico(IUnitOfWorkEntity uow)
        {
            _uow = uow;
            Notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();
        }
        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }
        public bool Commit()
        {
            if (Notifications.HasNotifications())
                return false;

            _uow.Commit();
            return true;
        }
    }
}
