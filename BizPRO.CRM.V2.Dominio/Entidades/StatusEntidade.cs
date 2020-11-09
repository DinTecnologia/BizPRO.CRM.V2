using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class StatusEntidade
    {
        public long id { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }
        public string entidadesValidas { get; set; }
        public bool padrao { get; set; }
        public bool finalizador { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public StatusEntidade()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
