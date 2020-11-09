using BizPRO.CRM.V2.Aplicacao.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IAspNetRolesFilaAppServico
    {
        IEnumerable<AspNetRolesFilaApp> ObterPorFila(long id);
    }
}
