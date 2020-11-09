using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ProdutoTipo
    {
        public int id { get; private set; }
        public string nome { get; set; }
        public DateTime criadoEm { get; set; }
        public string criadoPorUserID { get; set; }
        public bool ativo { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public ProdutoTipo()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
