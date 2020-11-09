using DomainValidation.Validation;
using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CriadoPorUserId { get; set; }
        public DateTime CriadoEm { get; set; }
        public string AlteradoPorUserId { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public Servico()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
