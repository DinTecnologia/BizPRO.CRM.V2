using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IAspNetRolesMenuRepositorio : IRepositorio<AspNetRolesMenu>
    {
        IEnumerable<AspNetRolesMenu> BuscarPorMenuId(int id);
    }
}