using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Core.Interfaces
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);
        IEnumerable<T> Notify();
        bool HasNotifications();
        List<T> GetValues();
    }
}