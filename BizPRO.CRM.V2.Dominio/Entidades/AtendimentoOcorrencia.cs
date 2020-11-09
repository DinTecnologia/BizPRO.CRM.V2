using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class AtendimentoOcorrencia
    {
        public long Id { get; private set; }
        public long OcorrenciasId { get; set; }
        public long AtendimentosId { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public AtendimentoOcorrencia()
        {
            ValidationResult = new ValidationResult();
        }

        public AtendimentoOcorrencia(long ocorrenciaId, long atendimentoId)
        {
            OcorrenciasId = ocorrenciaId;
            AtendimentosId = atendimentoId;
            ValidationResult = new ValidationResult();
        }
    }
}
