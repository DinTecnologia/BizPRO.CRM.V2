using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IVendasServico : IServico<Vendas>
    {
        IEnumerable<Vendas> ListarVendas();

        Vendas SalvarVendas(Vendas venda);

        Vendas EditarVendas(Vendas venda);

        Vendas ObterVendaPorId(long idVenda);
    }
}
