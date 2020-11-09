using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ListaDePrecosViewModel
    {
        public ListaDePrecosViewModel()
        {
            ListaDeProdutos = new List<ListaDePrecosProdutoViewModel>();
            SProdutos = new List<Produto>();
        }

        public int Id { get; set; }

        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [Required(ErrorMessage = "Preencha o campo Código")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        public DateTime? InicioVigencia { get; set; }

        public DateTime? TerminoVigencia { get; set; }

        public string CriadoPorAspNetUsers { get; set; }

        public DateTime CriadoEm { get; set; }

        public string AlteradoPorAspNetUsers { get; set; }

        public DateTime? AlteradoEm { get; set; }

        public List<ListaDePrecosProdutoViewModel> ListaDeProdutos { get; set; }

        public IEnumerable<Produto> SProdutos { get; set; }

        public bool Status { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
