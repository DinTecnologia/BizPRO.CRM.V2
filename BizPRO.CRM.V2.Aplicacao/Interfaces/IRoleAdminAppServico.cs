using System.Collections.Generic;
using BizPRO.CRM.V2.Identity.Model;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IRoleAdminAppServico
    {
        IEnumerable<MatrizClaim> Editar(string roleId, List<Claims> claims);
        bool Atualizar(RoleViewModel model);
    }
}