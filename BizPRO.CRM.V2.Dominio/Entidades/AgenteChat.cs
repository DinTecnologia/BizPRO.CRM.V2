namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class AgenteChat
    {
        public string AgenteChatId { get; set; }
        public string NomeAgenteChat { get; set; }
        public bool IsOnline { get; set; }
        public bool IsPausa { get; set; }
        public bool IsContadorPausa { get; set; }
        public string Id { get; set; }
    }
}