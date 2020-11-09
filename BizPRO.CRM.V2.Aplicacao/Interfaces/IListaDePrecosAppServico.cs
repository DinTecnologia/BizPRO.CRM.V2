using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IListasDePrecosAppServico
    {
        ListaDePrecosViewModel Edit(ListaDePrecosViewModel viewModel);

        ListaDePrecosViewModel Create(ListaDePrecosViewModel viewModel);

        ListaDePrecosViewModel ObterListadePrecosPorId(int idListaDePreco);

        List<ListaDePrecosProdutoViewModel> CarregarListaDeProdutos(int idListaDePreco);

        void SalvarListaDePrecoProdutos(ListaDePrecosViewModel viewModel);

        IEnumerable<ListasDePrecos> ObterTodos();
    }
}
