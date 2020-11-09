using DomainValidation.Validation;
using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class PessoaJuridicaTiposContato
    {
        public int id { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }
        public DateTime criadoEm { get; set; }
        public string criadoPorUserID { get; set; }
        public bool padrao { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public PessoaJuridicaTiposContato()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
