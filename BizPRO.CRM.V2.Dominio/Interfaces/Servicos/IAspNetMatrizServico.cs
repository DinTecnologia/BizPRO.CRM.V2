using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IAspNetMatrizServico
    {
        IEnumerable<AspNetMatriz> ObterPor(string sentido);
        IEnumerable<AspNetMatriz> ObterPor(string claimId, string sentido);
    }
}
