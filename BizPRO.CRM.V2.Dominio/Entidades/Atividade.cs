using System;
using System.Collections.Generic;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Atividade
    {
        public long Id { get; private set; }
        public int? AtividadeTipoId { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }
        public string ResponsavelPorUserId { get; set; }
        public int StatusAtividadeId { get; set; }
        public long? OcorrenciaId { get; set; }
        public long? ContratoId { get; set; }
        public long? AtendimentoId { get; set; }
        public DateTime? PrevisaoDeExecucao { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public string FinalizadoPorUserId { get; set; }
        public string Titulo { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public AtividadeTipo AtividadeTipo { get; set; }
        public StatusAtividade StatusAtividade { get; set; }
        public string Descricao { get; set; }
        public Usuario Usuario { get; set; }
        public Usuario Responsavel { get; set; }
        public long? PessoasFisicasId { get; set; }
        public long? PessoasJuridicasId { get; set; }
        public long? PotenciaisClientesId { get; set; }
        public Email Email { get; set; }
        public Tarefa Tarefa { get; set; }
        public Ligacao Ligacao { get; set; }
        public int? CanaisId { get; set; }
        public int? MidiasId { get; set; }
        public DateTime? IniciadoEm { get; private set; }
        public string IniciadoPorUserId { get; private set; }
        public long? AtividadeDeOrigemId { get; set; }
        public IEnumerable<AtividadeParteEnvolvida> Envolvidos { get; set; }
        public IEnumerable<AtividadeFila> AtividadeFilas { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
        public Contrato Contrato { get; set; }
        public Atendimento Atendimento { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }
        public string UsuarioId { get; set; }
        public DateTime? ClienteFinalizouContatoEm { get; set; }
        public DateTime? AgenteFinalizouContatoEm { get; set; }

        public Atividade()
        {
            CriadoEm = DateTime.Now;
            ValidationResult = new ValidationResult();
            AtividadeTipo = new AtividadeTipo();
            StatusAtividade = new StatusAtividade();
            Envolvidos = new List<AtividadeParteEnvolvida>();
            AtividadeFilas = new List<AtividadeFila>();
        }

        public Atividade(string userId, int statusAtividadeId, int atividadeTipoId, string titulo, long? pessoaFisicaId,
            long? pessoaJuridicaId, long? potenciaisClientesId)
        {
            CriadoEm = DateTime.Now;
            ValidationResult = new ValidationResult();
            CriadoPorUserId = userId;
            ResponsavelPorUserId = userId;
            StatusAtividadeId = statusAtividadeId;
            AtividadeTipoId = atividadeTipoId;
            Titulo = titulo;
            PessoasFisicasId = pessoaFisicaId;
            PessoasJuridicasId = pessoaJuridicaId;
            PotenciaisClientesId = potenciaisClientesId;
            Envolvidos = new List<AtividadeParteEnvolvida>();
            AtividadeFilas = new List<AtividadeFila>();
        }

        public Atividade(long id, long? atendimentoId, DateTime? previsaoDeExecucao, string titulo, string descricao)
        {
            ValidationResult = new ValidationResult();
            Id = id;
            AtendimentoId = atendimentoId;
            PrevisaoDeExecucao = previsaoDeExecucao;
            Titulo = titulo;
            Descricao = descricao;
            Envolvidos = new List<AtividadeParteEnvolvida>();
            AtividadeFilas = new List<AtividadeFila>();
        }

        public Atividade
        (
            long id
            , int? atividadeTipoId
            , DateTime criadoEm
            , string criadoPorUserId
            , string responsavelPorUserId
            , int statusAtividadeId
            , long? ocorrenciaId
            , long? contratoId
            , long? atendimentoId
            , DateTime? previsaoDeExecucao
            , DateTime? finalizadoEm
            , string finalizadoPorUserId
            , string titulo
            , string descricao
            , long? pessoaFisicaId
            , long? pessoaJuridicaId
            , long? potenciaisClientesId
        )
        {
            ValidationResult = new ValidationResult();
            Id = id;
            AtividadeTipoId = atividadeTipoId;
            CriadoEm = criadoEm;
            CriadoPorUserId = criadoPorUserId;
            ResponsavelPorUserId = responsavelPorUserId;
            StatusAtividadeId = statusAtividadeId;
            OcorrenciaId = ocorrenciaId;
            ContratoId = contratoId;
            AtendimentoId = atendimentoId;
            PrevisaoDeExecucao = previsaoDeExecucao;
            FinalizadoEm = finalizadoEm;
            FinalizadoPorUserId = finalizadoPorUserId;
            Descricao = descricao;
            PessoasFisicasId = pessoaFisicaId;
            PessoasJuridicasId = pessoaJuridicaId;
            PotenciaisClientesId = potenciaisClientesId;
            Envolvidos = new List<AtividadeParteEnvolvida>();
            AtividadeFilas = new List<AtividadeFila>();
            Titulo = titulo;
        }

        public Atividade(string criadoPorUserId, int statusAtividadeId, int atividadeTipoId, string titulo,
            long? pessoaFisicaId, long? pessoaJuridicaId, long? potenciaisClientesId, long? ocorrenciaId,
            string descricao, long? atendimentoId, int? midiaId, IEnumerable<AtividadeParteEnvolvida> envolvidos,
            string responsavelPorUserId, long? atividadeDeOrigemId, DateTime? previsaoExecucao, int? canalId,
            string iniciadoPorUserId)
        {
            CriadoEm = DateTime.Now;
            ValidationResult = new ValidationResult();
            CriadoPorUserId = criadoPorUserId;
            ResponsavelPorUserId = criadoPorUserId;
            StatusAtividadeId = statusAtividadeId;
            AtividadeTipoId = atividadeTipoId;
            Titulo = titulo;
            PessoasFisicasId = pessoaFisicaId;
            PessoasJuridicasId = pessoaJuridicaId;
            PotenciaisClientesId = potenciaisClientesId;
            OcorrenciaId = ocorrenciaId;
            Descricao = descricao;
            Envolvidos = envolvidos ?? new List<AtividadeParteEnvolvida>();
            AtendimentoId = atendimentoId;
            MidiasId = midiaId;
            ResponsavelPorUserId = responsavelPorUserId;
            AtividadeDeOrigemId = atividadeDeOrigemId > 0 ? atividadeDeOrigemId : null;
            AtividadeFilas = new List<AtividadeFila>();
            PrevisaoDeExecucao = previsaoExecucao;
            CanaisId = canalId;
            IniciadoPorUserId = iniciadoPorUserId;
            IniciadoEm = string.IsNullOrEmpty(IniciadoPorUserId) ? (DateTime?) null : DateTime.Now;
        }

        public void IniciarAtividade(string userId)
        {
            IniciadoEm = DateTime.Now;
            IniciadoPorUserId = userId;
        }

        public void Finalizar(string userId, int? statusAtividadeId)
        {
            ResponsavelPorUserId = userId;
            FinalizadoPorUserId = userId;
            FinalizadoEm = DateTime.Now;

            if (statusAtividadeId != null)
                StatusAtividadeId = (int) statusAtividadeId;
        }
    }
}
