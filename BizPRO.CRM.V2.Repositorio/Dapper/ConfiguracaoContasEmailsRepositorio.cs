using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Dapper;
using DapperExtensions;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class ConfiguracaoContasEmailsRepositorio : Repositorio<ConfiguracaoContasEmails>,
        IConfiguracaoContasEmailsRepositorio
    {
        public ConfiguracaoContasEmailsRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public ConfiguracaoContasEmails ObterContaEmailPorAtividadeId(long atividadeId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@atividadeId", atividadeId);
            return ObterPorProcedimento("usp_front_sel_ConfiguracaoContaEmail", parametros).FirstOrDefault();
        }

        public ConfiguracaoContasEmails ObterPorFilaId(int filaId)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<ConfiguracaoContasEmails>(f => f.FilasId, Operator.Eq, filaId));
            return ObterPor(where).FirstOrDefault();
        }

        public ConfiguracaoContasEmails ObterContaPadrao()
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<ConfiguracaoContasEmails>(f => f.ContaPadrao, Operator.Eq, true));
            return ObterPor(where).FirstOrDefault();
        }

        public IEnumerable<ConfiguracaoContasEmails> ObterPorUsuarioId(string usuarioId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@usuarioId", usuarioId);
            return ObterPorProcedimento("usp_front_sel_ConfiguracaoContaEmailPorUsuarioId", parametros);
        }


        public IEnumerable<ConfiguracaoContasEmails> ObterRegistroEmailEntrada(string usuarioId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@usuarioId", usuarioId);
            return ObterPorProcedimento("usp_front_sel_ConfiguracaoContaEmail_RegistroEmailEntrada", parametros);
        }
    }
}
