using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ClienteFormViewModel
    {
        public long Id { get; set; }
        public int? TipoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo 4 caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo 4 caracteres")]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Documento")]
        [MaxLength(14, ErrorMessage = "Máximo 11 caracteres")]
        [MinLength(11, ErrorMessage = "Mínimo 11 caracteres")]
        public string Cpf { get; set; }

        public bool CpfProprio { get; set; }

        public DateTime? DataNascimento { get; set; }

        [EmailAddress]
        [Display(Name = "E-mail")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Email { get; set; }

        public string UserId { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public IEnumerable<SelectListItem> TiposCliente { get; set; }
    }
}
