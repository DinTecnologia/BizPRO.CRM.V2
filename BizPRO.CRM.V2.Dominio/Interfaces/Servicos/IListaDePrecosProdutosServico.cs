using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IListaDePrecosProdutosServico : IServico<ListaDePrecosProdutos> 
    {
        IEnumerable<ListaDePrecosProdutos> ObterListadePrecosProdutosPorId(int idLista);
    }
}
