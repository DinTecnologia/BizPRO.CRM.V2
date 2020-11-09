using DomainValidation.Validation;
using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Midia
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int? CanaisId { get; set; }
        public string CriadoPorAspNetUserId { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public Midia()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
