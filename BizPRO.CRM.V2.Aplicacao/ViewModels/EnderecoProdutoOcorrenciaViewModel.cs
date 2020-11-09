using System.ComponentModel.DataAnnotations;


namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class EnderecoProdutoOcorrenciaViewModel
    {
        [Key]
        public long? Id { get; set; }

        public long? OcorrenciasId { get; set; }
        public int? LocaisId { get; set; }
        public int? LocaisTiposAtendimentoId { get; set; }

        [Required(ErrorMessage = "Informe o Logradouro")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o Número")]
        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Informe o Bairro")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Selecione a Cidade")]        
        [Display(Name = "Cidade")]
        public int? CidadesId { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public EnderecoProdutoOcorrenciaViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
    }
}
