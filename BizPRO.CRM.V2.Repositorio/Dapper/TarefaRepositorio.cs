using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using DapperExtensions;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class TarefaRepositorio : Repositorio<Tarefa>, ITarefaRepositorio
    {
        public TarefaRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public void AtualizarDados(Tarefa tarefas)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@UserID", tarefas.CriadoPorUserId);
            parametros.Add("@tarefaID", tarefas.Id);
            parametros.Add("@atividadeID", tarefas.AtividadeId);
            ExecutarProcedimento("usp_upd_tarefasAtividadesFilas", parametros);
        }

        public IEnumerable<Tarefa> ObterPorOcorrencia(long ocorrenciaId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ocorrenciaID", ocorrenciaId);
            return ObterPorProcedimento("usp_front_sel_TarefasPorOcorrenciaID", parametros);
        }

        public Tarefa BuscarPorAtividadeId(long atividadeId)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<Tarefa>(f => f.AtividadeId, Operator.Eq, atividadeId));
            return ObterPor(where).FirstOrDefault();
        }
    }
}
