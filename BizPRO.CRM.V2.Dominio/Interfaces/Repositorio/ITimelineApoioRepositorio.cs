using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface ITimelineApoioRepositorio : IRepositorio<TimelineApoio>
    {
        IEnumerable<TimelineApoio> ObterPor(long? pessoaFisicaId, long? pessoaJuridicaId);
    }
}
