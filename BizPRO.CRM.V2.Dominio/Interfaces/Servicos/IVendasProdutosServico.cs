using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IVendasProdutosServico : IServico<VendasProdutos>
    {
        void RemoverVendaProduto(long idVenda);
    }
}
