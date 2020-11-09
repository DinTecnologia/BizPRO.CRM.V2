using System;
using System.Data;

namespace BizPRO.CRM.V2.Contexto.Interfaces
{
    public interface IDapperContexto : IDisposable
    {
        IDbConnection Connection { get; }
    }
}
