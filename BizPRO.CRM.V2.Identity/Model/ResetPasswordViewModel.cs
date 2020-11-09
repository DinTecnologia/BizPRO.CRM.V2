using System.ComponentModel.DataAnnotations;

namespace BizPRO.CRM.V2.Identity.Model
{
    public class ResetPasswordViewModel
    {
  
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

      
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} precisa ter o minimo de {2} caracteres .", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não conferem .")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }

        public string token { get; set; }

    }
}