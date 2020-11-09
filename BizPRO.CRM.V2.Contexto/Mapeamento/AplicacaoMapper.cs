using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class AplicacaoMapper : ClassMapper<BizPRO.CRM.V2.Dominio.Entidades.Aplicacao>
    {
        public AplicacaoMapper()
        {
            Table("aplicacoes");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("nome");
            Map(m => m.Url).Column("url");
            Map(m => m.Ssl).Column("ssl");
        }
    }
}
