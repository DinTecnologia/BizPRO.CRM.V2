using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{   
    public class ProdutoTipoMapper : ClassMapper<ProdutoTipo>
    {
        public ProdutoTipoMapper()
        {
            Table("produtosTipos");
            Map(p => p.id).Column("id").Key(KeyType.Identity);
            Map(p => p.nome).Column("nome");
            Map(p => p.criadoEm).Column("criadoEm");
            Map(p => p.criadoPorUserID).Column("criadoPorUserID");
            Map(p => p.ativo).Column("ativo");
        }
    }
}
