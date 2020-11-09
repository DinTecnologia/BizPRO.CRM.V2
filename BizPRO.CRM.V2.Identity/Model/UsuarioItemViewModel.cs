using System.ComponentModel.DataAnnotations;

namespace BizPRO.CRM.V2.Identity.Model
{
    public class UsuarioItemViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não esta em um formato válido.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha.")]
        [StringLength(100, ErrorMessage = "A {0} deve ter de pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação Senha")]
        [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não coincidem.")]
        public string ConfirmPassword { get; set; }
    }
}
