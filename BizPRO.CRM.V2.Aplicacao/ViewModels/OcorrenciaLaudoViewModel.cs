using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class OcorrenciaLaudoViewModel
    {
        public IEnumerable<OcorrenciaListaItemViewModel> OcorrenciaLaudoLista { get; set; }
        public string Cliente { get; set; }
        public string Documento { get; set; }
        public string Protocolo { get; set; }
        public long? OcorrenciasTiposID { get; set; }
        //public IEnumerable<OcorrenciaTipoViewModel> ListarOcorrenciaTipo { get; set; }
    }
}
