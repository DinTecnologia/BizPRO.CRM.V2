using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class DashboardServico : IDashboardServico
    {
        private readonly IDashboardRepositorio _repositorio;

        public DashboardServico(IDashboardRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Entidades.Dashboard> ObterDaFila(int? filaId, DateTime? dataInicio, DateTime? dataFim,
            string userId, int? departamentoId)
        {
            return _repositorio.ObterDaFila(filaId, dataInicio, dataFim, userId, departamentoId);
        }

        public IEnumerable<Entidades.Dashboard> ObterChat(int? filaId)
        {
            return _repositorio.ObterChat(filaId);
        }
    }
}
