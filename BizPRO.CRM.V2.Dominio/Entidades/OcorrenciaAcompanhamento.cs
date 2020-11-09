using System;
using System.Text;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class OcorrenciaAcompanhamento
    {
        public long Id { get; set; }
        public string Protocolo { get; set; }
        public DateTime? AtendimentoIniciadoEm { get; set; }
        public DateTime? AtendimentoFinalizadoEm { get; set; }
        public string Cliente { get; set; }
        public string Documento { get; set; }
        public int TotalLigacoesCliente { get; set; }
        public int TotalLigacoesOcorrencia { get; set; }
        public string OcorrenciaTipoNivel1 { get; set; }
        public string OcorrenciaTipoNivel2 { get; set; }
        public string OcorrenciaTipoNivel3 { get; set; }
        public string OcorrenciaTipoNivel4 { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? FinalizaEm { get; set; }
        public string OcorrenciaTipoNomeExibicao { get; set; }
        public bool PossuiSla { get; set; }
        public decimal SlaEmDias { get; set; }
        public bool SlaExcedido { get; set; }
        public decimal SlaExcedidoDias { get; set; }
        public decimal TempoTotalEmDias { get; set; }
        public bool GerouAtividades { get; set; }
        public string Status { get; set; }
        public string CriadoPor { get; set; }
        public string Responsavel { get; set; }
        public int TotalAtividadesGeradas { get; set; }
        public DateTime? ResponsavelAtribuidoEm { get; set; }
        public int TempoPrevistoAtendimento { get; set; }
        public int TempoTotalAtendimento { get; set; }
        public int TempoTotalExcedido { get; set; }
        public string Sla
        {
            get
            {
                return FormatarSla(TempoPrevistoAtendimento);
            }
        }
        public string SlaTempoExcedido
        {
            get
            {
                return FormatarSla(TempoTotalExcedido);
            }
        }
        public string TempoTotal
        {
            get
            {
                return FormatarSla(TempoTotalAtendimento);
            }
        }
        public bool PossuiAtividadeAtrasadaAtendimento { get; set; }
        public bool PossuiAtividadeAtrasadaAtribuicao { get; set; }
        public bool PossuiAlgumAtraso
        {
            get
            {
                var Retorno = false;

                if (SlaExcedido || PossuiAtividadeAtrasadaAtendimento || PossuiAtividadeAtrasadaAtribuicao)
                    Retorno = true;

                return Retorno;
            }
        }
        public string DataUltimaAnotacao { get; set; }
        public string TipoUltimaAnotacao { get; set; }

        protected string FormatarSla(int minutos)
        {
            var sb = new StringBuilder();
            var ts = new TimeSpan(0, minutos, 0);

            if (ts.Days > 0)
            {
                if (ts.Hours > 0 || ts.Minutes > 0)
                    sb.Append(string.Format("{0}d", ts.Days));
                else if (ts.Days == 1)
                    sb.Append(string.Format("{0} Dia", ts.Days));
                else
                    sb.Append(string.Format("{0} Dias", ts.Days));
            }

            if (ts.Hours > 0)
            {
                if (ts.Days > 0 || ts.Minutes > 0)
                    sb.Append(string.Format("{0}h", ts.Hours));
                else if (ts.Hours == 1)
                    sb.Append(string.Format("{0} Hora", ts.Hours));
                else
                    sb.Append(string.Format("{0} Horas", ts.Hours));
            }
            else
            {
                if (sb.Length > 0 && ts.Minutes > 0)
                    sb.Append(string.Format("{0}h", ts.Hours));
            }

            if (ts.Minutes > 0)
            {
                if (ts.Days > 0 || ts.Hours > 0)
                    sb.Append(ts.Minutes);
                else if (ts.Minutes == 1)
                    sb.Append(string.Format("{0} Minuto", ts.Minutes));
                else
                    sb.Append(string.Format("{0} Minutos", ts.Minutes));
            }
            else if (sb.Length == 0)
                sb.Append("--");

            return sb.ToString();
        }
    }
}
