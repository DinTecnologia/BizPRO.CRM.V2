using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Acesso
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public Acesso()
        {
            ValidationResult = new ValidationResult();
        }

        public Acesso(string userId)
        {
            UserId = userId;
            Token = Guid.NewGuid().ToString();
            CriadoEm = DateTime.Now;
        }

        public static bool IsValid()
        {
            return true;
        }
    }
}