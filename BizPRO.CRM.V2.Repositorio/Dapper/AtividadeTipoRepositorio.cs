using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using DapperExtensions;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class AtividadeTipoRepositorio : Repositorio<AtividadeTipo>, IAtividadeTipoRepositorio
    {
        public AtividadeTipoRepositorio(IDapperContexto context)
            : base(context)
        {
        }

        public AtividadeTipo BuscarPorNome(string nome)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<AtividadeTipo>(f => f.Nome, Operator.Like, nome));
            var atividadesTipo = ObterPor(where);

            return atividadesTipo.Any() ? atividadesTipo.FirstOrDefault() : null;
        }
    }
}
