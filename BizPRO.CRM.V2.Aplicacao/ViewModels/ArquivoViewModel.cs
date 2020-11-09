using System;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ArquivoViewModel
    {
        public long Id { get; set; }
        public string Caminho { get; set; }
        public string Nome { get; set; }
        public long Tamanho { get; set; }
        public string Extensao { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPor { get; set; }

        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public ArquivoViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
    }
}
