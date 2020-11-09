using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class AspNetRolesMenuMapper : ClassMapper<AspNetRolesMenu>
    {
        public AspNetRolesMenuMapper()
        {
            Table("AspNetRolesMenus");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.AspNetRolesId).Column("AspNetRolesID");
            Map(m => m.MenusId).Column("MenusID");
        }
    }
}
