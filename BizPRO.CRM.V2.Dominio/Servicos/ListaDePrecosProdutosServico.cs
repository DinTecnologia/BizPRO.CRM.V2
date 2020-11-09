using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ListaDePrecosProdutosServico : Servico<ListaDePrecosProdutos>, IListaDePrecosProdutosServico
    {
        private readonly IListaDePrecosProdutoRepositorio _repositorio;
        private DynamicParameters _parametros = null;

        public ListaDePrecosProdutosServico(IListaDePrecosProdutoRepositorio repositorio, DynamicParameters parametros)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<ListaDePrecosProdutos> ObterListadePrecosProdutosPorId(int idLista)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@ID", idLista);

            return _repositorio.ObterPorProcedimento("usp_front_sel_ListaDePrecosProdutosPorID", _parametros);
        }
    }
}
