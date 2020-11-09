using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface ITextoFilaRepositorio : IRepositorio<TextoFila>
    {
        IEnumerable<TextoFila> ObterPorTextoId(long id);

        void DeletarTodosAtivo(long textoId, string usuarioId);        
    }
}
