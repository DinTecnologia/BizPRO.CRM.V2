using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class AspNetRolesFila
    {
        public long Id { get; set; }
        public int FilasId { get; set; }
        public string AspNetRolesId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public AspNetRolesFila()
        {
            ValidationResult = new ValidationResult();
        }

        public AspNetRolesFila(int filasId, string aspNetRolesId)
        {
            FilasId = filasId;
            AspNetRolesId = aspNetRolesId;
        }
    }
}
