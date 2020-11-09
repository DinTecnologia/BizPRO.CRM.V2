using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AdicionarEnderecoProdutoViewModel
    {
        public long? ContratoID { get; set; }
        public long? OcorrenciaID { get; set; }
        public int? LocalID { get; set; }
        public int? LocaisTiposAtendimentoID { get; set; }
        public long? PessoaFisicaID { get; set; }
        public long? PessoaJuridicaID { get; set; }        
        public string EnderecoID { get; set; }        
        public long? SegmentoID { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [MaxLength(100,ErrorMessage="Favor informar no máximo 100 caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe o CEP")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Informe o Logradouro")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o Número")]
        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Informe o Bairro")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Selecione a Cidade")]
        public int? CidadeId { get; set; }

        [Required(ErrorMessage = "Selecione a Estado")]
        public int? UfId { get; set; }

        public SelectList Cidades { get; set; }
        public SelectList Estados { get; set; }

        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public AdicionarEnderecoProdutoViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
        public AdicionarEnderecoProdutoViewModel(IEnumerable<Cidade> estados)
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            Estados = new SelectList(estados, "id", "uf");
            Cidades = new SelectList(new List<Cliente>(), "id", "nome");
        }
    }
}
