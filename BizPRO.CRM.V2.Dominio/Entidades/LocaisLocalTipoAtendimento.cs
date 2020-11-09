using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class LocaisLocalTipoAtendimento
    {
        public int Id { get; private set; }
        public int LocaisTiposAtendimentoId { get; set; }
        public int LocaisId { get; set; }
        
        public ValidationResult ValidationResult { get; private set; }

        public LocaisLocalTipoAtendimento()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
