using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class RelatorioAppServico : AppServicoDapper, IRelatorioAppServico
    {
        private readonly IRelatorioServico _servicoRelatorio;
        private readonly IStatusEntidadeServico _servicoStatusEntidade;
        private readonly IUsuarioServico _servicoUsuario;
        private readonly ICanalAppServico _canalAppServico;
        private readonly IMidiaAppServico _midiaAppServico;
        private readonly IStatusEntidadeAppServico _statusEntidadeAppServico;

        public RelatorioAppServico(IRelatorioServico servicoRelatorio, IStatusEntidadeServico servicoStatusEntidade,
            IUsuarioServico servicoUsuario,
            ICanalAppServico canalAppServico, IMidiaAppServico midiaAppServico,
            IStatusEntidadeAppServico statusEntidadeAppServico)
        {
            _servicoRelatorio = servicoRelatorio;
            _servicoStatusEntidade = servicoStatusEntidade;
            _servicoUsuario = servicoUsuario;
            _canalAppServico = canalAppServico;
            _midiaAppServico = midiaAppServico;
            _statusEntidadeAppServico = statusEntidadeAppServico;
        }

        public IEnumerable<Relatorio> HistoricoCronologia(DateTime? dtInicio, DateTime? dtFim)
        {
            return _servicoRelatorio.HistoricoCronologia(dtInicio, dtFim);
        }

        public IEnumerable<Relatorio> RelatorioAtendimento(DateTime? dtInicio, DateTime? dtFim)
        {
            return _servicoRelatorio.RelatorioAtendimento(dtInicio, dtFim);
        }

        public IEnumerable<Relatorio> RelatorioOcorrencia(DateTime? dtInicio, DateTime? dtFim)
        {
            return _servicoRelatorio.RelatorioOcorrencia(dtInicio, dtFim);
        }

        public IEnumerable<Relatorio> RelatorioLigacoes(DateTime? dtInicio, DateTime? dtFim)
        {
            return _servicoRelatorio.RelatorioLigacoes(dtInicio, dtFim);
        }

        public IEnumerable<Relatorio> RelatorioLigacoesStatus(DateTime? dtInicio, DateTime? dtFim)
        {
            return _servicoRelatorio.RelatorioLigacoesStatus(dtInicio, dtFim);
        }

        public IEnumerable<Relatorio> RelatorioRateio(DateTime? dtInicio, DateTime? dtFim)
        {
            return _servicoRelatorio.RelatorioRateio(dtInicio, dtFim);
        }

        public IEnumerable<Relatorio> RelatorioLigacoesOperadorStatus(DateTime? dtInicio, DateTime? dtFim,
            string usuarioId)
        {
            return _servicoRelatorio.RelatorioLigacoesOperadorStatus(dtInicio, dtFim, usuarioId);
        }

        public IEnumerable<Relatorio> RelatorioVendasStatus(DateTime? dtInicio, DateTime? dtFim, string usuarioId,
            int? status)
        {
            return _servicoRelatorio.RelatorioVendasStatus(dtInicio, dtFim, usuarioId, status);
        }

        public IEnumerable<Usuario> CarregarUsuariosVendas()
        {
            return _servicoUsuario.CarregarUsuariosVendas();
        }

        public IEnumerable<Usuario> CarregarUsuariosLigacoes()
        {
            return _servicoUsuario.CarregarUsuariosLigacoes();
        }

        public IEnumerable<StatusEntidade> CarregarStatus()
        {

            return _servicoStatusEntidade.ObterStatusEntidadeVendas();
        }

        public IEnumerable<Relatorio> RelatorioOcorrenciaConsolidada(DateTime? dtInicio, DateTime? dtFim,
            string usuarioId, long? status, long? tipoPai)
        {
            return _servicoRelatorio.RelatorioOcorrenciaConsolidada(dtInicio, dtFim, usuarioId, status, tipoPai);
        }

        public IEnumerable<Usuario> ObterUsuariosOcorrencia()
        {
            return _servicoUsuario.ObterUsuariosOcorrencia();
        }

        public IEnumerable<Relatorio> ObterDadosRelatorioConsolidadoContatos(
            RelatorioFiltrosSelecionadosViewModel filtro)
        {
            long? pessoaFisicaId = null;
            long? pessoaJuridicaId = null;
            long? potencialClienteId = null;

            //Sentando o propiedade correta conforme o tipo de cliente
            if (string.IsNullOrEmpty(filtro.Sentido))
                return _servicoRelatorio.ConsolidadoContatos(filtro.AtividadeTipoID, filtro.DataInicial,
                    filtro.DataFinal,
                    filtro.StatusAtividadeID, filtro.UsuarioID, filtro.Sentido, pessoaFisicaId, pessoaJuridicaId,
                    potencialClienteId);
            switch (filtro.Sentido.ToLower())
            {
                case "pf":
                    pessoaFisicaId = filtro.ClienteID;
                    break;
                case "pj":
                    pessoaJuridicaId = filtro.ClienteID;
                    break;
                case "pc":
                    potencialClienteId = filtro.ClienteID;
                    break;
            }

            return _servicoRelatorio.ConsolidadoContatos(filtro.AtividadeTipoID, filtro.DataInicial, filtro.DataFinal,
                filtro.StatusAtividadeID, filtro.UsuarioID, filtro.Sentido, pessoaFisicaId, pessoaJuridicaId,
                potencialClienteId);
        }

        public RelatorioViewModel CarregarDados()
        {
            var vm = new RelatorioViewModel();
            var inicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var fim = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            vm.ListaUsuarios = ObterUsuariosOcorrencia();
            vm.StatusEntidade = _statusEntidadeAppServico.CarregarStatusOcorrencia();
            vm.ListarCanais = _canalAppServico.ListarCanais();
            vm.ListarMidias = _midiaAppServico.ListarMidias();
            vm.dataInicio = inicio.ToString("dd/MM/yyyy");
            vm.dataFim = fim.ToString("dd/MM/yyyy");
            return vm;
        }
    }
}
