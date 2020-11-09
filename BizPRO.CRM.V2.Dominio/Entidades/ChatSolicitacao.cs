using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ChatSolicitacao
    {
        public long Id { get; set; }
        public string CampanhaId { get; set; }
        public int? FilaId { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? SaidoEm { get; set; }
        public DateTime? AtendidoEm { get; set; }
        public string ConexaoClienteId { get; set; }
        public long? AtendimentoId { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public ChatSolicitacao()
        {
            ValidationResult = new ValidationResult();
            CriadoEm = DateTime.Now;
        }
    }
}
