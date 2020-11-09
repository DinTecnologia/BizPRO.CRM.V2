using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;


namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IPessoaFisicaAppServico
    {
        PessoaFisicaFormViewModel Salvar(PessoaFisicaFormViewModel model, string usuarioId);
        PessoaFisicaFormViewModel Carregar(bool atender);

        IEnumerable<PessoaFisica> PesquisarPessoaFisica(string nome, string documento, string telefone,
            long? pessoaFisicaId, string protocolo);

        PessoaFisicaFormViewModel PessoaFisicaPorId(long pessoaFisicaId);
        PessoaFisicaFormViewModel Atualizar(PessoaFisicaFormViewModel model, string userId);

        //long AdicionarClienteIntegracao(PessoaFisica model);
    }
}
