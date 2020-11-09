using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class TimelineAppServico : ITimelineAppServico
    {
        private readonly ITimelineApoioServico _servicoTimeline;

        public TimelineAppServico(ITimelineApoioServico servicoTimeline)
        {
            this._servicoTimeline = servicoTimeline;
        }
        public IEnumerable<TimelineApoio> CarregarTimeLine(long? pessoaFisicaID, long? pessoaJuridicaID)
        {
            return _servicoTimeline.CarregarTimeline(pessoaFisicaID, pessoaJuridicaID);
        }
    }
}
