using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class AtendimentoAtividadeMapper : ClassMapper<AtendimentoAtividade>
    {
        public AtendimentoAtividadeMapper()
        {
            Table("AtendimentosAtividades");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.AtividadesId).Column("AtividadesID");
            Map(m => m.AtendimentosId).Column("AtendimentosID");
        }
    }
}
