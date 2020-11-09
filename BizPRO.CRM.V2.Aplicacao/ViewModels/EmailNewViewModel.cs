using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class EmailNewViewModel
    {
        public long? PessoaFisicaId { get; set; }
        public long PessoaJuridicaId { get; set; }
        public long FilaId { get; set; }
        public long? OcorrenciaId { get; set; }
        public bool RetornarPartial { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public EmailNewViewModel()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
