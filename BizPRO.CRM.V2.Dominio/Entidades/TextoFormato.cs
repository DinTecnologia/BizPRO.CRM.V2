using DomainValidation.Validation;
using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class TextoFormato
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime CriadoEm { get; set; }

        public string CriadoPor { get; set; }

        public DateTime? AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; }

        public bool Ativo { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public TextoFormato()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
