using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IPausaMotivoRepositorio : IRepositorio<PausaMotivo>
    {
        IEnumerable<PausaMotivo> ObterPorCanalIds(string canalIds);
    }
}
