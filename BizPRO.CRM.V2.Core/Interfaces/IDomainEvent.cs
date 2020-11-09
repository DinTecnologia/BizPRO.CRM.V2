using System;

namespace BizPRO.CRM.V2.Core.Interfaces
{
    public interface IDomainEvent
    {
        int Versao { get; }
        DateTime DataOcorrencia { get; }
    }
}