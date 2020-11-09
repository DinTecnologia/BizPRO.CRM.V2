using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ListasDePrecosServico : Servico<ListasDePrecos>, IListasDePrecosServico
    {
        private readonly IListasDePrecosRepositorio _repositorio;
        private readonly DynamicParameters _parametros = null;

        public ListasDePrecosServico(IListasDePrecosRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public void Edit(ListasDePrecos lista)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ID", lista.Id);
            parametros.Add("@CODIGO", lista.Codigo);
            parametros.Add("@NOME", lista.Nome);
            parametros.Add("@inicioVigencia", lista.InicioVigencia);
            parametros.Add("@terminoVigencia", lista.TerminoVigencia);
            parametros.Add("@alteradoPor", lista.AlteradoPorAspNetUsers);
            parametros.Add("@alteradoEm", lista.AlteradoEm);
            parametros.Add("@STATUS", lista.Status);
            _repositorio.ExecutarProcedimento("usp_front_upd_ListasDePrecos", parametros);
        }

        public ListasDePrecos Create(ListasDePrecos lista)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@CODIGO", lista.Codigo);
            parametros.Add("@NOME", lista.Nome);
            parametros.Add("@inicioVigencia", lista.InicioVigencia);
            parametros.Add("@terminoVigencia", lista.TerminoVigencia);
            parametros.Add("@criadoPor", lista.CriadoPorAspNetUsers);
            parametros.Add("@criadoEm", lista.CriadoEm);
            parametros.Add("@STATUS", lista.Status);
            return _repositorio.ObterPorProcedimento("usp_front_ins_ListasDePrecos", parametros).FirstOrDefault();


        }

        public void InserirListaDePrecosProdutos(ListaDePrecosProdutos listaProduto)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@listaID", listaProduto.ListasDePrecosID);
            parametros.Add("@produtoID", listaProduto.ProdutosID);
            parametros.Add("@valorSugerido", listaProduto.valorSugerido);
            parametros.Add("@valorMinimo", listaProduto.valorMinimo);
            parametros.Add("@valorLivre", listaProduto.valorLivre);
            parametros.Add("@criadoPor", listaProduto.criadoPorAspNetUsers);
            parametros.Add("@criadoEm", listaProduto.criadoEm);

            _repositorio.ExecutarProcedimento("usp_front_ins_ListasDePrecosProdutos", parametros);

        }

        public IEnumerable<ListasDePrecos> ObterListaDePrecos()
        {
            return _repositorio.ObterPorProcedimento("usp_front_sel_ListasDePrecos", _parametros);
        }

        public void RemoverProdutosAntigos(int idListaPreco)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@listaID", idListaPreco);
            _repositorio.ExecutarProcedimento("usp_front_del_ListasDePrecosProdutosAntigos", parametros);
        }

        public ListasDePrecos ObterListaDePrecosPorId(int idListaPreco)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@listaID", idListaPreco);
            return _repositorio.ObterPorProcedimento("usp_front_sel_ListasDePrecosPorID", parametros).FirstOrDefault();
        }
    }
}
