using System.Collections.Generic;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ComboFilaViewModel
    {
        public int Id { get; set; }
        public long? IdSelecionado { get; set; }
        public SelectList SelecioneFila { get; set; }

        public ComboFilaViewModel(IEnumerable<FilaViewModel> selecioneFila, long? filaId)
        {
            SelecioneFila = new SelectList(selecioneFila, "id", "nome");
            IdSelecionado = filaId;
        }

        public ComboFilaViewModel()
        {

        }
    }
}
