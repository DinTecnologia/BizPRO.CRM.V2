using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class ContratoProdutoMapper : ClassMapper<ContratoProduto>
    {
        public ContratoProdutoMapper()
        {
            Table("ContratoProdutos");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.ProdutoId).Column("produtoID");
            Map(m => m.ContratoId).Column("contratoID");
        }
    }
}
