using DomainValidation.Validation;


namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class RoleClaim
    {
        public long id { get; set; }
        public string roleID { get; set; }
        public string claimID { get; set; }
        public string claimType { get; set; }
        public string claimValue { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public RoleClaim()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
