using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IVendasAppServico
    {
        List<VendasFormViewModel> PesquisarVendas(string dataInicial, string dataFinal, string valorInicial,
            string valorFinal, string nomeCliente, string status);

        List<VendasFormViewModel> ListarVendas();
        VendasFormViewModel ObterVendaPorId(long idVenda);
        List<VendasProdutosFormViewModel> ObterVendaProdutosPorId(long idVenda);
        Vendas SalvarVendas(VendasFormViewModel venda);
        Vendas EditarVendas(VendasFormViewModel venda);
    }
}
