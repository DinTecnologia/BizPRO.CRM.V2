using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ResultadoCamposDinamicosViewModel
    {

        public long id { get; set; }
        public string nome { get; set; }
        public IEnumerable<ResultadoCamposDinamicosViewModel> Lista { get; set; }

        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public ResultadoCamposDinamicosViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
        public ResultadoCamposDinamicosViewModel(long id, string nome, IEnumerable<ResultadoCamposDinamicosViewModel> Lista)
        {
            this.id = id;
            this.nome = nome;
            this.Lista = Lista;
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
        public ResultadoCamposDinamicosViewModel(long id, string nome)
        {
            this.id = id;
            this.nome = nome;
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
    }
}
