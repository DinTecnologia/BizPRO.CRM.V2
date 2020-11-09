namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ChatOpCliMsg
    {
        public string ChatOperadorId { get; set; }
        public string ChatClienteId { get; set; }
        public string Nome { get; set; }
        public string NomeCliente { get; set; }
        public string Mensagem { get; set; }
        public string NmProtocolo { get; set; }
    }
}