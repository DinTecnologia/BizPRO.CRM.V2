using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IPessoaJuridicaAppServico
    {
        PessoaJuridicaFormViewModel Carregar(bool atender);
        PessoaJuridicaFormViewModel Salvar(PessoaJuridicaFormViewModel model, string usuarioId);
        IEnumerable<Cidade> ObterCidadesPorUf(string uf);
        PessoaJuridicaFormViewModel PessoaJuridicaPorId(long pessoaJuridicaId);
        PessoaJuridicaFormViewModel Atualizar(PessoaJuridicaFormViewModel model, string userId);

        IEnumerable<PessoaJuridica> PesquisarPessoaJuridica(string razaoSocial, string documento, string telefone,
            long? pessoaJuridicaId, string protocolo);

        SelectList ObterPor(long? tipoId, string letraBusca);
    }
}
