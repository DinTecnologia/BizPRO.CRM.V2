using System.Collections.Generic;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using Camadas.Infra.Repositorio.Dapper.Comum;
using DapperExtensions;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class ConfiguracaoRepositorio : Repositorio<Configuracao>, IConfiguracaoRepositorio
    {
        public ConfiguracaoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Configuracao> ObterPorSigla(string sigla)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<Configuracao>(f => f.Sigla, Operator.Eq, sigla));
            where.Predicates.Add(Predicates.Field<Configuracao>(f => f.Ativo, Operator.Eq, true));
            return ObterPor(where);
        }
    }
}
