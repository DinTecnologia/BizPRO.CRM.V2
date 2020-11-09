using System;
using BizPRO.CRM.V2.Contexto.Interfaces;

namespace BizPRO.CRM.V2.Contexto
{
    public class UnitOfWorkEntity : IUnitOfWorkEntity
    {
        private readonly CrudContext _context;
        private bool _disposed;

        public UnitOfWorkEntity(CrudContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
