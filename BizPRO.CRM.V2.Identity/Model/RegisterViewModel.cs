using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DomainValidation;


namespace BizPRO.CRM.V2.Identity.Model
{
    public class RegisterViewModel
    {
        public long id { get; set; }
        public string UserID { get; set; }

        [Display(Name = "Departamento")]
        public int? departamentoId { get; set; }

        [Display(Name = "Equipe")]
        public int? equipeID { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo UserName")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A senha deve conter no minimo 6 caracteres !", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a Senha")]
        [Compare("Password", ErrorMessage = "As senhas não conferem !")]
        public string ConfirmPassword { get; set; }

        public long Terminal { get; set; }
        public long Agente { get; set; }
        public List<terminal> TerminaisUsuario { get; set; }
        public string[] selectedRoles { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public RegisterViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }

    }
    public class terminal
    {
        public long? numeroTerminal { get; set; }
        public long? agente { get; set; }
    }

}