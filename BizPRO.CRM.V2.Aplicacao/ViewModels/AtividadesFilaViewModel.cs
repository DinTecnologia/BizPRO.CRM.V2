using System;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AtividadesFilaViewModel
    {
        public int FilaId { get; set; }
        public string FilaNome { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string StatusIds { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public string AssuntoAtividade { get; set; }

        public AtividadesFilaViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }

        public AtividadesFilaViewModel(int filaId, string filaNome)
        {
            FilaId = filaId;
            FilaNome = filaNome;
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
    }
}
