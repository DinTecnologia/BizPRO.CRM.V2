using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using DapperExtensions;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class EmailModeloRepositorio : Repositorio<EmailModelo>, IEmailModeloRepositorio
    {
        public EmailModeloRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<EmailModelo> ObterPor(EmailModelo entidade)
        {
            var where = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            where.Predicates.Add(Predicates.Field<EmailModelo>(f => f.Ativo, Operator.Eq, true));

            if (!string.IsNullOrEmpty(entidade.NomeDoModelo))
                where.Predicates.Add(Predicates.Field<EmailModelo>(f => f.NomeDoModelo, Operator.Eq, entidade.NomeDoModelo));

            return ObterPor(where);
        }
    }
}
