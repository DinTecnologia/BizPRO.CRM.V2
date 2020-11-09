using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IAbordagemAppServico
    {
        AbordagemViewModel Carregar(AbordagemViewModel viewModel);
    }
}
