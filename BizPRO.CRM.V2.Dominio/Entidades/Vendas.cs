using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Vendas
    {
        public Vendas()
        {
            ListaVendasProduto = new List<VendasProdutos>();
        }

        public long id { get;  set; }

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
   
        public IEnumerable<VendasProdutos> ListaVendasProduto { get; set; }        

    }
}
