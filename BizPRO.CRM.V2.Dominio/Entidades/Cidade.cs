using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public Cidade()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
