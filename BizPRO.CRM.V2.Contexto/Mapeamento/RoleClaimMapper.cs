using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class RoleClaimMapper : ClassMapper<RoleClaim>
    {
        public RoleClaimMapper()
        {
            Table("AspNetRolesClaims");
            Map(m => m.id).Column("id").Key(KeyType.Identity);
            Map(m => m.roleID).Column("roleID");
            Map(m => m.claimID).Column("claimID");
            Map(m => m.claimType).Column("claimType");
            Map(m => m.claimValue).Column("claimValue");            
        }
    }
}
