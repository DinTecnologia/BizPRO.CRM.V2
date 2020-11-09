using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ClienteChat
    {
        public string TokenCli { get; set; }
        public string NomeCli { get; set; }
        public string Doc { get; set; }
        public long Atividadeid { get; set; }
        public long IdCliente { get; set; }
        public string TipoCliente { get; set; }
        public long Filaid { get; set; }
        public long Chatid { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }
    }
}