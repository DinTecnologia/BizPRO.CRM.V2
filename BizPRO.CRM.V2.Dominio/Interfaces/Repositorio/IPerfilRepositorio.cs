using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IPerfilRepositorio : IRepositorio<Perfil>
    {
        IEnumerable<Perfil> ObterPerfis(string usuarioId);
    }
}
