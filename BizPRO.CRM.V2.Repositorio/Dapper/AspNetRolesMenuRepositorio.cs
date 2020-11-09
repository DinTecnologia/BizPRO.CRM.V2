using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using DapperExtensions;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class AspNetRolesMenuRepositorio : Repositorio<AspNetRolesMenu>, IAspNetRolesMenuRepositorio
    {
        public AspNetRolesMenuRepositorio(IDapperContexto context)
            : base(context)
        {
        }

        public IEnumerable<AspNetRolesMenu> BuscarPorMenuId(int id)
        {
            var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pg.Predicates.Add(Predicates.Field<AspNetRolesMenu>(f => f.MenusId, Operator.Eq, id));
            return ObterPor(pg);
        }
    }
}
