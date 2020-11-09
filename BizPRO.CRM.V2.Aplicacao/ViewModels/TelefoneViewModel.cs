using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class TelefoneViewModel
    {
        public long? ID { get; set; }
        public long? PessoaFisicaID { get; set; }
        public long? PessoaJuridicaID { get; set; }
        [Required(ErrorMessage = "Preencha o Numero de Telefone")]
        public long? numero { get; set; }
        [Required(ErrorMessage = "Preencha o DDD")]
        public int? DDD { get; set; }
        public int? TelefonesTiposID { get; set; }
        public string tipo { get; set; }
        public bool ativo { get; set; }
        public long? PotenciaisClientesID { get; set; }

        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public TelefoneViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
        public TelefoneViewModel(long? PessoaFisicaID, long? PessoaJuridicaID, long? PotenciaisClientesID )
        {
            this.PessoaFisicaID = PessoaFisicaID;
            this.PessoaJuridicaID = PessoaJuridicaID;
            this.PotenciaisClientesID = PotenciaisClientesID;
            ValidationResult = new DomainValidation.Validation.ValidationResult();

        }
        public TelefoneViewModel(long? ID, long? PessoaFisicaID, long? PessoaJuridicaID, int? DDD, long? numero, string tipo, int? TelefonesTiposID, long? PotenciaisClientesID)
        {
            this.ID = ID;
            this.PessoaFisicaID = PessoaFisicaID;
            this.PessoaJuridicaID = PessoaJuridicaID;
            this.DDD = DDD;
            this.numero = numero;
            this.tipo = tipo;
            this.TelefonesTiposID = TelefonesTiposID;
            this.PotenciaisClientesID = PotenciaisClientesID;
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
    }
}
