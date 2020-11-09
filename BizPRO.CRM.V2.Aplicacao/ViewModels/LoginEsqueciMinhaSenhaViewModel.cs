using System.ComponentModel.DataAnnotations;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class LoginEsqueciMinhaSenhaViewModel
    {
        [Required(ErrorMessage = "Informe o E-mail.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "O e-mail informado não esta em um formato válido.")]
        public string Email { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
