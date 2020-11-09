using System.Collections.Generic;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IDepartamentoAppServico
    {
        IEnumerable<DepartamentoViewModel> ObterDepartamentos();
        DepartamentoViewModel ObterPorId(int id);
        bool Adicionar(DepartamentoViewModel model);
        bool Atualizar(DepartamentoViewModel model);
    }
}