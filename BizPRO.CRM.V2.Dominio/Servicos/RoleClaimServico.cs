using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;


namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class RoleClaimServico : IRoleClaimServico
    {
        private readonly IRoleClaimRepositorio _repositorio;
        private readonly IAspNetMatrizServico _servicoAspNetMatriz;

        public RoleClaimServico(IRoleClaimRepositorio repositorio, IAspNetMatrizServico servicoAspNetMatriz)
        {
            _repositorio = repositorio;
            _servicoAspNetMatriz = servicoAspNetMatriz;
        }
        public bool Adicionar(RoleClaim roleClaim)
        {
            _repositorio.Adicionar(roleClaim);

            if (roleClaim.id > 0)
                return true;
            else
                return false;
        }
        public void AtualizarUsuariosNovaRoleClaim(string roleID)
        {
            _repositorio.AtualizarUsuariosNovaRoleClaim(roleID);
        }
        public IEnumerable<RoleClaim> ObteRoleClaims(string roleID)
        {
            return _repositorio.ObterPor(roleID);
        }
        public bool Deletar(long id)
        {
            var entidade = _repositorio.ObterPorId(id);

            if (_repositorio.Deletar(entidade))
                AtualizarUsuariosNovaRoleClaim(entidade.roleID);

            return true;
        }
        public bool Deletar(string roleID)
        {
            return _repositorio.Deletar(roleID);
        }
    }
}
