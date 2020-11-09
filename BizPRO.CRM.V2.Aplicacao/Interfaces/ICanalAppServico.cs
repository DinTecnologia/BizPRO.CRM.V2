using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface ICanalAppServico
    {

        IEnumerable<CanalViewModel> ListarCanais();
        long ObterCanalPorNome(string nome);
    }
}
 