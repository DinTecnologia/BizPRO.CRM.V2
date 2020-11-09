using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface ITimelineAppServico
    {
        IEnumerable<TimelineApoio> CarregarTimeLine(long? pessoaFisicaId, long? pessoaJuridicaId);
    }
}
