using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class TerminaisUsuario
    {
        public long Id { get; set; }
        public long? NumeroTerminal { get; set; }
        public long? Agente { get; set; }
        public bool AtivarScreenPopUp { get; set; }
        public string UserId { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }
        public DateTime AlteradoEm { get; set; }
        public string AlteradoPorUserId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public TerminaisUsuario()
        {
            ValidationResult = new ValidationResult();
        }

        public TerminaisUsuario(long? numeroTerminal, long? agente, string userId, string criadoPorUserId,
            string alteradoPorUserId)
        {
            ValidationResult = new ValidationResult();
            NumeroTerminal = numeroTerminal;
            Agente = agente;
            UserId = userId;
            CriadoPorUserId = criadoPorUserId;
            AlteradoPorUserId = alteradoPorUserId;
            CriadoEm = DateTime.Now;
            AtivarScreenPopUp = false;
            AlteradoEm = DateTime.Now;
        }
    }
}
