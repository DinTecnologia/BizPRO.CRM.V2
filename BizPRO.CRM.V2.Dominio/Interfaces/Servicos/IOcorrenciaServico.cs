using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using System.Data;
using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IOcorrenciaServico
    {
        ValidationResult Adicionar(Ocorrencia ocorrencia);
        ValidationResult Atualizar(Ocorrencia ocorrencia);
        Ocorrencia ObterPorId(long ocorrenciaId);
        Ocorrencia ObterOcorrenciaCompletaPorId(long ocorrenciaId);
        IEnumerable<Ocorrencia> Obter(Ocorrencia entidade);
        IEnumerable<Ocorrencia> ObterOcorrenciasLocalPorUserId(string userId);
        IEnumerable<Ocorrencia> ObterOcorrenciasPorProtocolo(string protocolo);

        DataSet SelectDinamicoExportacaoOcorrencia(string campos, string userId, DateTime? inicio, DateTime? fim,
            string status, string cliente, long? ocorrenciaTipoId);

        IEnumerable<Ocorrencia> ObterOcorrenciasLocal(string userId, string protocolo, string cliente,
            long? ocorrenciaTipoId, string documento);

        IEnumerable<Ocorrencia> ObterOcorrenciasLojista(string userId, string protocolo, string documento);

        IEnumerable<Ocorrencia> BuscarOcorrenciasCliente(long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potencialClienteId);

        ValidationResult AtualizarResponsavel(long ocorrenciaId, string responsavelId, string atualizadoPorId);

        DataSet ObterOcorrenciaExportar(string campos, string usuarioId, DateTime? dataInicio, DateTime? dataFim,
            string statusIds,
            string cliente, long? ocorrenciaTipoId, string camposDinamicosOcorrenciaId, string camposDinamicosContratoId);

        IEnumerable<Ocorrencia> ObterOcorrenciasOriginal(string cliente, string protocolo, long? pessoaJuridicaId,
            long? pessoaFisicaId, long? ocorrenciaId);

        bool OcorrenciaFinalizada(long ocorrenciaId);

        void CorrigirOcorrenciasPrevisaoInicial();

        ValidationResult AtualizarMotivoOcorrencia(long ocorrenciaId, long ocorrenciaTipoId, string usuarioId);

        ValidationResult AtualizarContratoOcorrencia(long ocorrenciaId, long contratoId, string usuarioId);

    }
}