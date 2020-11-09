using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class PessoaJuridicaContato
    {
        public long id { get; set; }
        public long PessoasFisicasID { get; set; }
        public bool principal { get; set; }
        public int tiposContatoPessoaJuridicaID { get; set; }
        public DateTime criadoEm { get; set; }
        public string criadoPorUserID { get; set; }
        public DateTime? removidoEm { get; set; }
        public string removidoPorUserID { get; set; }
        public long PessoasJuridicasID { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }
        public PessoaJuridicaTiposContato PessoaJuridicaTiposContato { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public PessoaJuridicaContato()
        {
            ValidationResult = new ValidationResult();
        }
    }

}
