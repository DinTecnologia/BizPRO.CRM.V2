using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;


namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IProdutoServico : IServico<Produto>
    {
        IEnumerable<Produto> ObterProdutoAtivo(long? idProduto);
        IEnumerable<Produto> ObterProdutoPorContratoId(long contratoId);
        IEnumerable<Produto> ObterProdutoPorTipoId(long produtoTipoId);
    }
}
