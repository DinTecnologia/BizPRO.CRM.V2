using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IDashboardAppServico
    {
        DashboardFilaViewModel CarregarFila(int? filaId, string userId, int? departamentoId);

        DashboardFilaViewModel CarregarDashboardFila(int? filaId, DateTime? dataInicio, DateTime? dataFim, string userId,
            int? departamentoId);

        DashboardChatViewModel CarregarDashboardChat(int? filaId);
    }
}
