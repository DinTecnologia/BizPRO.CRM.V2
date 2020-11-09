using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IAspNetClaimRepositorio : IRepositorio<AspNetClaim>
    {
        IEnumerable<AspNetClaim> ObterTodosProc();
    }
}

