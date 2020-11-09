using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IRoleClaimRepositorio : IRepositorio<RoleClaim>
    {
        IEnumerable<RoleClaim> ObterPor(string roleId);
        void AtualizarUsuariosNovaRoleClaim(string roleId);
        bool Deletar(string roleId);
    }
}
