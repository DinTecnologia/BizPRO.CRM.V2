using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Collections.Generic;
using DapperExtensions;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class AtendimentoOcorrenciaRepositorio : Repositorio<AtendimentoOcorrencia>, IAtendimentoOcorrenciaRepositorio
    {
        public AtendimentoOcorrenciaRepositorio(IDapperContexto context)
            : base(context)
        {
        }

        public IEnumerable<AtendimentoOcorrencia> BuscarAtendimentoOcorrencia(long atendimentoId, long ocorrenciaId)
        {
            var where = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            where.Predicates.Add(Predicates.Field<AtendimentoOcorrencia>(f => f.AtendimentosId, Operator.Eq, atendimentoId));
            where.Predicates.Add(Predicates.Field<AtendimentoOcorrencia>(f => f.OcorrenciasId, Operator.Eq, ocorrenciaId));
            return ObterPor(where);
        }

        public IEnumerable<AtendimentoOcorrencia> ObterOcorrenciasVinculadasAoAtendimento(long atendimentoId)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<AtendimentoOcorrencia>(f => f.AtendimentosId, Operator.Eq,
                atendimentoId));
            return ObterPor(where);
        }
    }
}
