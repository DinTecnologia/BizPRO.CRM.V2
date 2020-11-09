using System;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AgendamentoViewModal
    {
        public long? atividadeID { get; set; }
        public DateTime dataAgendamento { get; set; }
        public string data { get; set; }
        public string hora { get; set; }

        public AgendamentoViewModal()
        {
            dataAgendamento = DateTime.Now;
            data = "";
            hora = "";
        }
    }
}
