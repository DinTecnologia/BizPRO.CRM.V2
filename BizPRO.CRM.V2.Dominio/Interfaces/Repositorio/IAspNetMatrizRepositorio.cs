using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IAspNetMatrizRepositorio : IRepositorio<AspNetMatriz>
    {
        IEnumerable<AspNetMatriz> ObterPor(string claimId, string sentido);
    }
}
