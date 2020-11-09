using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IDashboardRepositorio : IRepositorio<Dashboard>
    {
        IEnumerable<Dashboard> ObterDaFila(int? filaId, DateTime? dataInicio, DateTime? dataFim, string userId,
            int? departamentoId);

        IEnumerable<Dashboard> ObterChat(int? filaId);
    }
}
