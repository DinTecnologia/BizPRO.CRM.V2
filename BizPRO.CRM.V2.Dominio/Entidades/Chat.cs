using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Chat
    {
        public long Id { get; set; }
        public long AtividadeId { get; set; }
        public string ConexaoClienteId { get; set; }
        public string ConexaoOperadorId { get; set; }
        public string Tipo { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public long ChatSolicitacaoId { get; set; }
        public Atividade Atividade { get; set; }
        public bool Online { get; set; }

        public Chat()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
