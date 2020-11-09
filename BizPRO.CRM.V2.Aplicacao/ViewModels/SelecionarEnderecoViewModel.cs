using System.Web.Mvc;
using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class SelecionarEnderecoViewModel
    {
        public long? ContratoID { get; set; }
        public long? OcorrenciaID { get; set; }
        public long? PessoaFisicaID { get; set; }
        public long? PessoaJuridicaID { get; set; }
        public string EnderecoID { get; set; }


        public SelectList ListaEnderecos { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public SelecionarEnderecoViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
        public SelecionarEnderecoViewModel(long? ocorrenciaID, long? pessoaFisicaID, long? pessoaJuridicaID, IEnumerable<Endereco> enderecos, long? contratoID)
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            this.OcorrenciaID = ocorrenciaID;
            this.PessoaFisicaID = pessoaFisicaID;
            this.PessoaJuridicaID = PessoaJuridicaID;
            ListaEnderecos = new SelectList(enderecos, "valorCombo", "enderecoCompleto");
            this.ContratoID = contratoID;
        }
    }
}
