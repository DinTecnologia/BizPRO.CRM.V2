using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class PessoaJuridicaTiposContatoAppServico : IPessoaJuridicaTiposContatoAppServico
    {
        private readonly IPessoaJuridicaTiposContatoServico _pessoaJuridicaTiposContatoServico;

        public PessoaJuridicaTiposContatoAppServico(IPessoaJuridicaTiposContatoServico pessoaJuridicaTiposContatoServico)
        {
            _pessoaJuridicaTiposContatoServico = pessoaJuridicaTiposContatoServico;
        }

        public PessoaJuridicaTiposContatoViewModel CarregarCombo()
        {
            var view = new PessoaJuridicaTiposContatoViewModel();
            var lista = new List<PessoaJuridicaTiposContatoViewModel>();

            var retorno = _pessoaJuridicaTiposContatoServico.Listar();

            foreach (var item in retorno)
            {
                lista.Add(new PessoaJuridicaTiposContatoViewModel(item.id, item.nome, item.ativo));
            }

            view.listarPessoaJuridicaTiposContato = lista;

            return view;
        }
    }
}
