using System;
using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Canal
    {
        public int Id { get; set; }
        public string Nome { get; set; }        
        public DateTime CriadoEm { get; set; }
        public string CriadoPorAspNetUserId { get; set; }
        public ValidationResult ValidationResult { get; private set; }
        public virtual ICollection<Atendimento> Atendimentos { get; set; }
        public Canal()
        {
            CriadoEm = DateTime.Now;
            ValidationResult = new ValidationResult();
        }
    }
}
