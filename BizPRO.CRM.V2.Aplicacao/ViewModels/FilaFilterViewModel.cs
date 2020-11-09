using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class FilaFilterViewModel
    {     
        public bool? Ativo { get; set; }
        public int? DepartamentoId { get; set; }
        public string UsuarioId { get; set; }
        /// A idéia é ir completando aqui conforme forem surgindo novas necessidades!        

        public FilaFilterViewModel()
        {

        }
    }
}
