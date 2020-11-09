using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IRoleClaimServico
    {
        bool Adicionar(RoleClaim roleClaim);
        void AtualizarUsuariosNovaRoleClaim(string roleId);
        IEnumerable<RoleClaim> ObteRoleClaims(string roleId);
        bool Deletar(long id);
        bool Deletar(string roleId);
    }
}
