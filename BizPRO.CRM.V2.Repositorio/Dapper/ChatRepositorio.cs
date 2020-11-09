using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using DapperExtensions;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class ChatRepositorio : Repositorio<Chat>, IChatRepositorio
    {
        public ChatRepositorio(IDapperContexto context)
            : base(context)
        {
        }

        public bool Online(int? filaId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@filaId", filaId);
            var chat = ObterPorProcedimento("usp_chat_VerificaOnline", parametros).FirstOrDefault();
            return chat != null && chat.Online;
        }

        public Chat ObterPorAtividadeId(long atividadeId)
        {
            var parametros = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            parametros.Predicates.Add(Predicates.Field<Chat>(f => f.AtividadeId, Operator.Eq, atividadeId));
            return ObterPor(parametros).FirstOrDefault();
        }
    }
}
