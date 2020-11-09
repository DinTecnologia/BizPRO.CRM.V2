using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Data;
using Dapper;
using System.Linq;
using DomainValidation.Validation;
using System;
using BizPRO.CRM.V2.Dominio.Enums;
using BizPRO.CRM.V2.Core.Comum;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class OcorrenciaServico : Servico<Ocorrencia>, IOcorrenciaServico
    {
        private readonly IOcorrenciaRepositorio _repositorio;
        private readonly ICamposDinamicosRepositorio _repositorioTest;
        private readonly IOcorrenciaTipoServico _servicoOcorrenciaTipo;
        private readonly IStatusEntidadeServico _servicoStatusEntidade;
        private readonly IUsuarioServico _servicoUsuario;
        private readonly IFeriadoServico _feriadoServico;


        public OcorrenciaServico(IOcorrenciaRepositorio repositorio, ICamposDinamicosRepositorio repositorioTest,
            IOcorrenciaTipoServico servicoOcorrenciaTipo, IStatusEntidadeServico servicoStatusEntidade,
            IUsuarioServico servicoUsuario, IFeriadoServico feriadoServico)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _repositorioTest = repositorioTest;
            _servicoOcorrenciaTipo = servicoOcorrenciaTipo;
            _servicoStatusEntidade = servicoStatusEntidade;
            _servicoUsuario = servicoUsuario;
            _feriadoServico = feriadoServico;
        }

        public IEnumerable<Ocorrencia> Obter(Ocorrencia entidade)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@pessoaFisicaID", entidade.PessoaFisicaId ?? (long?) null);
            parametros.Add("@pessoaJuridicaID", entidade.PessoaFisicaId ?? (long?) null);
            parametros.Add("@ocorrenciaTiposID",
                entidade.OcorrenciasTiposId > 0 ? entidade.OcorrenciasTiposId : (long?) null);
            parametros.Add("@contratoID", entidade.ContratoId ?? (long?) null);
            return
                _repositorio.ObterPorProcedimento("usp_front_sel_ocorrencias", parametros)
                    .OrderByDescending(c => c.CriadoEm);
        }

        public IEnumerable<Ocorrencia> ObterOcorrenciasLocalPorUserId(string userId)
        {
            return _repositorio.ObterOcorrenciasLocalPorUserId(userId);
        }

        public IEnumerable<Ocorrencia> ObterOcorrenciasLocal(string userId, string protocolo, string cliente,
            long? ocorrenciaTipoId, string documento)
        {
            return _repositorio.ObterOcorrenciasLocalPorObjetos(userId, protocolo, cliente, ocorrenciaTipoId,
                documento);
        }

        public IEnumerable<Ocorrencia> ObterOcorrenciasPorProtocolo(string protocolo)
        {
            if (!string.IsNullOrEmpty(protocolo))
                return _repositorio.ObterOcorrenciasPorProtocolo(protocolo);
            else
                return null;
        }

        public DataSet SelectDinamicoExportacaoOcorrencia(string campos, string userId, DateTime? inicio, DateTime? fim,
            string status, string cliente, long? ocorrenciaTipoId)
        {
            var list = _repositorioTest.ProcessoTabelaDinamica(campos, userId, inicio, fim, status, cliente,
                ocorrenciaTipoId);
            return list;
        }

        public Ocorrencia ObterOcorrenciaCompletaPorId(long ocorrenciaId)
        {
            var ocorrencia = new Ocorrencia();
            ocorrencia = _repositorio.ObterPorId(ocorrenciaId);

            if (ocorrencia != null)
            {
                ocorrencia.OcorrenciaTipo = _servicoOcorrenciaTipo.ObterPorId(ocorrencia.OcorrenciasTiposId);
                ocorrencia.StatusEntidade = _servicoStatusEntidade.ObterPorId(ocorrencia.StatusEntidadesId);

                if (!string.IsNullOrEmpty(ocorrencia.ResponsavelPorAspNetUserId))
                    ocorrencia.Responsavel = _servicoUsuario.ObterPorUserId(ocorrencia.ResponsavelPorAspNetUserId);
            }

            return ocorrencia;
        }

        public Ocorrencia ObterPorId(long ocorrenciaId)
        {
            return _repositorio.ObterPorId(ocorrenciaId);
        }

        public ValidationResult Atualizar(Ocorrencia ocorrencia)
        {
            return Atualizar(ocorrencia, null);
        }

        public ValidationResult Adicionar(Ocorrencia ocorrencia)
        {
            return Adicionar(ocorrencia, null);
        }

        public IEnumerable<Ocorrencia> ObterOcorrenciasLojista(string userId, string protocolo, string documento)
        {
            return _repositorio.ObterOcorrenciasLojista(userId, protocolo, documento);
        }

        public IEnumerable<Ocorrencia> BuscarOcorrenciasCliente(long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potencialClienteId)
        {
            return _repositorio.BuscarOcorrenciasCliente(pessoaFisicaId, pessoaJuridicaId, potencialClienteId);
        }

        public ValidationResult AtualizarResponsavel(long ocorrenciaId, string responsavelId, string atualizadoPorId)
        {
            var retorno = new ValidationResult();
            var ocorrencia = _repositorio.ObterPorId(ocorrenciaId);

            if (ocorrencia == null)
            {
                retorno.Add(new ValidationError("Nenhuma Ocorrência retornada com o Id: " + ocorrenciaId));
                return retorno;
            }

            ocorrencia.AtualizadoEm = DateTime.Now;
            ocorrencia.AtualizadoPorAspNetUserId = atualizadoPorId;
            ocorrencia.ResponsavelPorAspNetUserId = responsavelId;

            if (!_repositorio.Atualizar(ocorrencia))
                retorno.Add(new ValidationError("Problema ao atualizar a Ocorrência"));

            return retorno;
        }

        protected ValidationResult GerarTimelineOcorrencia(string usuarioId, TipoTimelineEnum tipoTimeline,
            long ocorrenciaId)
        {
            var retorno = new ValidationResult();

            //Implementar o mecanismo aqui

            return retorno;
        }

        public DataSet ObterOcorrenciaExportar(string campos, string usuarioId, DateTime? dataInicio, DateTime? dataFim,
            string statusIds, string cliente, long? ocorrenciaTipoId, string camposDinamicosOcorrenciaId,
            string camposDinamicosContratoId)
        {
            return _repositorioTest.ObterOcorrenciasExportar(campos, usuarioId, dataInicio, dataFim, statusIds,
                cliente,
                ocorrenciaTipoId, camposDinamicosOcorrenciaId, camposDinamicosContratoId);
        }

        public IEnumerable<Ocorrencia> ObterOcorrenciasOriginal(string cliente, string protocolo,
            long? pessoaJuridicaId,
            long? pessoaFisicaId, long? ocorrenciaId)
        {
            return _repositorio.ObterOcorrenciasOriginal(cliente, protocolo, pessoaJuridicaId, pessoaFisicaId,
                ocorrenciaId);
        }

        public bool OcorrenciaFinalizada(long ocorrenciaId)
        {
            return _repositorio.OcorrenciaFinalizada(ocorrenciaId);
        }

        public void CorrigirOcorrenciasPrevisaoInicial()
        {
            var ocorrencias = _repositorio.ObterOcorrenciasCorrecao();
            var feriados = _feriadoServico.ObterTodos().Where(x => x.Uf == null || x.Uf == "SP");

            var listaDatasFeriado =
                feriados.Select(
                        feriado =>
                            new DateTime(feriado.Ano <= 0 ? DateTime.Now.Year : feriado.Ano, feriado.Mes, feriado.Dia))
                    .ToList();

            if (ocorrencias.Any())
            {
                foreach (var ocorrencia in ocorrencias)
                {
                    var ocorrenciaTipo = ocorrencia.OcorrenciaTipo;
                    var previsaoInicial = Metodos.CalcularSla(ocorrenciaTipo.TempoPrevistoAtendimento,
                        listaDatasFeriado, !ocorrenciaTipo.TempoPrevistoCorrido, false, ocorrencia.CriadoEm);

                    ocorrencia.PrevisaoInicial = previsaoInicial;
                    _repositorio.Atualizar(ocorrencia);

                }
            }
        }

        public ValidationResult AtualizarMotivoOcorrencia(long ocorrenciaId, long ocorrenciaTipoId, string usuarioId)
        {
            return _repositorio.AtualizarMotivoOcorrencia(ocorrenciaId, ocorrenciaTipoId, usuarioId);
        }

        public ValidationResult AtualizarContratoOcorrencia(long ocorrenciaId, long contratoId, string usuarioId)
        {
            return _repositorio.AtualizarContratoOcorrencia(ocorrenciaId, contratoId, usuarioId);
        }
    }
}