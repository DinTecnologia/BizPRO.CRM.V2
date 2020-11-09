using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface ITextoServico : IServico<Texto>
    {
        IEnumerable<Texto> ObterPorFilaId(int? filaId);

        IEnumerable<Texto> FiltrarPor(int? filaId, int? canalId, int? tipoId, int? formatoId);
    }
}
