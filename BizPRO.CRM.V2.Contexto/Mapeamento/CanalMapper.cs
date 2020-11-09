using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;


namespace Camadas.Infra.Dados.Contexto.Mapeamento
{    
    public class CanalMapper : ClassMapper<Canal>
    {
        public CanalMapper()
        {
            Table("Canais");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("nome");          
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorAspNetUserId).Column("criadoPorAspNetUserID");
        }
    }
}
