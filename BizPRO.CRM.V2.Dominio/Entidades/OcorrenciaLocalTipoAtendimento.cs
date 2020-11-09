using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class OcorrenciaLocalTipoAtendimento
    {
        public long Id { get; set; }
        public long OcorrenciasId { get; set; }
        public int LocaisId { get; set; }
        public int LocaisTiposAtendimentoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public int? CidadesId { get; set; }
        public string CriadoPorUserId { get; set; }
        public DateTime CriadoEm { get; set; }
        public string AlteradoPorUserId { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public ValidationResult ValidationResult { get; private set; }
        public string Complemento { get; set; }
        public LocalTipoAtendimento LocalTipoAtendimento { get; set; }

        public OcorrenciaLocalTipoAtendimento()
        {
            ValidationResult = new ValidationResult();
        }

        public OcorrenciaLocalTipoAtendimento(long ocorrrenciaId, int locaisId, int locaisTiposAtendimentoId,
            string logradouro, string numero, string cep, string bairro, int? cidadesId, string criadoPorUserId,
            string complemento)
        {
            OcorrenciasId = ocorrrenciaId;
            LocaisId = locaisId;
            LocaisTiposAtendimentoId = locaisTiposAtendimentoId;
            Logradouro = logradouro;
            Numero = numero;
            Cep = cep;
            Bairro = bairro;
            CidadesId = cidadesId;
            CriadoPorUserId = criadoPorUserId;
            ValidationResult = new ValidationResult();
            CriadoEm = DateTime.Now;
            Complemento = complemento;
        }
    }
}
