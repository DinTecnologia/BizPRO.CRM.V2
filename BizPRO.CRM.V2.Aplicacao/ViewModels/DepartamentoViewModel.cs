using System;
using System.ComponentModel.DataAnnotations;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class DepartamentoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public DepartamentoViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
    }
}
