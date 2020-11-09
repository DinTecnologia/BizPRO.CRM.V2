using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ListaDePrecosProdutos
    {
        public int id { get; set; }

        public int ListasDePrecosID { get; set; }

        public int ProdutosID { get; set; }

        
        public float valorSugerido { get; set; }

        public float valorMinimo { get; set; }

        public bool valorLivre { get; set; }

        public string criadoPorAspNetUsers { get; set; }

        public DateTime criadoEm { get; set; }

        public string alteradoPorAspNetUsers { get; set; }

        public DateTime? alteradoEm { get; set; }


    }
}
