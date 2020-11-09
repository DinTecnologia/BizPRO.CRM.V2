using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface ITextoFilaServico : IServico<TextoFila>
    {
        IEnumerable<TextoFila> ObterPorTextoId(long id);        

        void DeletarTodosAtivo(long textoId, string usuarioId);

    }
}
