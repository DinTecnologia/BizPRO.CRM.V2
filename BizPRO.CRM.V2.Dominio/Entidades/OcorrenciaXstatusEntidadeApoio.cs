using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class OcorrenciaXstatusEntidadeApoio
    {
        public string cliente { get; set; }
        public string tipo { get; set; }
        public string status { get; set; }
        public DateTime criadoEm { get; set; }
        public string responsavel { get; set; }
        public DateTime? finalizadoEm { get; set; }
        public int dias { get; set; }
        public long OcorrenciaID { get; set; }
        public bool atrasadoAtendimento { get; set; }
        public int sla { get; set; }
        public string tempoTotal { get; set; }
        public string estiloLinha
        {
            get
            {
                var classe = "";
                if (atrasadoAtendimento)
                    classe = "Atividade-Atrasada";

                if (finalizadoEm.HasValue)
                    classe = "Atividade-Finalizada";

                return classe;
            }
        }
        public string Departamento { get; set; }

        public string tempoAtividade
        {
            get
            {
                if (sla > 0)
                {
                    var result = TimeSpan.FromMinutes(sla);
                    TimeSpan ts = (finalizadoEm.HasValue ? finalizadoEm : DateTime.Now).Value.Subtract(criadoEm);
                    var tempoPassado = ts.Subtract(result);
                    if (tempoPassado.Ticks > 0)
                    {
                        if (tempoPassado != null)
                            return string.Format("{0} dia(s) {1}hrs {2}min", tempoPassado.Days, tempoPassado.Hours.ToString().PadLeft(2, '0'), tempoPassado.Minutes.ToString().PadLeft(2, '0'));
                        else
                            return "--";
                    }
                    else
                    {
                        //DateTime periodo = new DateTime(ts.Ticks);

                        //if (periodo != null)
                        //    return string.Format("{0} dia(s) {1}hrs {2}min", periodo.Day, periodo.Hour.ToString().PadLeft(2, '0'), periodo.Minute.ToString().PadLeft(2, '0'));
                        //else
                        return "--";
                    }
                }
                else
                    return "--";
            }
        }

    }
}
