using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ConfiguracoesViewModel
    {
        [Key]
        public long id { get; set; }
        [DisplayName("Sigla")]
        public string sigla { get; set; }
        [DisplayName("Descrição")]
        public string descricao { get; set; }
        [DisplayName("Valor da Configuração")]
        public string valor { get; set; }
        public DateTime criadoEm { get; set; }
        public string criadoPorUserID { get; set; }
        public DateTime? alteradoEm { get; set; }
        public string alteradoPorUserID { get; set; }
        [DisplayName("Ativo")]
        public bool ativo { get; set; }
        public bool padraoProduto { get; set; }
        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public ConfiguracoesViewModel() { ValidationResult = new DomainValidation.Validation.ValidationResult(); }

    }
}
