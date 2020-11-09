using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Funcionalidade
    {
        public long Id { get; private set; }
        public string Nome { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string PatternParametros { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public Funcionalidade()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
