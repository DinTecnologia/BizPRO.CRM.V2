using System;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AtendimentoViewModel
    {
        public long id { get; private set; }
        public string protocolo { get; set; }
        public int? canalOrigemID { get; set; }
        public string criadoPorUserId { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public string finalizadoPorUserID { get; set; }

        public string numeroProtocolo { get; set; }
        public long atendimentoID { get; set; }
        public string numeroOriginal { get; set; }

        public DateTime CriadoEm { get; set; }

        public AtendimentoViewModel(Atendimento atendimento, Ligacao ligacao)
        {
            numeroOriginal = ligacao.NumeroOriginal;
            numeroProtocolo = atendimento.Protocolo;
            atendimentoID = atendimento.Id;
            CriadoEm = atendimento.CriadoEm;
        }
        public AtendimentoViewModel(string numeroProtocolo, long atendimentoID, string numeroOriginal)
        {
            this.numeroOriginal = numeroOriginal;
            this.numeroProtocolo = numeroProtocolo;
            this.atendimentoID = atendimentoID;
        }
        public AtendimentoViewModel(Atendimento atendimento)
        {
            numeroProtocolo = atendimento.Protocolo;
            atendimentoID = atendimento.Id;
            CriadoEm = atendimento.CriadoEm;
        }
        public AtendimentoViewModel(long id, string protocolo, DateTime CriadoEm)
        {
            this.protocolo = protocolo;
            this.id = id;
            this.CriadoEm = CriadoEm;
        }
        public AtendimentoViewModel()
        {

        }
    }
}
