using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ListasDePrecos
    {
        public ListasDePrecos()
        {
            ListaDeProdutos = new List<ListaDePrecosProdutos>();
        }

        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Nome { get; set; }

        public DateTime? InicioVigencia { get; set; }

        public DateTime? TerminoVigencia { get; set; }

        public string CriadoPorAspNetUsers { get; set; }

        public DateTime CriadoEm { get; set; }

        public string AlteradoPorAspNetUsers { get; set; }

        public DateTime? AlteradoEm { get; set; }

        public IEnumerable<ListaDePrecosProdutos> ListaDeProdutos { get; set; }

        public bool Status { get; set; }
    }
}
