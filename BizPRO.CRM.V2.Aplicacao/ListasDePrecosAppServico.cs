using System;
using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class ListasDePrecosAppServico : IListasDePrecosAppServico
    {
        private readonly IListasDePrecosServico _servicoListasDePrecos;
        private readonly IListaDePrecosProdutosServico _servicoListaDePrecosProdutos;


        public ListasDePrecosAppServico(IListasDePrecosServico servicoListasDePrecos,
            IListaDePrecosProdutosServico servicoListaDePrecosProdutos)
        {
            _servicoListasDePrecos = servicoListasDePrecos;
            _servicoListaDePrecosProdutos = servicoListaDePrecosProdutos;

        }

        public List<ListaDePrecosProdutoViewModel> CarregarListaDeProdutos(int idLista)
        {
            List<ListaDePrecosProdutoViewModel> viewModel = new List<ListaDePrecosProdutoViewModel>();
            IEnumerable<ListaDePrecosProdutos> lista =
                _servicoListaDePrecosProdutos.ObterListadePrecosProdutosPorId(idLista);

            foreach (var item in lista)
            {
                viewModel.Add(new ListaDePrecosProdutoViewModel
                {
                    id = item.id,
                    ListasDePrecosID = item.ListasDePrecosID,
                    ProdutosID = item.ProdutosID,
                    valorSugerido = item.valorSugerido,
                    valorMinimo = item.valorMinimo,
                    valorLivre = item.valorLivre,
                    criadoPorAspNetUsers = item.criadoPorAspNetUsers,
                    criadoEm = item.criadoEm,
                    alteradoPorAspNetUsers = item.alteradoPorAspNetUsers,
                    alteradoEm = item.alteradoEm
                });
            }

            return viewModel;
        }

        public ListaDePrecosViewModel ObterListadePrecosPorId(int idListaDePreco)
        {
            ListasDePrecos listaDePrecos = this._servicoListasDePrecos.ObterListaDePrecosPorId(idListaDePreco);

            ListaDePrecosViewModel viewModel = new ListaDePrecosViewModel();
            viewModel.Id = listaDePrecos.Id;
            viewModel.Codigo = listaDePrecos.Codigo;
            viewModel.Nome = listaDePrecos.Nome;
            viewModel.Status = listaDePrecos.Status;
            viewModel.InicioVigencia = listaDePrecos.InicioVigencia;
            viewModel.TerminoVigencia = listaDePrecos.TerminoVigencia;
            viewModel.CriadoEm = listaDePrecos.CriadoEm;
            viewModel.CriadoPorAspNetUsers = listaDePrecos.CriadoPorAspNetUsers;
            viewModel.ListaDeProdutos = CarregarListaDeProdutos(idListaDePreco);

            return viewModel;
        }

        public ListaDePrecosViewModel ObterListadePrecosProdutosPorId(int idListaDePreco)
        {
            var viewModel = ObterListadePrecosPorId(idListaDePreco);
            viewModel.ListaDeProdutos = CarregarListaDeProdutos(idListaDePreco);

            return viewModel;
        }

        public ListaDePrecosViewModel Edit(ListaDePrecosViewModel viewModel)
        {

            ListasDePrecos listaDePrecos = new ListasDePrecos();
            listaDePrecos.Id = viewModel.Id;
            listaDePrecos.Codigo = viewModel.Codigo;
            listaDePrecos.Nome = viewModel.Nome;
            listaDePrecos.Status = viewModel.Status;
            listaDePrecos.InicioVigencia = viewModel.InicioVigencia;
            listaDePrecos.TerminoVigencia = viewModel.TerminoVigencia;
            listaDePrecos.CriadoPorAspNetUsers = viewModel.CriadoPorAspNetUsers;
            listaDePrecos.CriadoEm = viewModel.CriadoEm;
            listaDePrecos.AlteradoEm = DateTime.Now;
            listaDePrecos.AlteradoPorAspNetUsers = viewModel.AlteradoPorAspNetUsers;

            this._servicoListasDePrecos.Edit(listaDePrecos);

            return viewModel;
        }

        public void SalvarListaDePrecoProdutos(ListaDePrecosViewModel listaDePrecos)
        {

            this._servicoListasDePrecos.RemoverProdutosAntigos(
                listaDePrecos.ListaDeProdutos.FirstOrDefault().ListasDePrecosID);

            foreach (var item in listaDePrecos.ListaDeProdutos)
            {
                ListaDePrecosProdutos ldp = new ListaDePrecosProdutos();
                ldp.ListasDePrecosID = item.ListasDePrecosID;
                ldp.ProdutosID = item.ProdutosID;
                ldp.valorLivre = item.valorLivre;
                ldp.valorMinimo = item.valorMinimo;
                ldp.valorSugerido = item.valorSugerido;
                ldp.criadoEm = DateTime.Now;
                ldp.criadoPorAspNetUsers = listaDePrecos.CriadoPorAspNetUsers;

                this._servicoListasDePrecos.InserirListaDePrecosProdutos(ldp);
            }

        }

        public ListaDePrecosViewModel Create(ListaDePrecosViewModel viewModel)
        {

            ListasDePrecos listaDePrecos = new ListasDePrecos();
            listaDePrecos.Codigo = viewModel.Codigo;
            listaDePrecos.Nome = viewModel.Nome;
            listaDePrecos.Status = viewModel.Status;
            listaDePrecos.InicioVigencia = viewModel.InicioVigencia;
            listaDePrecos.TerminoVigencia = viewModel.TerminoVigencia;
            listaDePrecos.CriadoEm = DateTime.Now;
            listaDePrecos.CriadoPorAspNetUsers = viewModel.CriadoPorAspNetUsers;

            listaDePrecos = this._servicoListasDePrecos.Create(listaDePrecos);

            foreach (var item in viewModel.ListaDeProdutos)
            {
                item.ListasDePrecosID = listaDePrecos.Id;
                //this._servicoListasDePrecos.InserirListaDePrecosProdutos(item);
            }

            return viewModel;
        }

        public IEnumerable<ListasDePrecos> ObterTodos()
        {

            return this._servicoListasDePrecos.ObterListaDePrecos();

        }
    }
}
