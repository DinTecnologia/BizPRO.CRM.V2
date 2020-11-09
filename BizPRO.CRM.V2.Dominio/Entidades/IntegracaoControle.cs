using DomainValidation.Validation;
using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class IntegracaoControle
    {
        public long Id { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public long? ContratoId { get; set; }
        public long? TelefoneId { get; set; }
        public long IdentificadorIntegracao { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPor { get; set; }
        public DateTime? UltimaAtualizacaoEm { get; set; }
        public bool Ativo { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public IntegracaoControle()
        {
            ValidationResult = new ValidationResult();
            CriadoEm = DateTime.Now;
            UltimaAtualizacaoEm = DateTime.Now;
            Ativo = true;
        }
    }
}
