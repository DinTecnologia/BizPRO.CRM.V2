using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Aplicacao
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public bool Ssl { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public Aplicacao()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
