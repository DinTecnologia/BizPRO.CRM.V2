using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IMenuServico : IServico<Menu>
    {
        IEnumerable<Menu> ObterMenu(string userId, string url);        
    }
}
