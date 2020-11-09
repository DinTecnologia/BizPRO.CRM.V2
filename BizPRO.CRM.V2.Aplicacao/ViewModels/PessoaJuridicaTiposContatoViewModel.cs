using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class PessoaJuridicaTiposContatoViewModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }
        public DateTime criadoEm { get; set; }
        public string criadoPorUserID { get; set; }
        public bool padrao { get; set; }

        public List<PessoaJuridicaTiposContatoViewModel> listarPessoaJuridicaTiposContato { get; set; }

        public PessoaJuridicaTiposContatoViewModel(int id , string nome ,bool ativo )
        {
            this.id = id ;
            this.nome=nome;
            this.ativo = ativo ;
        }
        public PessoaJuridicaTiposContatoViewModel()
        {

        }
    }
}
