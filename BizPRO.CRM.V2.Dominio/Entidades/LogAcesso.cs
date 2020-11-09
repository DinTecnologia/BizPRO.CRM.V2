using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class LogAcesso
    {
        public long id { get; set; }
        public string token { get; set; }
        public DateTime criadoEm { get; set; }
        public DateTime ultimoPing { get; set; }
        public bool valido { get; set; }
        public string AspNetUserID { get; set; }
    }
}
