using System;
using System.Data;
using BizPRO.CRM.V2.Contexto.Interfaces;

namespace BizPRO.CRM.V2.Contexto
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public IDapperContexto Context { get; private set; }
        public IDbTransaction Transaction { get; private set; }

        public UnitOfWork(IDapperContexto context)
        {
            Context = context;
        }

        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot)
        {
            return Transaction ?? (Transaction = Context.Connection.BeginTransaction(isolationLevel));
        }

        public void Commit()
        {
            if (Transaction == null) return;

            Transaction.Commit();
            Transaction.Dispose();
            Transaction = null;
        }

        public void Rollback()
        {
            Transaction.Rollback();
            Transaction = null;
        }

        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
            }
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
