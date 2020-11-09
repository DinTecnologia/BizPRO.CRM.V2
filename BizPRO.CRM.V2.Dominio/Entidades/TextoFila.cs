using DomainValidation.Validation;
using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class TextoFila
    {
        public long Id { get; set; }

        public long TextoId { get; set; }

        public int FilaId { get; set; }

        public string CriadoPor { get; set; }

        public DateTime CriadoEm { get; set; }

        public string AtualizadoPor { get; set; }

        public DateTime? AtualizadoEm { get; set; }

        public bool Ativo { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public TextoFila()
        {
            CriadoEm = DateTime.MaxValue;
            ValidationResult = new ValidationResult();
        }
    }
}
