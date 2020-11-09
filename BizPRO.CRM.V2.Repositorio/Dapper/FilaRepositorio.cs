using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Dapper;
using System.Data;
using DapperExtensions;
using System;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class FilaRepositorio : Repositorio<Fila>, IFilaRepositorio
    {
        public FilaRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Fila> ObterFilaMenu(string userId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@userID", userId);
            return ObterPorProcedimento("usp_front_sel_FilaMenu", parametros);
        }

        public IEnumerable<Fila> ObterFilaLigacao()
        {
            return ObterPorProcedimento("usp_front_sel_FilaLigacao", null);
        }

        public IEnumerable<Fila> ObterFilasFiltroDashboard(string userId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@userID", userId);
            return ObterPorProcedimento("usp_front_sel_FilasFiltroDashboard", parametros);
        }

        public IEnumerable<Fila> ObterFilasPorUsuario(string userId, bool? aceitaLigacao, bool? aceitaEmail,
            bool? aceitaTarefa,
            bool? aceitaChatSms, bool? aceitaChatWeb, bool? aceitaChatMessenger, bool? ativo)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@UserID", userId);
            parametros.Add("@AceitaLigacoes", aceitaLigacao);
            parametros.Add("@AceitaEmails", aceitaEmail);
            parametros.Add("@AceitaTarefas", aceitaTarefa);
            parametros.Add("@AceitaChatSMS", aceitaChatSms);
            parametros.Add("@AceitaChatWeb", aceitaChatWeb);
            parametros.Add("@AceitaChatMessenger", aceitaChatMessenger);
            parametros.Add("@Ativo", true);
            return ObterPorProcedimento("usp_front_sel_FilaPermissaoPorUsuario", parametros);
        }

        public IEnumerable<Fila> ObterFilasParaAlterar(long atividadeId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@atividadeId", atividadeId);
            return ObterPorProcedimento("usp_front_sel_FilasAlterar_PorAtividadeId", parametros);
        }

        public IEnumerable<Fila> ObterVisaoAdmin()
        {
            var parametros = new DynamicParameters();

            var retorno = Conn.Query<Fila, ConfiguracaoContasEmails, Fila>("usp_admin_sel_Filas",
                (ret, conta) =>
                {
                    ret.ContaEmailDisparo = conta;
                    return ret;
                },
                parametros,
                splitOn: "Id,id",
                commandType: CommandType.StoredProcedure);

            return retorno;
        }

        public IEnumerable<Fila> ObterPorDepartamentoId(int? departamentoId)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<Fila>(f => f.Ativo, Operator.Eq, true));

            if (departamentoId.HasValue)
                where.Predicates.Add(Predicates.Field<Fila>(f => f.DepartamentoId, Operator.Eq, departamentoId));

            return ObterPor(where);
        }

        public IEnumerable<Fila> ObterPor(bool? aceitaLigacao, bool? aceitaEmail, bool? aceitaTarefa,
            bool? aceitaChatSms, bool? aceitaChatWeb, int? departamentoId)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<Fila>(f => f.Ativo, Operator.Eq, true));

            if (aceitaLigacao.HasValue)
                where.Predicates.Add(Predicates.Field<Fila>(f => f.AceitaLigacoes, Operator.Eq, aceitaLigacao));

            if (aceitaEmail.HasValue)
                where.Predicates.Add(Predicates.Field<Fila>(f => f.AceitaEmails, Operator.Eq, aceitaEmail));

            if (aceitaTarefa.HasValue)
                where.Predicates.Add(Predicates.Field<Fila>(f => f.AceitaTarefas, Operator.Eq, aceitaTarefa));

            if (aceitaChatSms.HasValue)
                where.Predicates.Add(Predicates.Field<Fila>(f => f.AceitaChatSms, Operator.Eq, aceitaChatSms));

            if (aceitaChatWeb.HasValue)
                where.Predicates.Add(Predicates.Field<Fila>(f => f.AceitaChatWeb, Operator.Eq, aceitaChatWeb));

            if (departamentoId.HasValue)
                where.Predicates.Add(Predicates.Field<Fila>(f => f.DepartamentoId, Operator.Eq, departamentoId));

            return ObterPor(where);
        }

        public IEnumerable<Fila> ObterPor(int? departamentoId, string usuarioId)
        {
            var parametros = new DynamicParameters();

            if (departamentoId.HasValue)
                parametros.Add("@departamentoId", departamentoId);

            if (!string.IsNullOrEmpty(usuarioId))
                parametros.Add("@usuarioId", usuarioId);

            return ObterPorProcedimento("usp_front_sel_Filas_ObterPor", parametros);
        }

        public IEnumerable<Fila> ObterFilaPorCanalId(int? canalId)
        {
            var where = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };

            if (canalId.HasValue)
                where.Predicates.Add(Predicates.Field<Fila>(f => f.CanalId, Operator.Eq, canalId));

            return ObterPor(where);
        }
    }
}
