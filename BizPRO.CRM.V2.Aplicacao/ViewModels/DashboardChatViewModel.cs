using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class DashboardChatViewModel
    {
        public int MyProperty { get; set; }
        public IEnumerable<Dashboard> Dashboard { get; set; }
        public string TempoMedioGeral { get; set; }
        public ValidationResult ValidationResult { get; set; }


        public DashboardChatViewModel()
        {
            ValidationResult = new ValidationResult();
        }

        public string ConvertSegundoEmTempo(int segundos)
        {
            var dia = 0;
            var hora = 0;
            var minuto = 0;

            if (segundos > 86400)
            {
                dia = segundos / 86400;
                segundos = segundos - (dia * 86400);
            }

            if (segundos > 3600)
            {
                hora = segundos / 3600;
                segundos = segundos - (hora * 3600);
            }

            if (segundos > 60)
            {
                minuto = segundos / 60;
                segundos = segundos - (minuto * 60);
            }

            if (dia > 0)
                return dia + "d" + hora.ToString().PadLeft(2, '0') + "h" + minuto.ToString().PadLeft(2, '0');

            if (hora > 0)
                return hora.ToString().PadLeft(2, '0') + "h" + minuto.ToString().PadLeft(2, '0');

            return minuto.ToString().PadLeft(2, '0') + "m" + segundos.ToString().PadLeft(2, '0');
        }
    }
}
