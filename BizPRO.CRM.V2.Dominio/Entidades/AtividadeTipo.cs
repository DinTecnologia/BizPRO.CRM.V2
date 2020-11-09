using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class AtividadeTipo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }
        public bool EhDeContato { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public AtividadeTipo()
        {
            CriadoEm = DateTime.Now;
            ValidationResult = new ValidationResult();
        }
    }
}
