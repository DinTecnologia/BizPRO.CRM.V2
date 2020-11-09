using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AtividadeFilasApoioViewModel
    {
        public Fila Fila { get; set; }
        public IEnumerable<AtividadeFilasApoio> AtividadeFilasApoio { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public IEnumerable<StatusAtividade> StatusAtividade { get; set; }
        public long? FilaId { get; set; }
        public SelectList Responsaveis { get; set; }
        public SelectList Criadores { get; set; }
        public SelectList Filas { get; set; }

        public long Total { get; set; }
        public string TotalFilas { get; set; }

        public string AssuntoAtividade { get; set; }

        public AtividadeFilasApoioViewModel()
        {
            Fila = new Fila();
            DataInicio = DateTime.Now.AddDays(-15);
            DataFim = DateTime.Now;
            Responsaveis = new SelectList(new List<Usuario>(), "id", "nome");
            Criadores = new SelectList(new List<Usuario>(), "id", "nome");
            Filas = new SelectList(new List<Fila>(), "id", "nome");
        }

        //public Fila Fila { get; set; }
        //public IEnumerable<AtividadeFilasApoio> AtividadeFilasApoio { get; set; }
        //public DateTime DataInicio { get; set; }
        //public DateTime DataFim { get; set; }
        //public IEnumerable<StatusAtividade> StatusAtividade { get; set; }
        //public long? FilaId { get; set; }
        //public SelectList Responsaveis { get; set; }
        //public SelectList Criadores { get; set; }
        //public SelectList Filas { get; set; }

        //public AtividadeFilasApoioViewModel()
        //{
        //    Fila = new Fila();
        //    DataInicio = DateTime.Now.AddDays(-15);
        //    DataFim = DateTime.Now;
        //    Responsaveis = new SelectList(new List<Usuario>(), "id", "nome");
        //    Criadores = new SelectList(new List<Usuario>(), "id", "nome");
        //    Filas = new SelectList(new List<Fila>(), "id", "nome");
        //}
    }
}
