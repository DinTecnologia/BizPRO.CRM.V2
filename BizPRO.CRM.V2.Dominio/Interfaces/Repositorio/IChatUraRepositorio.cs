using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IChatUraRepositorio : IRepositorio<ChatUra>
    {
        IEnumerable<ChatUra> ObterUnificado(long? atividadeId, long? chatUraId, int? ordem);
    }
}
