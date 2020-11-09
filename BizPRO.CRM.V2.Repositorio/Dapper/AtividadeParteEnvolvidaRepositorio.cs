using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using DapperExtensions;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class AtividadeParteEnvolvidaRepositorio : Repositorio<AtividadeParteEnvolvida>,
        IAtividadeParteEnvolvidaRepositorio
    {
        public AtividadeParteEnvolvidaRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<AtividadeParteEnvolvida> ObterPorAtividadeId(long atividadeId)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<AtividadeParteEnvolvida>(f => f.AtividadesId, Operator.Eq, atividadeId));
            return ObterPor(where);
        }

        public IEnumerable<AtividadeParteEnvolvida> BuscarPor(long atividadeId, string tipoParteEnvolvida)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<AtividadeParteEnvolvida>(f => f.AtividadesId, Operator.Eq, atividadeId));
            where.Predicates.Add(Predicates.Field<AtividadeParteEnvolvida>(f => f.TipoParteEnvolvida, Operator.Eq,
                tipoParteEnvolvida));
            return ObterPor(where);
        }

        public IEnumerable<AtividadeParteEnvolvida> BuscarPor(long atividadeId, long? pessoaFisicaId,
            long? pessoaJuridicaId)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<AtividadeParteEnvolvida>(f => f.AtividadesId, Operator.Eq, atividadeId));

            if (pessoaFisicaId.HasValue)
                where.Predicates.Add(Predicates.Field<AtividadeParteEnvolvida>(f => f.PessoasFisicasId, Operator.Eq,
                    pessoaFisicaId));

            if (pessoaJuridicaId.HasValue)
                where.Predicates.Add(Predicates.Field<AtividadeParteEnvolvida>(f => f.PessoasJuridicasId, Operator.Eq,
                    pessoaJuridicaId));

            return ObterPor(where);
        }
    }
}
