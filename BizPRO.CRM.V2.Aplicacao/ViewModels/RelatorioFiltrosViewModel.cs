using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class RelatorioFiltrosViewModel
    {
        public int CanalID { get; set; }
        public int MidiaID { get; set; }
    }
    public class RelatorioFiltrosSelecionadosViewModel
    {
        public int? AtividadeTipoID { get; set; }
        public int? StatusAtividadeID { get; set; }
        public string Sentido { get; set; }
        public long? ClienteID { get; set; }
        public string TipoCliente { get; set; }
        public string UsuarioID { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
    }
}
