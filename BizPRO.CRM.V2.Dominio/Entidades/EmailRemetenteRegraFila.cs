using System;
using DomainValidation.Validation;


namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class EmailRemetenteRegra
    {
        public long Id { get; set; }

        public string Remetente { get; set; }

        public long StatusAtividadeId { get; set; }

        public DateTime CriadoEm { get; set; }

        public string CriadoPor { get; set; }

        public DateTime AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; }

        public bool Ativo { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public long? FilaId { get; set; }

        public EmailRemetenteRegra()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
