using System.Collections.Generic;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IMenuAppServico
    {
        IEnumerable<MenuViewModel> Carregar(string userId, string url);
        IEnumerable<MenuViewModel> CarregarAdministracao();
        MenuAdminFormViewModel Create();
        void CreateAdd(MenuAdminFormViewModel model);
        void EditarAdd(MenuAdminFormViewModel model);
        MenuAdminFormViewModel Editar(int id);
    }
}
