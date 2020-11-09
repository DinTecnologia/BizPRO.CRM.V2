using System;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Core.Comum
{
    public class Metodos
    {
        public static DateTime? CalcularSla(int minutos, IEnumerable<DateTime> feriados, bool somenteDiasUteis,
            bool sabadoDiaUtil = false ,DateTime? dataBaseCalculo = null)
        {
            const int horaEmMinutos = 60;
            const int diaEmMinutos = 1440;
            var dataSla = dataBaseCalculo.HasValue ? dataBaseCalculo.Value : DateTime.Now;

            if (minutos <= 0)
                return null;

            var somandoHoras = minutos % diaEmMinutos;
            var somandoDias = (minutos - somandoHoras) / diaEmMinutos;
            var somandoMinutos = somandoHoras % horaEmMinutos;
            somandoHoras = (somandoHoras - somandoMinutos) / horaEmMinutos;

            if (somandoDias > 0)
            {
                for (var i = 0; i < somandoDias; i++)
                {
                    dataSla = dataSla.AddDays(1);
                    if (!somenteDiasUteis) continue;
                    if (ValidarDiaUtil(dataSla, feriados, sabadoDiaUtil)) continue;
                    dataSla = dataSla.AddDays(1);
                    i--;
                }
            }

            if (somandoHoras > 0)
                dataSla = dataSla.AddHours(somandoHoras);

            if (somandoMinutos > 0)
                dataSla = dataSla.AddMinutes(somandoMinutos);

            while (true)
            {
                if (!somenteDiasUteis) break;
                if (!ValidarDiaUtil(dataSla, feriados, sabadoDiaUtil))
                    dataSla = dataSla.AddDays(1);
                else
                {
                    break;
                }
            }


            return dataSla;
        }

        public static bool ValidarDiaUtil(DateTime data, IEnumerable<DateTime> feriados, bool sabadoDiaUtil)
        {
            if ((data.DayOfWeek == DayOfWeek.Saturday && !sabadoDiaUtil) || data.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }

            if (feriados == null || !feriados.Any()) return true;

            var dataEhFeriado =
                feriados.Where(x => x.Year == data.Year || x.Year == 0)
                    .Where(x => x.Month == data.Month)
                    .Where(x => x.Day == data.Day)
                    .ToList();

            return !dataEhFeriado.Any();
        }
    }
}
