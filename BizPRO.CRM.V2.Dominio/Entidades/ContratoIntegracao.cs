using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ContratoIntegracao
    {
        public long ContratoIntegracaoId { get; set; }
        public string TipoProduto { get; set; }
        public string Parceiro { get; set; }
        public string Certificado { get; set; }
        public string Apolice { get; set; }
        public DateTime? InicioVigencia { get; set; }
        public DateTime? FimVigencia { get; set; }
        public decimal? Premio { get; set; }
        public string Lmi { get; set; }
        public string DataAdesao { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public string Produto { get; set; }
        public string PequenoPorte { get; set; }
        public string Marca { get; set; }
        public string Status { get; set; }

        public ContratoIntegracao()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
