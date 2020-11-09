using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IListasDePrecosServico : IServico<ListasDePrecos>
    {
        void Edit(ListasDePrecos lista);

        void RemoverProdutosAntigos(int idListaPreco);

        ListasDePrecos Create(ListasDePrecos lista);

        IEnumerable<ListasDePrecos> ObterListaDePrecos();

        ListasDePrecos ObterListaDePrecosPorId(int idListaPreco);

        void InserirListaDePrecosProdutos(ListaDePrecosProdutos listaProdutos);
    }
}
