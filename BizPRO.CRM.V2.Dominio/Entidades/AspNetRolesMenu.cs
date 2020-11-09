using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class AspNetRolesMenu
    {
        public long Id { get; set; }
        public string AspNetRolesId { get; set; }
        public int MenusId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public AspNetRolesMenu()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
