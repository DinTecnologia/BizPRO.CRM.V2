using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IConfiguracaoContasEmailsAppServico
    {
        IEnumerable<ConfiguracoesContaEmailsViewModel> ObterTodos();

        ConfiguracoesContaEmailsViewModel ObterPorId(int id);
    }
}