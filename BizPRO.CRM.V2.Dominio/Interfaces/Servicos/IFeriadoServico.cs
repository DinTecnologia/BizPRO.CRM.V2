using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IFeriadoServico
    {
        IEnumerable<Feriado> ObterTodos();
    }
}
