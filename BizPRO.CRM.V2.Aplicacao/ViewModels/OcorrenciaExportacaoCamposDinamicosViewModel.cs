using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class OcorrenciaExportacaoCamposDinamicosViewModel
    {
        public IEnumerable<camposDinamicosViewModel> CamposDinamicosOcorrencia { get; set; }
        public IEnumerable<camposDinamicosViewModel> CamposDinamicosContrato { get; set; }
    }
}
