using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using DapperExtensions;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class EmailRepositorio : Repositorio<Email>, IEmailRepositorio
    {
        public EmailRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Email> ObterEmailsPendentesDeEnvio(long filaId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@FilaID", filaId);

            var retorno = Conn.Query<Email, Atividade, Usuario, Email>("usp_back_sel_EmailsPendentesDeEnvio",
                (email, atividade, responsavel) =>
                {
                    email.Atividade = atividade;
                    email.Atividade.Responsavel = responsavel;
                    return email;
                },
                parametros,
                splitOn: "Id,id,id",
                commandType: CommandType.StoredProcedure);

            return retorno;
        }

        public IEnumerable<Email> ObterUids(int configuracaContasEmailsId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@configuracaoContasEmailID", configuracaContasEmailsId);
            return ObterPorProcedimento("usp_front_sel_Email_UID", parametros);
        }

        public Email ObterEmailPorAtividadeId(long atividadeId)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<Email>(f => f.AtividadeId, Operator.Eq, atividadeId));
            return ObterPor(where).FirstOrDefault();
        }

        public Email ObterEmailCompletoPor(long? emailId, long? atividadeId)
        {
            var parametros = new DynamicParameters();

            if (atividadeId != null)
                parametros.Add("@atividadeId", atividadeId);

            if (emailId != null)
                parametros.Add("@emailId", emailId);

            var retorno = Conn.Query<Email, Atividade, Usuario, Email>("usp_front_sel_EmailCompleto",
                (email, atividade, responsavel) =>
                {
                    email.Atividade = atividade;
                    email.Atividade.Responsavel = responsavel;
                    return email;
                },
                parametros,
                splitOn: "Id,id,id",
                commandType: CommandType.StoredProcedure);

            return retorno.FirstOrDefault();
        }

        public int PossuiNovosEmails(string userId)
        {
            int retorno = 0;
            var parametros = new DynamicParameters();
            parametros.Add("@userID", userId);
            var emails = ObterPorProcedimento("usp_front_sel_VerificarNovoEmail", parametros);

            if (emails != null)
                retorno = emails.Count();

            return retorno;
        }

        public Email BuscarProximoEmail(string userId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@userID", userId);
            return ObterPorProcedimento("usp_front_sel_BuscarProximoEmail", parametros).FirstOrDefault();
        }

        public void ClassificarEmailAutomatico(long atividadeId, long statusAtividadeId, int filaId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@AtividadeId", atividadeId);
            parametros.Add("@StatusAtividadeId", statusAtividadeId);
            parametros.Add("@FilaId", filaId);
            ExecutarProcedimento("usp_batch_upd_EmailsSpam", parametros);
        }
    }
}
