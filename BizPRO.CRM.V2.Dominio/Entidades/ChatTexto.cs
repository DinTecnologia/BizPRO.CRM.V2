using DomainValidation.Validation;
using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ChatTexto
    {
        public long Id { get; set; }
        public int? FilaId { get; set; }
        public long TipoTextoEntidadeCampoValorId { get; set; }
        public string Texto { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPor { get; set; }
        public ValidationResult ValidationResult { get; set; }

        
        
        
        public ChatTexto()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
