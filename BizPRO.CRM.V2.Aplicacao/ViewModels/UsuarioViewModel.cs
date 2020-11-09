using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class UsuarioViewModel
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Departamento { get; set; }
        public string Perfil { get; set; }
        public bool PartialViewMinimizada { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public UsuarioViewModel(string erro, bool partialViewMinimizada)
        {
            ValidationResult = new ValidationResult();
            ValidationResult.Add(new ValidationError(erro));
            PartialViewMinimizada = partialViewMinimizada;
        }

        public UsuarioViewModel(string nome, string login, string email, string departamento, bool partialViewMinimizada)
        {
            Nome = string.IsNullOrEmpty(nome) ? "--" : nome.ToUpper();
            Login = string.IsNullOrEmpty(login) ? "--" : login.ToUpper();
            Email = string.IsNullOrEmpty(email) ? "--" : email.ToUpper();
            Departamento = string.IsNullOrEmpty(departamento) ? "--" : departamento.ToUpper();
            PartialViewMinimizada = partialViewMinimizada;
        }
    }
}
