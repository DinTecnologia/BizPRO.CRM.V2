using System.Collections.Generic;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IAnotacaoAppServico
    {
        AnotacaoFormViewModel Adicionar(long? ocorrenciaId, long? atividadeId, long? pessoaFisicaId,
            long? pessoaJuridicaId, long? potenciaisClienteId, long? atendimentoId);

        AnotacaoFormViewModel Salvar(AnotacaoFormViewModel viewModel);

        IEnumerable<AnotacoesViewForm> ObterPor(long? ocorrenciaId, long? atividadeId, long? pessoaFisicaId,
            long? pessoaJuridicaId, long? potenciaisClienteId);

        AnotacaoFormViewModel CarregarAdicionarAnotacao(long? ocorrenciaId, long? atividadeId);

        bool OcorrenciaFinalizada(long ocorrenciaId);
    }
}
