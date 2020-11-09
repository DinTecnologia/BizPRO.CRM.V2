using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BizPRO.CRM.V2.Identity.Model
{
    public class ApplicationUser : IdentityUser
    {

        public bool ativo { get; set; }
        public string nome { get; set; }
        public int? departamentoId { get; set; }
        public int? equipeID { get; set; }

        //public string SuperiorImediatoId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}