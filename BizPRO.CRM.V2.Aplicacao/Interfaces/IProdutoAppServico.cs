using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IProdutoAppServico
    {
        IEnumerable<Produto> ObterProdutosPorContratoId(long contratoId);
        IEnumerable<Produto> ObterProdutoAtivo(int? idProduto);
        ProdutoFormViewModel ObterProdutoPorId(int idProduto);
        ProdutoFormViewModel Edit(ProdutoFormViewModel viewModel);
        ProdutoFormViewModel Create(ProdutoFormViewModel viewModel);
        ProdutoFormViewModel Carregar();
    }
}
