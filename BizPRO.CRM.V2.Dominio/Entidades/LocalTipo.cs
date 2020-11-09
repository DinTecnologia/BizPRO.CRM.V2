using System;
using DomainValidation.Validation;


namespace BizPRO.CRM.V2.Dominio.Entidades
{   
    public class LocalTipo
    {
        public long Id { get; private set; }
        public string Nome { get; set; }
        public string CriadoPorUserId { get; set; }
        public DateTime CriadoEm { get; set; }
        public string AlteradoPorUserId { get; set; }
        public DateTime AlteradoEm { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public LocalTipo()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
