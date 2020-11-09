using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IStatusEntidadeAppServico
    {
        statusEntidadeViewModal CarregarStatusOcorrencia();
        statusEntidadeViewModal CarregarStatusVendas();
        StatusEntidadeAlterarViewModel CarregarAlterarStatus(long? ocorrenciaId);
        StatusEntidadeAlterarViewModel CarregarAlterarStatusTroca(long? ocorrenciaId);
        StatusEntidadeAlterarViewModel SalvarAlterarStatus(StatusEntidadeAlterarViewModel viewModel, string userId);
        StatusEntidadeAlterarViewModel AxaCarregarAlterarStatusLojista(long? ocorrenciaId);
    }
}
