using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class ChatClienteViewModel
    {
        public string CampanhaId { get; set; }
        public int? FilaId { get; set; }
        public long? ChatRequisicaoId { get; set; }
        public string ConexaoClienteId { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public ChatClienteViewModel()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
