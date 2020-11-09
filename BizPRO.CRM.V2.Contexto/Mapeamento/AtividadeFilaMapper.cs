using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class AtividadeFilaMapper : ClassMapper<AtividadeFila>
    {
        public AtividadeFilaMapper()
        {
            Table("AtividadesFilas");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.AtividadeId).Column("atividadeID");
            Map(m => m.FilaId).Column("filaID");
            Map(m => m.EntrouNaFilaEm).Column("entrouNaFilaEm");
            Map(m => m.SaiuDaFilaEm).Column("saiuDaFilaEm");
        }
    }
}
