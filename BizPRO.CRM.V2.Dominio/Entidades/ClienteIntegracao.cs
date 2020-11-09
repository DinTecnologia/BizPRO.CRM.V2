using System.Collections.Generic;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ClienteIntegracaoBusca
    {
        public List<PessoaFisica> PessoasFisicas { get; set; }
        public List<PessoaJuridica> PessoasJuridicas { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public ClienteIntegracaoBusca()
        {
            ValidationResult = new ValidationResult();
            PessoasJuridicas = new List<PessoaJuridica>();
            PessoasFisicas = new List<PessoaFisica>();
        }
    }
}
