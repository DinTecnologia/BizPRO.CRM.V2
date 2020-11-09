using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ChatMensagem
    {
        public long Id { get; set; }
        public long ChatId { get; set; }
        public string Mensagem { get; set; }
        public string Tipo { get; set; }
        public long? ArquivoId { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? LidoEm { get; set; }
        public string StatusMensagemId { get; set; }
        public long? AtividadeParteEnvolvidaId { get; set; }
        public string Nome { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public AtividadeParteEnvolvida AtividadeParteEnvolvida { get; set; }

        public ChatMensagem()
        {
            CriadoEm = DateTime.Now;
            ValidationResult = new ValidationResult();
        }
    }
}
