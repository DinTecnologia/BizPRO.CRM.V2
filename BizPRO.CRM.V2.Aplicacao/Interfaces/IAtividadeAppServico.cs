using System;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IAtividadeAppServico
    {
        AtividadeNewViewModel Carregar(string usuarioId, long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potencialClientesId, long? ocorrenciaId);

        AtividadeViewModel SalvarAtendimentoLigacao(AtividadeViewModel view);
        AtividadeViewModel CarregarAtividadeLigacao(AtividadeViewModel view, string usuarioId);
        AtividadeViewModel ObterPorId(long atividadeId);
        AtividadeNewViewModel SalvarAtividade(AtividadeNewViewModel model, string usuarioId);
        AtividadeNewViewModel Editar(long id, string usuarioId, bool linkFila);
        StatusAtividade ObterStatusAtividade(long id);
        long ObterAtividadeTipoPorNome(string nome);
        long ObterAtividadeStatusPorNome(string nome, string atividadeValida);
        IEnumerable<AtividadeListaViewModel> ObterPor(AtividadeFilterViewModel viewModel);

        IEnumerable<ContatoViewModel> ObterContatos(long? pessoaFisicaId, long? pessoaJuridicaId,
            int? quantidade);

        AtividadeViewModel AlteraDataPrevisaoAtividade(DateTime data, long atividadeId);


        //AtividadeNewViewModel Carregar(string usuarioId, long? pessoaFisicaId, long? pessoaJuridicaId,
        //    long? potencialClientesId, long? ocorrenciaId);

        //AtividadeViewModel SalvarAtendimentoLigacao(AtividadeViewModel view);
        //AtividadeViewModel CarregarAtividadeLigacao(AtividadeViewModel view, string usuarioId);
        ////AtividadeViewModel AtribuirCarregarMinhasAtividadesLigacao(long atividadeID, string UserID);
        //AtividadeViewModel ObterPorId(long atividadeId);
        //AtividadeNewViewModel SalvarAtividade(AtividadeNewViewModel model, string usuarioId);
        //AtividadeNewViewModel Editar(long id, string usuarioId, bool linkFila);
        //StatusAtividade ObterStatusAtividade(long id);
        //long ObterAtividadeTipoPorNome(string nome);
        //long ObterAtividadeStatusPorNome(string nome, string atividadeValida);
        //IEnumerable<AtividadeListaViewModel> ObterPor(AtividadeFilterViewModel viewModel);

        //IEnumerable<ContatoViewModel> ObterContatos(long? pessoaFisicaId, long? pessoaJuridicaId,
        //    int? quantidade);
    }
}