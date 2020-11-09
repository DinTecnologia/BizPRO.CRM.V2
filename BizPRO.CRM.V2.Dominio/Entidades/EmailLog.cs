using DomainValidation.Validation;
using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class EmailLog
    {
        public long Id { get; private set; }
        public long EmailsId { get; private set; }
        public string Texto { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public ValidationResult ValidationResult { get; private set; }

        public EmailLog()
        {
            ValidationResult = new ValidationResult();
        }
        public EmailLog(long emailsId, string texto)
        {
            EmailsId = emailsId;
            Texto = texto;
            CriadoEm = DateTime.Now;
            ValidationResult = new ValidationResult();
        }
    }
}
