using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Ocorrencia
    {
        public long Id { get; set; }
        public long OcorrenciasTiposId { get; set; }
        public string DecritivoDeAbertura { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public long? PotenciaisClientesId { get; set; }
        public long? ContratoId { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public string FinalizadoPorUserId { get; set; }
        public long StatusEntidadesId { get; set; }
        public DateTime? UltimaAtualizacaoEm { get; set; }
        public OcorrenciaTipo OcorrenciaTipo { get; set; }
        public StatusEntidade StatusEntidade { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public string AtualizadoPorAspNetUserId { get; set; }
        public PessoaFisica PessoaFisica { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }
        public string ResponsavelPorAspNetUserId { get; set; }
        public DateTime? ResponsavelAtribuidoEm { get; set; }
        public Usuario Responsavel { get; set; }
        public string CampoChave1 { get; set; }
        public Atendimento Atendimento { get; set; }
        public bool Finalizada { get; set; }
        public DateTime? PrevisaoInicial { get; set; }
        public DateTime? PrevisaoNova { get; set; }

        public bool PossuiVinculoComAtendimento { get; set; }

        public Ocorrencia()
        {
            OcorrenciaTipo = new OcorrenciaTipo();
            StatusEntidade = new StatusEntidade();
            ValidationResult = new ValidationResult();
        }

        public Ocorrencia(long clienteId, string tipoCliente)
        {
            if (tipoCliente == "PJ")
                PessoaJuridicaId = clienteId;
            else
                PessoaFisicaId = clienteId;
            ValidationResult = new ValidationResult();
        }

        public Ocorrencia(long? pessoaFisicaId, long? pessoaJuridicaId)
        {
            PessoaFisicaId = pessoaFisicaId;
            PessoaJuridicaId = pessoaJuridicaId;
            ValidationResult = new ValidationResult();
        }

        public Ocorrencia(int ocorrenciaTipoId, string descritivo, long? pessoaFisicaId, long? pessoaJuridicaId,
            long? contratoId, string criadoPorUserId, string campoChave1, DateTime? previsaoInicial)
        {
            OcorrenciasTiposId = ocorrenciaTipoId;
            DecritivoDeAbertura = descritivo;
            CriadoEm = DateTime.Now;
            CriadoPorUserId = criadoPorUserId;
            PessoaFisicaId = pessoaFisicaId;
            PessoaJuridicaId = pessoaJuridicaId;
            ContratoId = contratoId;
            CampoChave1 = campoChave1;
            PrevisaoInicial = previsaoInicial;
            ValidationResult = new ValidationResult();
        }
    }
}
