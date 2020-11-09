using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Contexto.Mapeamento
{
    public class ConfiguracaoMapper : ClassMapper<Configuracao>
    {
        public ConfiguracaoMapper()
        {
            Table("Configuracoes");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Sigla).Column("sigla");
            Map(m => m.Descricao).Column("descricao");
            Map(m => m.Valor).Column("valor");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.AlteradoEm).Column("alteradoEm");
            Map(m => m.AlteradoPorUserId).Column("alteradoPorUserID");
            Map(m => m.Ativo).Column("ativo");
            Map(m => m.PadraoProduto).Column("padraoProduto");
        }
    }
}
