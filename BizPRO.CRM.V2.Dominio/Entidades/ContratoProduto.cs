using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ContratoProduto
    {
        public long Id { get; set; }
        public long ProdutoId { get; set; }
        public long ContratoId { get; set; }
        public Contrato Contrato { get; set; }
        public Produto Produto { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public ContratoProduto()
        {
            ValidationResult = new ValidationResult();
        }

        public ContratoProduto(long produtoId, long contratoId)
        {
            ProdutoId = produtoId;
            ContratoId = contratoId;
        }
    }
}
