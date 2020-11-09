using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IPausaAppServico
    {
        PausaFormViewModel Carregar(string canalIds, string usuarioId);
        PausaFormViewModel Salvar(PausaFormViewModel viewModel);
    }
}
