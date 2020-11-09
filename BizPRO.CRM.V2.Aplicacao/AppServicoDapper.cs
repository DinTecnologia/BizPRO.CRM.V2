using BizPRO.CRM.V2.Core.Events;
using BizPRO.CRM.V2.Core.Interfaces;
using DomainValidation.Validation;


namespace BizPRO.CRM.V2.Aplicacao
{
    public class AppServicoDapper
    {
        protected readonly IHandler<DomainNotification> Notifications;
        public AppServicoDapper()
        {
            ValidationResult = new ValidationResult();
        }
        protected ValidationResult ValidationResult { get; private set; }
    }
}
