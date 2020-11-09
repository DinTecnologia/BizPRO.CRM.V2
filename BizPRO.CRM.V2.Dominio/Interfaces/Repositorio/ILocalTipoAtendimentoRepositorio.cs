using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface ILocalTipoAtendimentoRepositorio : IRepositorio<LocalTipoAtendimento>
    {
        IEnumerable<LocalTipoAtendimento> ObterLocalTiposAtendimentoPorLocalId(long localId);
    }
}
