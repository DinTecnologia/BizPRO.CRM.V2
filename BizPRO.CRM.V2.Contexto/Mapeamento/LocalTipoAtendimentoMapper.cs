using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{   
    public class LocalTipoAtendimentoMapper : ClassMapper<LocalTipoAtendimento>
    {
        public LocalTipoAtendimentoMapper()
        {
            Table("LocaisTiposAtendimento");
            Map(m => m.id).Column("id").Key(KeyType.Identity);
            Map(m => m.nome).Column("nome");
            Map(m => m.ativo).Column("ativo");
            Map(m => m.criadoPorUserID).Column("criadoPorUserID");
            Map(m => m.criadoEm).Column("criadoEm");
            Map(m => m.alteradoPorUserID).Column("alteradoPorUserID");
            Map(m => m.alteradoEm).Column("alteradoEm");
        }
    }
}
