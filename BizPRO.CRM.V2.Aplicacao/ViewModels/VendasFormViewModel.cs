using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Enums;
using System.Web.Mvc;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class VendasFormViewModel
    {
        public VendasFormViewModel()
        {
            this.ListaVendasProduto = new List<VendasProdutosFormViewModel>();
        }

        public VendasFormViewModel(IEnumerable<Vendas> ListaVendas)
        {
            List<VendasFormViewModel> lista  = new List<VendasFormViewModel>();
        }

        public long id { get; set; }

        public long? PessoasFisicasID { get; set; }

        public long? PessoasJuridicasID { get; set; }

        public string criadoPorUserID { get; set; }

        public DateTime criadoEm { get; set; }

        public string alteradoPorUserID { get; set; }

        public DateTime? alteradoEm { get; set; }

        public decimal valorTotal { get; set; }

        public int qtdItens { get; set; }

        public int ListasDePrecosID { get; set; }

        public int StatusEntidadeID { get; set; }        

        public IEnumerable<Produto> SProdutos { get; set; }

        public List<ListaDePrecosViewModel> ListaDePrecos { get; set; }

        public ClientePerfilViewModel Cliente { get; set; }

        public List<ListaDePrecosProdutoViewModel> listaDeProdutos { get; set; }

        public List<VendasProdutosFormViewModel> ListaVendasProduto { get; set; }

        public IEnumerable<StatusEntidade> StatusEntidade { get; set; }


        /*Filtro*/

        public DateTime? dataInicio { get; set; }
        public DateTime? dataFim { get; set; }
        public decimal valorInicio { get; set; }
        public decimal valorFim { get; set; }
        public string nomeCliente { get; set; }
        public string Status { get; set; }



    }
}
