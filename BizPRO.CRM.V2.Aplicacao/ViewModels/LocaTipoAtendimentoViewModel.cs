using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class LocaTipoAtendimentoViewModel
    {
        public long LocalId { get; set; }
        public long? LocalTipoAtendimentoId { get; set; }
        public SelectList TiposAtendimentos { get; set; }

        public LocaTipoAtendimentoViewModel(long localId, IEnumerable<LocalTipoAtendimento> tiposAtendimento)
        {
            LocalId = localId;
            TiposAtendimentos = new SelectList(tiposAtendimento, "id", "nome");
        }
    }
}
