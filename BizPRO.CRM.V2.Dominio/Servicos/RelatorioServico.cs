using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Linq.Expressions;
using Dapper;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class RelatorioServico : Servico<Relatorio>, IRelatorioServico
    {
        private readonly IRelatorioRepositorio _repositorio;
        private DynamicParameters _parametros = null;

        public RelatorioServico(IRelatorioRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }
        public IEnumerable<Relatorio> RelatorioRateio(DateTime? Dt_Inicio, DateTime? Dt_Fim)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@dataInicioPeriodo", Dt_Inicio);
            _parametros.Add("@dataFimPeriodo", Dt_Fim);
            return _repositorio.ObterPorProcedimento("usp_rpt_Rateio_Departamento", _parametros);
        }
        public IEnumerable<Relatorio> HistoricoCronologia(DateTime? Dt_Inicio, DateTime? Dt_Fim)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@dataInicioPeriodo", Dt_Inicio);
            _parametros.Add("@dataFimPeriodo", Dt_Fim);
            return _repositorio.ObterPorProcedimento("usp_rpt_atendimentoCronologia", _parametros);
        }
        public IEnumerable<Relatorio> RelatorioAtendimento(DateTime? Dt_Inicio, DateTime? Dt_Fim)
        {
            var retorno = new List<Relatorio>();
            _parametros = new DynamicParameters();
            _parametros.Add("@dataInicioPeriodo", Dt_Inicio);
            _parametros.Add("@dataFimPeriodo", Dt_Fim);
            return _repositorio.ObterPorProcedimento("usp_rpt_tabuladorAtendimento", _parametros);
        }
        public IEnumerable<Relatorio> RelatorioOcorrencia(DateTime? Dt_Inicio, DateTime? Dt_Fim)
        {
            var retorno = new List<Relatorio>();
            _parametros = new DynamicParameters();
            _parametros.Add("@dataInicioPeriodo", Dt_Inicio);
            _parametros.Add("@dataFimPeriodo", Dt_Fim);
            return _repositorio.ObterPorProcedimento("usp_rpt_Ocorrencias", _parametros);
        }
        public IEnumerable<Relatorio> RelatorioLigacoes(DateTime? Dt_Inicio, DateTime? Dt_Fim)
        {
            var retorno = new List<Relatorio>();
            _parametros = new DynamicParameters();
            _parametros.Add("@dataInicioPeriodo", Dt_Inicio);
            _parametros.Add("@dataFimPeriodo", Dt_Fim);
            return _repositorio.ObterPorProcedimento("usp_rpt_Ligacoes", _parametros);
        }
        public Relatorio Adicionar(Relatorio obj)
        {
            throw new NotImplementedException();
        }
        public Relatorio ObterPorId(long id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Relatorio> ObterTodos()
        {
            throw new NotImplementedException();
        }
        public Relatorio Atualizar(Relatorio obj)
        {
            throw new NotImplementedException();
        }
        public void Remover(long id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Relatorio> Buscar(Expression<Func<Relatorio, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
        public Relatorio ObterPorId(int id)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Relatorio> RelatorioLigacoesStatus(DateTime? Dt_Inicio, DateTime? Dt_Fim)
        {
            var retorno = new List<Relatorio>();
            _parametros = new DynamicParameters();
            _parametros.Add("@dataInicioPeriodo", Dt_Inicio);
            _parametros.Add("@dataFimPeriodo", Dt_Fim);
            return _repositorio.ObterPorProcedimento("usp_rpt_LigacoesXStatus", _parametros);
        }
        public IEnumerable<Relatorio> RelatorioLigacoesOperadorStatus(DateTime? Dt_Inicio, DateTime? Dt_Fim, string UsuarioID)
        {
            var retorno = new List<Relatorio>();
            _parametros = new DynamicParameters();
            _parametros.Add("@dataInicioPeriodo", Dt_Inicio);
            _parametros.Add("@dataFimPeriodo", Dt_Fim);
            _parametros.Add("@UsuarioID", UsuarioID);
            return _repositorio.ObterPorProcedimento("usp_rpt_LigacoesXOperadorXStatus", _parametros);
        }
        public IEnumerable<Relatorio> RelatorioVendasStatus(DateTime? Dt_Inicio, DateTime? Dt_Fim, string UsuarioID, int? StatusID)
        {
            var retorno = new List<Relatorio>();
            _parametros = new DynamicParameters();
            _parametros.Add("@dataInicioPeriodo", Dt_Inicio);
            _parametros.Add("@dataFimPeriodo", Dt_Fim);
            _parametros.Add("@UsuarioID", UsuarioID);
            _parametros.Add("@Status", StatusID);
            return _repositorio.ObterPorProcedimento("usp_rpt_VendasXOperadorXStatus", _parametros);
        }
        public IEnumerable<Relatorio> RelatorioOcorrenciaConsolidada(DateTime? Dt_Inicio, DateTime? Dt_Fim, string UsuarioID, long? Status, long? TipoPai)
        {
            var retorno = new List<Relatorio>();
            _parametros = new DynamicParameters();
            _parametros.Add("@inicio", Dt_Inicio);
            _parametros.Add("@fim", Dt_Fim);
            _parametros.Add("@usuario", UsuarioID == "" ? null : UsuarioID);
            _parametros.Add("@status", Status);
            _parametros.Add("@TipoPai", TipoPai);
            return _repositorio.ObterPorProcedimento("usp_rpt_ocorrenciaConsolidada", _parametros);
        }
        public IEnumerable<Relatorio> ConsolidadoContatos(int? atividadeTipoID, DateTime? dataInicio, DateTime? dataFim, int? statusAtividadeID, string userID, string sentido, long? pessoaFisicaID, long? pessoaJuriciaID, long? potenciaisClienteID)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@atividadeTipoID", atividadeTipoID);

            if (dataInicio != null && dataInicio != DateTime.MinValue)
                _parametros.Add("@dataInicial", dataInicio);

            if (dataFim != null && dataFim != DateTime.MinValue)
                _parametros.Add("@dataFinal", dataFim);

            _parametros.Add("@statusAtividadeID", statusAtividadeID);
            _parametros.Add("@userID", userID);
            _parametros.Add("@sentido", sentido);
            _parametros.Add("@pessoaFisicaID", pessoaFisicaID);
            _parametros.Add("@pessoaJuridicaID", pessoaJuriciaID);
            _parametros.Add("@potenciaisClienteID", potenciaisClienteID);
            return _repositorio.ObterPorProcedimento("usp_rpt_ConsolidadoContatos", _parametros);
        }
        public IEnumerable<Relatorio> RelatorioContatoDetalhado(DateTime? Dt_Inicio, DateTime? Dt_Fim, string UsuarioID, long? Status, long? PessoaFisicaID, long? PessoaJuridicaID, long? CanalID, long? MidiaID, string Sentido)
        {
            var retorno = new List<Relatorio>();
            _parametros = new DynamicParameters();
            _parametros.Add("@inicio", Dt_Inicio);
            _parametros.Add("@fim", Dt_Fim);
            _parametros.Add("@usuario", UsuarioID == "" ? null : UsuarioID);
            _parametros.Add("@status", Status);
            _parametros.Add("@PessoaFisicaID", PessoaFisicaID);
            _parametros.Add("@PessoaJuridicaID", PessoaJuridicaID);
            _parametros.Add("@canalID", CanalID);
            _parametros.Add("@midiaID", MidiaID);
            _parametros.Add("@sentido", Sentido == "" ? null : Sentido);
            //parametros.Add("@TipoPai", TipoPai);
            return _repositorio.ObterPorProcedimento("usp_rpt_contatoDetalhado", _parametros);
        }
        public IEnumerable<Relatorio> RelatorioContatoDetalhado(DateTime? Dt_Inicio, DateTime? Dt_Fim, string UsuarioID, long? Status, long? TipoPai)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Relatorio> RelatorioContatoDetalhado(DateTime? Dt_Inicio, DateTime? Dt_Fim, string UsuarioID, long? Status, long? PessoaFisicaID, long? PessoaJuridicaID)
        {
            throw new NotImplementedException();
        }
    }
}
