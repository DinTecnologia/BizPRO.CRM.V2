using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BizPRO.CRM.V2.Contexto.EntityConfig;

namespace BizPRO.CRM.V2.Contexto
{
    public class CrudContext : DbContext
    {
        public CrudContext()
            : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new UsuarioConfig());
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        var message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }
    }

    // Classe para trocar a ConnectionString do EF em tempo de execução.
    public static class ChangeDb
    {
        public static void ChangeConnection(this CrudContext context, string cn)
        {
            context.Database.Connection.ConnectionString = cn;
        }
    }
}
