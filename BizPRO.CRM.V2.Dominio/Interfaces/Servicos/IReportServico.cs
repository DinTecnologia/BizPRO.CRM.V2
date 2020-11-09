using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IReportServico
    {
        IEnumerable<Report> ObterDadosRelatorioConsolidadoContatos(int? atividadeTipoId, DateTime? dataInicio,
            DateTime? dataFim, int? statusAtividadeId, string userId, string sentido, long? pessoaFisicaId,
            long? pessoaJuriciaId, long? potenciaisClienteId, int? midiaId);

        IEnumerable<Report> ObterDadosRelatorioDetalheContato(int? atividadeTipoId, DateTime? dataInicio,
            DateTime? dataFim, int? statusAtividadeId, string criadoPor, string sentido, long? midiaId,
            long? pessoaFisicaId, long? pessoaJuriciaId, long? potenciaisClienteId);

        IEnumerable<Report> ObterDadosRelatorioDetalheOcorrencia(int? atividadeTipoId, DateTime? dataInicio,
            DateTime? dataFim, int? statusEntidadeId, string criadoPor, string sentido, long? midiaId,
            long? pessoaFisicaId, long? pessoaJuriciaId, long? potenciaisClienteId, long? ocorrenciaId,
            long? ocorrenciaTipoId, long? atividadeId, string acaoOcorrencia, long? atendimentoId);

        IEnumerable<Report> ObterDadosRelatorioConsolidadoFilaAtividade(long? filaId, DateTime? dataInicio,
            DateTime? dataFim);

        IEnumerable<Report> ObterDadosRelatorioDetalheAtividade(long? filaId, long? statusAtividadeId,
            DateTime? dataInicio, DateTime? dataFim);

        IEnumerable<Report> ObterDadosRelatorioCronologiaAtendimento(DateTime? dataInicio, DateTime? dataFim);
        IEnumerable<Report> ObterDadosRelatorioOcorrencia(DateTime? dataInicio, DateTime? dataFim);
        IEnumerable<Report> ObterDadosRelatorioLigacao(DateTime? dataInicio, DateTime? dataFim);

        IEnumerable<Report> ObterDadosRelatorioConsolidadoOcorrencia(DateTime? dataInicio, DateTime? dataFim,
            string criadoPor, int? statusAtividadeId, long? ocorrenciaTipoId);

        IEnumerable<Report> ObterDadosRelatorioAtendimento(DateTime? dataInicio, DateTime? dataFim);

        DataSet ObterDadosRelatorioFluxoDeAtendimento(DateTime? dataInicio, DateTime? dataFim,
            int? canalId, string ocorrenciaTipoEstrutura, int? statusEntidadeId, string sentido, string usuarioId);

        DataSet ObterDadosRelatorioFluxoDeAtendimentoProdutivo(DateTime? dataInicio, DateTime? dataFim,
            int? canalId, string ocorrenciaTipoEstrutura, int? statusEntidadeId, string sentido, string usuarioId);
    }
}
