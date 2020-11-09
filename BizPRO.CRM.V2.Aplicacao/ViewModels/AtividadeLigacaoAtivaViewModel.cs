using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AtividadeLigacaoAtivaViewModel
    {        
        public SelectList Midias { get; set; }
        public IEnumerable<StatusAtividade> ListaStatusAtividade { get; set; }
    }
}
