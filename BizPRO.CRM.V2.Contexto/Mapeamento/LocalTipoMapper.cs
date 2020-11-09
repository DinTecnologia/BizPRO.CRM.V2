using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{  
    public class LocalTipoMapper : ClassMapper<LocalTipo>
    {
        public LocalTipoMapper()
        {
            Table("LocaisTipos");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("nome");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.AlteradoPorUserId).Column("alteradoPorUserID");
            Map(m => m.AlteradoEm).Column("alteradoEm");
        }
    }
}
