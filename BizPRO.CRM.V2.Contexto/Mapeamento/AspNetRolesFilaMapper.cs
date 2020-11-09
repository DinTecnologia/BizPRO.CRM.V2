using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class AspNetRolesFilaMapper : ClassMapper<AspNetRolesFila>
    {
        public AspNetRolesFilaMapper()
        {
            Table("AspNetRolesFilas");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.FilasId).Column("FilasID");
            Map(m => m.AspNetRolesId).Column("AspNetRolesID");
        }
    }
}
