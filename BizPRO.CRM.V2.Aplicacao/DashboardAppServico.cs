using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class DashboardAppServico : IDashboardAppServico
    {
        private readonly IDashboardServico _servicoDashboard;
        private readonly IFilaServico _servicoFila;
        private readonly IDepartamentoServico _departamentoServico;

        public DashboardAppServico(IDashboardServico servicoDashboard, IFilaServico servicoFila, IDepartamentoServico departamentoServico)
        {
            _servicoDashboard = servicoDashboard;
            _servicoFila = servicoFila;
            _departamentoServico = departamentoServico;
        }

        public DashboardFilaViewModel CarregarDashboardFila(int? filaId, DateTime? dataInicio, DateTime? dataFim,
            string userId, int? departamentoId)
        {
            var filas = _servicoFila.ObterPor(departamentoId, userId);
            var dashboard = _servicoDashboard.ObterDaFila(filaId, dataInicio, dataFim, userId, departamentoId);
            var departamentos = _departamentoServico.ObterPorUsuario(userId);
            return new DashboardFilaViewModel(filas, filaId, dashboard, dataInicio, dataFim, departamentos,
                departamentoId);
        }

        public DashboardFilaViewModel CarregarFila(int? filaId, string userId, int? departamentoId)
        {
            var filas = _servicoFila.ObterPor(departamentoId, userId);
            var dashboard = _servicoDashboard.ObterDaFila(filaId, DateTime.Now, null, userId, departamentoId);
            var departamentos = _departamentoServico.ObterPorUsuario(userId);
            return new DashboardFilaViewModel(filas, filaId, dashboard, DateTime.Now, null, departamentos,
                departamentoId);
        }


        public DashboardChatViewModel CarregarDashboardChat(int? filaId)
        {
            var retorno = new DashboardChatViewModel();
            var dashboard = _servicoDashboard.ObterChat(filaId);

            if (dashboard == null)
            {
                retorno.ValidationResult.Add(new ValidationError("Nenhum Dashboard Retornado."));
                return retorno;
            }

            retorno.Dashboard = dashboard;
            return retorno;
        }
    }
}

