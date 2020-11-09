using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class LocaisLocalTipoAtendimentoMapper : ClassMapper<LocaisLocalTipoAtendimento>
    {
        public LocaisLocalTipoAtendimentoMapper()
        {
            Table("LocaisLocaisTiposAtendimento");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.LocaisTiposAtendimentoId).Column("locaisTiposAtendimentoID");
            Map(m => m.LocaisId).Column("locaisID");
        }
    }
}
