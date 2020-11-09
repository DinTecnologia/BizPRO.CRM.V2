using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class LocalServicoMapper : ClassMapper<LocalServico>
    {
        public LocalServicoMapper()
        {
            Table("LocaisServicos");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.LocaisId).Column("locaisID");
            Map(m => m.ServicosId).Column("servicosID");
        }
    }
}
