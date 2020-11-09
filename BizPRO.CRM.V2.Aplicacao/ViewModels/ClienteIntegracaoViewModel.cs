using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ClienteIntegracaoViewModel
    {
        public long IdentificadorIntegracao { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public ClienteIntegracaoViewModel()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
