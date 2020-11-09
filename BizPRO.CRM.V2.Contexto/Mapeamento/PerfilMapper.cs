using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class PerfilMapper : ClassMapper<Perfil>
    {
        public PerfilMapper()
        {
            Table("AspNetRoles");
            Map(m => m.Id).Column("Id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("Name");
            Map(m => m.FuncionalidadeId).Column("funcionalidadeId");
            Map(m => m.Ordem).Column("ordem");
        }
    }
}
