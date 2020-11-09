using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class TextoTipo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public TextoTipo()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
