using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class ReportRepositorio : Repositorio<Report>, IReportRepositorio
    {
        private DynamicParameters _parametros;
        public IDbConnection _conn { get; set; }

        public ReportRepositorio(IDapperContexto context)
            : base(context)
        {
            _conn = context.Connection;
        }

        public IEnumerable<Report> ObterDadosRelatorioConsolidadoContatos(int? atividadeTipoId, DateTime? dataInicio,
            DateTime? dataFim, int? statusAtividadeId, string userId, string sentido, long? pessoaFisicaId,
            long? pessoaJuriciaId, long? potenciaisClienteId, int? midiaId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@atividadeTipoID", atividadeTipoId);

            if (dataInicio != null && dataInicio != DateTime.MinValue)
                _parametros.Add("@dataInicio", dataInicio);

            if (dataFim != null && dataFim != DateTime.MinValue)
                _parametros.Add("@dataFim", dataFim);

            _parametros.Add("@statusAtividadeID", statusAtividadeId);

            if (!String.IsNullOrEmpty(userId))
                _parametros.Add("@userID", userId);

            if (!String.IsNullOrEmpty(sentido))
                _parametros.Add("@sentido", sentido);

            _parametros.Add("@pessoaFisicaID", pessoaFisicaId);
            _parametros.Add("@pessoaJuridicaID", pessoaJuriciaId);
            _parametros.Add("@potenciaisClienteID", potenciaisClienteId);
            _parametros.Add("@midiaID", midiaId);

            return ObterPorProcedimento("usp_rpt_ConsolidadoContato", _parametros);
        }

        public IEnumerable<Report> ObterDadosRelatorioDetalheContato(int? atividadeTipoId, DateTime? dataInicio,
            DateTime? dataFim, int? statusAtividadeId, string criadoPor, string sentido, long? midiaId,
            long? pessoaFisicaId, long? pessoaJuriciaId, long? potenciaisClienteId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@atividadeTipoID", atividadeTipoId);

            if (dataInicio != null && dataInicio != DateTime.MinValue)
                _parametros.Add("@dataInicio", dataInicio);

            if (dataFim != null && dataFim != DateTime.MinValue)
                _parametros.Add("@dataFim", dataFim);

            _parametros.Add("@statusAtividadeID", statusAtividadeId);

            if (!String.IsNullOrEmpty(criadoPor))
                _parametros.Add("@criadoPor", criadoPor);

            if (!String.IsNullOrEmpty(sentido))
                _parametros.Add("@sentido", sentido);

            _parametros.Add("@midiaID", midiaId);
            _parametros.Add("@pessoaFisicaID", pessoaFisicaId);
            _parametros.Add("@pessoaJuridicaID", pessoaJuriciaId);
            _parametros.Add("@potenciaisClienteID", potenciaisClienteId);

            return ObterPorProcedimento("usp_rpt_DetalheContato", _parametros);
        }

        public IEnumerable<Report> ObterDadosRelatorioDetalheOcorrencia(int? atividadeTipoId, DateTime? dataInicio,
            DateTime? dataFim, int? statusEntidadeId, string criadoPor, string sentido, long? midiaId,
            long? pessoaFisicaId, long? pessoaJuriciaId, long? potenciaisClienteId, long? ocorrenciaId,
            long? ocorrenciaTipoId, long? atividadeId, string acaoOcorrencia, long? atendimentoId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@atividadeTipoID", atividadeTipoId);

            if (dataInicio != null && dataInicio != DateTime.MinValue)
                _parametros.Add("@dataInicio", dataInicio);

            if (dataFim != null && dataFim != DateTime.MinValue)
                _parametros.Add("@dataFim", dataFim);

            _parametros.Add("@statusEntidadeID", statusEntidadeId);

            if (!String.IsNullOrEmpty(criadoPor))
                _parametros.Add("@criadoPor", criadoPor);

            if (!String.IsNullOrEmpty(sentido))
                _parametros.Add("@sentido", sentido);

            if (!String.IsNullOrEmpty(acaoOcorrencia))
                _parametros.Add("@acaoOcorrencia", acaoOcorrencia);

            _parametros.Add("@midiaID", midiaId);
            _parametros.Add("@pessoaFisicaID", pessoaFisicaId);
            _parametros.Add("@pessoaJuridicaID", pessoaJuriciaId);
            _parametros.Add("@potenciaisClienteID", potenciaisClienteId);
            _parametros.Add("@ocorrenciaId", ocorrenciaId);
            _parametros.Add("@ocorrenciaTipoID", ocorrenciaTipoId);
            _parametros.Add("@atividadeID", atividadeId);
            _parametros.Add("@atendimentoID", atendimentoId);

            return ObterPorProcedimento("usp_rpt_DetalheOcorrencia", _parametros);
        }

        public IEnumerable<Report> ObterDadosRelatorioConsolidadoFilaAtividade(long? filaId, DateTime? dataInicio,
            DateTime? dataFim)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@filaID", filaId);
            if (dataInicio != null && dataInicio != DateTime.MinValue)
                _parametros.Add("@dataInicio", dataInicio);

            if (dataFim != null && dataFim != DateTime.MinValue)
                _parametros.Add("@dataFim", dataFim);
            return ObterPorProcedimento("usp_rpt_ConsolidadoFilaAtividade", _parametros);
        }

        public IEnumerable<Report> ObterDadosRelatorioDetalheAtividade(long? filaId, long? statusAtividadeId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@filaID", filaId);
            _parametros.Add("@statusAtividadeID", statusAtividadeId);
            return ObterPorProcedimento("usp_rpt_DetalheAtividade", _parametros);
        }

        public IEnumerable<Report> ObterDadosRelatorioDetalheAtividade(long? filaId, long? statusAtividadeId,
            DateTime? dataInicio, DateTime? dataFim)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@filaID", filaId);
            _parametros.Add("@statusAtividadeID", statusAtividadeId);

            if (dataInicio != null && dataInicio != DateTime.MinValue)
                _parametros.Add("@dataInicio", dataInicio);

            if (dataFim != null && dataFim != DateTime.MinValue)
                _parametros.Add("@dataFim", dataFim);

            return ObterPorProcedimento("usp_rpt_DetalheAtividade", _parametros);
        }

        public IEnumerable<Report> ObterDadosRelatorioCronologiaAtendimento(DateTime? dataInicio, DateTime? dataFim)
        {
            _parametros = new DynamicParameters();

            if (dataInicio != null && dataInicio != DateTime.MinValue)
                _parametros.Add("@dataInicioPeriodo", dataInicio);

            if (dataFim != null && dataFim != DateTime.MinValue)
                _parametros.Add("@dataFimPeriodo", dataFim);

            return ObterPorProcedimento("usp_rpt_atendimentoCronologia", _parametros);
        }

        public IEnumerable<Report> ObterDadosRelatorioOcorrencia(DateTime? dataInicio, DateTime? dataFim)
        {
            _parametros = new DynamicParameters();

            if (dataInicio.HasValue)
                _parametros.Add("@dataInicioPeriodo", dataInicio);

            if (dataFim.HasValue)
                _parametros.Add("@dataFimPeriodo", dataFim);

            return ObterPorProcedimento("usp_rpt_Ocorrencias", _parametros);
        }

        public IEnumerable<Report> ObterDadosRelatorioLigacao(DateTime? dataInicio, DateTime? dataFim)
        {
            _parametros = new DynamicParameters();

            if (dataInicio.HasValue)
                _parametros.Add("@dataInicioPeriodo", dataInicio);

            if (dataFim.HasValue)
                _parametros.Add("@dataFimPeriodo", dataFim);

            return ObterPorProcedimento("usp_rpt_Ligacoes", _parametros);
        }

        public IEnumerable<Report> ObterDadosRelatorioConsolidadoOcorrencia(DateTime? dataInicio, DateTime? dataFim,
            string criadoPor, int? statusAtividadeId, long? ocorrenciaTipoId)
        {
            _parametros = new DynamicParameters();

            if (dataInicio.HasValue)
                _parametros.Add("@inicio", dataInicio);

            if (dataFim.HasValue)
                _parametros.Add("@fim", dataFim);

            if (!string.IsNullOrEmpty(criadoPor))
                _parametros.Add("@usuario", criadoPor == "" ? null : criadoPor);

            if (statusAtividadeId.HasValue)
                _parametros.Add("@status", statusAtividadeId);

            if (ocorrenciaTipoId.HasValue)
                _parametros.Add("@TipoPai", ocorrenciaTipoId);

            return ObterPorProcedimento("usp_rpt_ocorrenciaConsolidada", _parametros);
        }

        public IEnumerable<Report> ObterDadosRelatorioAtendimento(DateTime? dataInicio, DateTime? dataFim)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@dataInicioPeriodo", dataInicio);
            _parametros.Add("@dataFimPeriodo", dataFim);
            return ObterPorProcedimento("usp_rpt_tabuladorAtendimento", _parametros);
        }

        public IEnumerable<Report> ObterDadosRelatorioFluxoDeAtendimento(DateTime? dataInicio, DateTime? dataFim,
            int? canalId, string ocorrenciaTipoEstrutura, int? statusEntidadeId, string sentido, string usuarioId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@Atendimento_dataInicioPesquisa", dataInicio);
            _parametros.Add("@Atendimento_dataFinalPesquisa", dataFim);
            _parametros.Add("@Atendimento_canalID", canalId);
            _parametros.Add("@Ocorrencia_ocorrenciasTiposEstrutura", ocorrenciaTipoEstrutura);
            _parametros.Add("@Ocorrencia_statusEntidade", statusEntidadeId);
            _parametros.Add("@Atendimento_sentido", sentido);
            _parametros.Add("@Atendimento_Usuario", usuarioId);
            return ObterPorProcedimento("USP_REPORT_OBTER_ATENDIMENTOS_OCORRENCIA", _parametros);
        }

        public IEnumerable<dynamic> ObterDadosRelatorioFluxoDeAtendimentoDinamico(DateTime? dataInicio,
            DateTime? dataFim,
            int? canalId, string ocorrenciaTipoEstrutura, int? statusEntidadeId, string sentido, string usuarioId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@Atendimento_dataInicioPesquisa", dataInicio);
            _parametros.Add("@Atendimento_dataFinalPesquisa", dataFim);
            _parametros.Add("@Atendimento_canalID", canalId);
            _parametros.Add("@Ocorrencia_ocorrenciasTiposEstrutura", ocorrenciaTipoEstrutura);
            _parametros.Add("@Ocorrencia_statusEntidade", statusEntidadeId);
            _parametros.Add("@Atendimento_sentido", sentido);
            _parametros.Add("@Atendimento_Usuario", usuarioId);
            //return ObterPorProcedimentoDinamico("USP_REPORT_OBTER_ATENDIMENTOS_OCORRENCIA", _parametros);


            return
                _conn.Query("USP_REPORT_OBTER_ATENDIMENTOS_OCORRENCIA", _parametros,
                        commandType: CommandType.StoredProcedure)
                    .Select(x => (ExpandoObject) ToExpandoObject(x));
        }

        public IEnumerable<Report> ObterDadosRelatorioFluxoDeAtendimentoProdutiva(DateTime? dataInicio,
            DateTime? dataFim, int? canalId, string ocorrenciaTipoEstrutura, int? statusEntidadeId, string sentido,
            string usuarioId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@Atendimento_dataInicioPesquisa", dataInicio);
            _parametros.Add("@Atendimento_dataFinalPesquisa", dataFim);
            _parametros.Add("@Atendimento_canalID", canalId);
            _parametros.Add("@Ocorrencia_ocorrenciasTiposEstrutura", ocorrenciaTipoEstrutura);
            _parametros.Add("@Ocorrencia_statusEntidade", statusEntidadeId);
            _parametros.Add("@Atendimento_sentido", sentido);
            _parametros.Add("@Atendimento_Usuario", usuarioId);
            return ObterPorProcedimento("USP_REPORT_OBTER_ATENDIMENTOS_OCORRENCIA", _parametros);
        }

        public IEnumerable<dynamic> ObterDadosRelatorioFluxoDeAtendimentoProdutivaDinamico(DateTime? dataInicio,
           DateTime? dataFim, int? canalId, string ocorrenciaTipoEstrutura, int? statusEntidadeId, string sentido,
           string usuarioId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@Atendimento_dataInicioPesquisa", dataInicio);
            _parametros.Add("@Atendimento_dataFinalPesquisa", dataFim);
            _parametros.Add("@Atendimento_canalID", canalId);
            _parametros.Add("@Ocorrencia_ocorrenciasTiposEstrutura", ocorrenciaTipoEstrutura);
            _parametros.Add("@Ocorrencia_statusEntidade", statusEntidadeId);
            _parametros.Add("@Atendimento_sentido", sentido);
            _parametros.Add("@Atendimento_Usuario", usuarioId);
            return ObterPorProcedimentoDinamico("USP_REPORT_OBTER_ATENDIMENTOS_OCORRENCIA", _parametros);
        }

        public static dynamic ToExpandoObject(object value)
        {
            IDictionary<string, object> dapperRowProperties = value as IDictionary<string, object>;

            IDictionary<string, object> expando = new ExpandoObject();

            foreach (KeyValuePair<string, object> property in dapperRowProperties)
                expando.Add(property.Key, property.Value);

            return expando as ExpandoObject;
        }
    }
}
