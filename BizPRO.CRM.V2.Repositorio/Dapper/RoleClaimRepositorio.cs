using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using DapperExtensions;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class RoleClaimRepositorio : Repositorio<RoleClaim>, IRoleClaimRepositorio
    {
        public RoleClaimRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public void AtualizarUsuariosNovaRoleClaim(string roleId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@roleID", roleId);
            ExecutarProcedimento("usp_front_upd_NovaRoleClaim", parametros);
        }

        public IEnumerable<RoleClaim> ObterPor(string roleId)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<RoleClaim>(f => f.roleID, Operator.Eq, roleId));
            return ObterPor(where);
        }

        public bool Deletar(string roleId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@roleID", roleId);
            try
            {
                ExecutarProcedimento("usp_front_del_AspNetRolesClaims", parametros);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
