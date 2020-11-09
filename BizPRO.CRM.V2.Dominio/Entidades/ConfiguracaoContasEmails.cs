using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ConfiguracaoContasEmails
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string ServidorPop { get; set; }
        public string ServidorSmtp { get; set; }
        public bool NecessarioSsl { get; set; }
        public string Email { get; set; }
        public string SenhaEmail { get; set; }
        public string UsuarioEmail { get; set; }
        public int? FilasId { get; set; }
        public int PortaServidorSaida { get; set; }
        public int PortaServidorEntrada { get; set; }
        public string ProtocoloServidorEntrada { get; set; }
        public bool ContaPadrao { get; set; }
        public string Assinatura { get; set; }
        public Fila Fila { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public ConfiguracaoContasEmails()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
