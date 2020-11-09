using DomainValidation.Validation;
using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class EmailModelo
    {
        public long Id { get; set; }
        public string NomeDoModelo { get; set; }
        public string Html { get; set; }
        public bool Ativo { get; set; }
        public string CriadoPorAspNetUsersId { get; set; }
        public DateTime CriadoEm { get; set; }
        public string AlteradoPorAspNetUsersId { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public EmailModelo()
        {
            ValidationResult = new ValidationResult();
        }
        public void SetarNovaOcorrenciaLinkExterno()
        {
            NomeDoModelo = "NOVA_OCORRENCIA_LINK_ACESSO_EXTERNO";
        }
    }
}
