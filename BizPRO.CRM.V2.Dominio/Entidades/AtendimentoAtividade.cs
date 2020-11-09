using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class AtendimentoAtividade
    {
        public long Id { get;  set; }
        public long AtividadesId { get; private set; }
        public long AtendimentosId { get; private set; }
        public ValidationResult ValidationResult { get; private set; }

        public AtendimentoAtividade()
        {
            ValidationResult = new ValidationResult();
        }

        public AtendimentoAtividade(long atividadeId, long atendimentoId)
        {
            ValidationResult = new ValidationResult();
            AtividadesId = atividadeId;
            AtendimentosId = atendimentoId;
        }
    }
}
