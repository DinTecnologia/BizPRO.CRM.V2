using System.Collections.Generic;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IEquipeAppServico
    {
        IEnumerable<EquipeViewModel> ObterEquipes();
        EquipeViewModel ObterPorId(int id);
        bool Adicionar(EquipeViewModel model);
        bool Atualizar(EquipeViewModel model);
    }
}