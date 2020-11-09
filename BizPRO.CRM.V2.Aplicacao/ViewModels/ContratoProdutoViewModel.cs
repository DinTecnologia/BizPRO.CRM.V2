using System.Collections.Generic;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ContratoProdutoViewModel
    {
        public ContratoViewModel ContratoViewModel { get; set; }
        public ProdutoViewModel ProdutoViewModel { get; set; }
        public IEnumerable<ResultadoCamposDinamicosViewModel> ListaResultadoCamposDinamicosViewModel { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public ContratoProdutoViewModel(ProdutoViewModel produtoViewModel,
            IEnumerable<ResultadoCamposDinamicosViewModel> listaResultadoCamposDinamicosViewModel)
        {
            ProdutoViewModel = produtoViewModel;
            ListaResultadoCamposDinamicosViewModel = listaResultadoCamposDinamicosViewModel;
            ValidationResult = new ValidationResult();
        }

        public ContratoProdutoViewModel()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
