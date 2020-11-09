using BizPRO.CRM.V2.Aplicacao.ViewModels.Admin;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IFilaAdminAppServico
    {
        FilaViewModel Index(string usuarioId);
        IEnumerable<FilaListViewModel> Pesquisar(FilaViewModel viewModel);
    }
}
