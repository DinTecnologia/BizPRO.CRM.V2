using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IBaseAppServico
    {
        IEnumerable<MenuViewModel> ObterMenu(string usuarioId, string url);
        string ObterTitle();
        string ObterTitleMenu();
        string ObterScript(string nomeLogico);
    }
}
