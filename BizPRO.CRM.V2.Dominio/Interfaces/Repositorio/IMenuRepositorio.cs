using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IMenuRepositorio : IRepositorio<Menu>
    {
        IEnumerable<Menu> ObterMenu(string userId, string url);
    }
}
