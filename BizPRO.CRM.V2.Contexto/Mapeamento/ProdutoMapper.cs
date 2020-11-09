using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Contexto.Mapeamento
{
    public class ProdutoMapper : ClassMapper<Produto>
    {
        public ProdutoMapper()
        {
            Table("produtos");
            Map(p => p.id).Column("id").Key(KeyType.Identity);
            Map(p => p.codigo).Column("codigo");
            Map(p => p.nome).Column("nome");
            Map(p => p.ativo).Column("ativo");
            Map(p => p.tipoProdutoID).Column("tipoProdutoID");
            Map(p => p.criadoEm).Column("criadoEm");
            Map(p => p.criadoPorUserID).Column("criadoPorUserID");
            Map(p => p.alteradoEm).Column("alteradoEm");
            Map(p => p.alteradoPorUserID).Column("alteradoPorUserID");
            Map(p => p.descritivo).Column("descritivo");
        }
    }
}
