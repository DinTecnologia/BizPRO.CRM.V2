using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BizPRO.CRM.V2.Dominio.Entidades;
using ValidationResult = DomainValidation.Validation.ValidationResult;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class LocalPesquisaViewModel
    {
        [Display(Name = "Nome")]
        public long? SegmentoId { get; set; }

        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int? CidadeId { get; set; }
        public long? ContratoId { get; set; }
        public SelectList Segmentos { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public string EnderecoCompleto
        {
            get
            {
                return String.Format("{0}, {1} - {2}, {3} - {4}, {5}", Logradouro, Numero, Bairro, Cidade, Estado, Cep);
            }
        }

        public IEnumerable<LocalListaViewModel> ListaPesquisaLocal { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public LocalPesquisaViewModel()
        {
            ValidationResult = new ValidationResult();
            Segmentos = new SelectList(new List<CampoDinamicoOpcao>(), "id", "nome");
        }

        public LocalPesquisaViewModel(string cep, string logradouro, string numero, string bairro, string cidade,
            string estado, int? cidadeId, long? contratoId, IEnumerable<CampoDinamicoOpcao> segmentos, long? segmentoId,
            double? latitude, double? longitude)
        {
            ValidationResult = new ValidationResult();
            Segmentos = new SelectList(segmentos, "id", "nome");
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            CidadeId = cidadeId;
            ContratoId = contratoId;
            SegmentoId = segmentoId;
            Latitude = latitude;
            Longitude = longitude;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
