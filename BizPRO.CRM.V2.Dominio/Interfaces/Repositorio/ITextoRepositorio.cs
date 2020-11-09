using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface ITextoRepositorio : IRepositorio<Texto>
    {
        IEnumerable<Texto> ObterPorFilaId(int? filaId);

        IEnumerable<Texto> FiltrarTexto(int? filaId, int? canalId, int? tipoId, int? formatoId);
        
    }
}
