using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IAspNetRolesFilaServico 
    {
        IEnumerable<AspNetRolesFila> ObterPorFila(long id);
        AspNetRolesFila InserirFilas(AspNetRolesFila aspNetRolesFila);
        void DeletaRolesFilas(long filaId);
    }
}
