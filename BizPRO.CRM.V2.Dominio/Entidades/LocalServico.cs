using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class LocalServico
    {
        public int Id { get; set; }
        public int LocaisId { get; set; }
        public int ServicosId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public LocalServico()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
