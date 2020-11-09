using System.ComponentModel.DataAnnotations;
using System;


namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class UsuarioRegisterViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter de pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação Senha")]
        [Compare("Password", ErrorMessage = "A senha e confirmação não coincidem.")]
        public string ConfirmPassword { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
