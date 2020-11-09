using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Data;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ReportServico : Servico<Report>, IReportServico
    {
        private readonly IReportRepositorio _repositorio;
        private readonly IRelatorioRepositorioAdo _relatorioRepositorioAdo;

        public ReportServico(IReportRepositorio repositorio, IRelatorioRepositorioAdo relatorioRepositorioAdo)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _relatorioRepositorioAdo = relatorioRepositorioAdo;
        }

        public IEnumerable<Report> ObterDadosRelatorioConsolidadoContatos(int? atividadeTipoId, DateTime? dataInicio,
            DateTime? dataFim, int? statusAtividadeId, string userId, string sentido, long? pessoaFisicaId,
            long? pessoaJuriciaId, long? potenciaisClienteId, int? midiaId)
        {
            return _repositorio.ObterDadosRelatorioConsolidadoContatos(atividadeTipoId, dataInicio, dataFim,
                statusAtividadeId, userId, sentido, pessoaFisicaId, pessoaJuriciaId, potenciaisClienteId, midiaId);
        }

        public IEnumerable<Report> ObterDadosRelatorioDetalheContato(int? atividadeTipoId, DateTime? dataInicio,
            DateTime? dataFim, int? statusAtividadeId, string criadoPor, string sentido, long? midiaId,
            long? pessoaFisicaId, long? pessoaJuriciaId, long? potenciaisClienteId)
        {
            return _repositorio.ObterDadosRelatorioDetalheContato(atividadeTipoId, dataInicio, dataFim,
                statusAtividadeId, criadoPor, sentido, midiaId, pessoaFisicaId, pessoaJuriciaId, potenciaisClienteId);
        }

        public IEnumerable<Report> ObterDadosRelatorioDetalheOcorrencia(int? atividadeTipoId, DateTime? dataInicio,
            DateTime? dataFim, int? statusEntidadeId, string criadoPor, string sentido, long? midiaId,
            long? pessoaFisicaId, long? pessoaJuriciaId, long? potenciaisClienteId, long? ocorrenciaId,
            long? ocorrenciaTipoId, long? atividadeId, string acaoOcorrencia, long? atendimentoId)
        {
            return _repositorio.ObterDadosRelatorioDetalheOcorrencia(atividadeTipoId, dataInicio, dataFim,
                statusEntidadeId, criadoPor, sentido, midiaId, pessoaFisicaId, pessoaJuriciaId, potenciaisClienteId,
                ocorrenciaId, ocorrenciaTipoId, atividadeId, acaoOcorrencia, atendimentoId);
        }

        public IEnumerable<Report> ObterDadosRelatorioConsolidadoFilaAtividade(long? filaId, DateTime? dataInicio,
            DateTime? dataFim)
        {
            return _repositorio.ObterDadosRelatorioConsolidadoFilaAtividade(filaId, dataInicio, dataFim);
        }

        public IEnumerable<Report> ObterDadosRelatorioDetalheAtividade(long? filaId, long? statusAtividadeId)
        {
            return _repositorio.ObterDadosRelatorioDetalheAtividade(filaId, statusAtividadeId);
        }

        public IEnumerable<Report> ObterDadosRelatorioDetalheAtividade(long? filaId, long? statusAtividadeId,
            DateTime? dataInicio, DateTime? dataFim)
        {
            return _repositorio.ObterDadosRelatorioDetalheAtividade(filaId, statusAtividadeId, dataInicio, dataFim);
        }

        public IEnumerable<Report> ObterDadosRelatorioCronologiaAtendimento(DateTime? dataInicio, DateTime? dataFim)
        {
            return _repositorio.ObterDadosRelatorioCronologiaAtendimento(dataInicio, dataFim);
        }

        public IEnumerable<Report> ObterDadosRelatorioOcorrencia(DateTime? dataInicio, DateTime? dataFim)
        {
            return _repositorio.ObterDadosRelatorioOcorrencia(dataInicio, dataFim);
        }

        public IEnumerable<Report> ObterDadosRelatorioLigacao(DateTime? dataInicio, DateTime? dataFim)
        {
            return _repositorio.ObterDadosRelatorioLigacao(dataInicio, dataFim);
        }

        public IEnumerable<Report> ObterDadosRelatorioConsolidadoOcorrencia(DateTime? dataInicio, DateTime? dataFim,
            string criadoPor, int? statusAtividadeId, long? ocorrenciaTipoId)
        {
            return _repositorio.ObterDadosRelatorioConsolidadoOcorrencia(dataInicio, dataFim, criadoPor,
                statusAtividadeId, ocorrenciaTipoId);
        }

        public IEnumerable<Report> ObterDadosRelatorioAtendimento(DateTime? dataInicio, DateTime? dataFim)
        {
            return _repositorio.ObterDadosRelatorioAtendimento(dataInicio, dataFim);
        }


        DataSet IReportServico.ObterDadosRelatorioFluxoDeAtendimento(DateTime? dataInicio, DateTime? dataFim,
            int? canalId, string ocorrenciaTipoEstrutura, int? statusEntidadeId, string sentido, string usuarioId)
        {
            return _relatorioRepositorioAdo.ObterDadosRelatorioFluxoDeAtendimento(dataInicio, dataFim, canalId,
                ocorrenciaTipoEstrutura, statusEntidadeId, sentido, usuarioId);
        }

        DataSet IReportServico.ObterDadosRelatorioFluxoDeAtendimentoProdutivo(DateTime? dataInicio, DateTime? dataFim,
            int? canalId, string ocorrenciaTipoEstrutura, int? statusEntidadeId, string sentido, string usuarioId)
        {
            return _relatorioRepositorioAdo.ObterDadosRelatorioFluxoDeAtendimentoProdutivo(dataInicio, dataFim, canalId,
                ocorrenciaTipoEstrutura, statusEntidadeId, sentido, usuarioId);
        }
    }
}
