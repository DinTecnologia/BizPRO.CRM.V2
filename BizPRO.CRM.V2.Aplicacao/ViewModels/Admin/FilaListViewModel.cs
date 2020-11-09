using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels.Admin
{
    public class FilaListViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CriadoEm { get; set; }
        public string CriadoPor { get; set; }
        public string AlteradoEm { get; set; }
        public string AlteradoPor { get; set; }
        public string ContaDisparo { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public FilaListViewModel(int id, string nome, DateTime criadoEm, string criadoPor, DateTime? alteradoEm, string alteradoPor, string contaDisparo)
        {
            Id = id;
            Nome = nome;
            CriadoEm = criadoEm.ToString("dd/MM/yyyy hh:mm");
            AlteradoEm = alteradoEm.HasValue ? alteradoEm.Value.ToString("dd/MM/yyyy hh:mm") : "--";
            AlteradoPor = alteradoPor;
            ContaDisparo = string.IsNullOrEmpty(contaDisparo) ? "--" : contaDisparo;
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
    }
}
