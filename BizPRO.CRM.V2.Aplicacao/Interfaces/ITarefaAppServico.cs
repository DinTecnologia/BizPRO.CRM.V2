using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface ITarefaAppServico
    {
        TarefaViewModel SalvarAnotacao(string anotacao, string userId, long atividadeId);
        TarefaViewModel CarregarTela(string userId, long atividadeId);
        TarefaViewModel CarregarTarefa(string userId, long atividadeId);

        TarefaFormViewModel CarregarAdicionar(long? ocorrenciaId, long? atividadeDeOrigemId, long? pessoaFisicaId,
            long? pessoaJuridicaId, long? potencialClienteId, long? atendimentoId);

        TarefaFormViewModel Salvar(TarefaFormViewModel viewModel, string userId);
    }
}
