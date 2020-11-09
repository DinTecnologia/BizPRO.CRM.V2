using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using DapperExtensions;
using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class StatusEntidadeRepositorio : Repositorio<StatusEntidade>, IStatusEntidadeRepositorio
    {
        public StatusEntidadeRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public StatusEntidade AxaObterStatusNovoLaudo()
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<StatusEntidade>(f => f.padrao, Operator.Eq, true));
            where.Predicates.Add(Predicates.Field<StatusEntidade>(f => f.ativo, Operator.Eq, true));
            where.Predicates.Add(Predicates.Field<StatusEntidade>(f => f.entidadesValidas, Operator.Like, "%laudo%"));
            return ObterPor(where).FirstOrDefault();
        }

        public IEnumerable<StatusEntidade> AxaObterStatusLaudo()
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<StatusEntidade>(f => f.padrao, Operator.Eq, false));
            where.Predicates.Add(Predicates.Field<StatusEntidade>(f => f.ativo, Operator.Eq, true));
            where.Predicates.Add(Predicates.Field<StatusEntidade>(f => f.entidadesValidas, Operator.Like, "%laudo%"));
            return ObterPor(where);
        }

        public IEnumerable<StatusEntidade> AxaObterStatusLojista()
        {
            return ObterPorProcedimento("usp_front_sel_statusEntidade_Lojista", null);
        }

        public IEnumerable<StatusEntidade> ObterPor(string entidadeValida, bool? padrao, bool? finalizador)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<StatusEntidade>(f => f.ativo, Operator.Eq, true));

            if (padrao.HasValue)
                where.Predicates.Add(Predicates.Field<StatusEntidade>(f => f.padrao, Operator.Eq, padrao));

            if (finalizador.HasValue)
                where.Predicates.Add(Predicates.Field<StatusEntidade>(f => f.finalizador, Operator.Eq, finalizador));

            if (!string.IsNullOrEmpty(entidadeValida))
                where.Predicates.Add(Predicates.Field<StatusEntidade>(f => f.entidadesValidas, Operator.Like,
                    "%" + entidadeValida + "%"));

            return ObterPor(where);
        }

        public IEnumerable<StatusEntidade> ObterPorOcorrenciaTipoId(long ocorrenciaTipoId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ocorrenciaTipoId", ocorrenciaTipoId);
            return ObterPorProcedimento("usp_front_StatusEntidadePorOcorrenciaTipoId", parametros);
        }

        public StatusEntidade ObterStatusOcorrenciaFinalizadoraPadrao()
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<StatusEntidade>(f => f.ativo, Operator.Eq, true));
            where.Predicates.Add(Predicates.Field<StatusEntidade>(f => f.finalizador, Operator.Eq, true));
            return ObterPor(where).FirstOrDefault();
        }
    }
}
