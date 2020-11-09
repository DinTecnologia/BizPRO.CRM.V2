using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class AspNetMatriz
    {
        public long Id { get; set; }
        public string Sentido { get; set; }
        public string Valor { get; set; }
        public string Texto { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public AspNetMatriz()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
