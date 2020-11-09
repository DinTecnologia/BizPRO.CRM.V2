using System;
using System.Data.Entity;
using BizPRO.CRM.V2.Identity.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BizPRO.CRM.V2.Identity.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Claims> Claims { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}