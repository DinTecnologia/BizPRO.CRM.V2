using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Anotacao
    {
        public long Id { get; set; }
        public string Texto { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }
        public long? OcorrenciaId { get; set; }
        public long? AtividadeId { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public long? PotenciaisClienteId { get; set; }
        public Usuario CriadoPorUser { get; set; }
        public bool AcompanhamentoOcorrencia { get; set; }
        public long? AnotacaoTipoId { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public Anotacao()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            CriadoPorUser = new Usuario();
        }

        public Anotacao(string texto, string criadoPorUserId, long? ocorrenciaId, long? atividadeId,
            long? pessoaFisicaId, long? pessoaJuridicaId, long? potenciaisClienteId, bool acompanhamentoOcorrencia,
            long? anotacaoTipoId)
        {
            Texto = texto;
            CriadoPorUserId = criadoPorUserId;
            OcorrenciaId = ocorrenciaId;
            AtividadeId = atividadeId;
            PessoaFisicaId = pessoaFisicaId;
            PessoaJuridicaId = pessoaJuridicaId;
            CriadoEm = DateTime.Now;
            PotenciaisClienteId = potenciaisClienteId;
            AcompanhamentoOcorrencia = acompanhamentoOcorrencia;
            AnotacaoTipoId = anotacaoTipoId;
            ValidationResult = new ValidationResult();
        }
    }
}
