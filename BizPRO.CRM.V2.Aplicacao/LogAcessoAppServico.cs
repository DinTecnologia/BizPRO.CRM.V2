using System;
using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DapperExtensions;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class LogAcessoAppServico : AppServicoDapper, ILogAcessoAppServico
    {
        private readonly ILogAcessoServico _logAcessoServico;

        public LogAcessoAppServico(ILogAcessoServico logAcessoServico)
        {
            _logAcessoServico = logAcessoServico;
        }

        public void AdicionarLogAcesso(string chatid, string id)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<LogAcesso>(f => f.AspNetUserID, Operator.Eq, id));
            where.Predicates.Add(Predicates.Field<LogAcesso>(f => f.valido, Operator.Eq, true));
            var lstServAcesso = _logAcessoServico.ObterPor(where);

            foreach (var x in lstServAcesso)
            {
                if (!x.valido) continue;
                x.valido = false;
                _logAcessoServico.Atualizar(x);
            }

            var logAcessoEntity = new LogAcesso
            {
                token = chatid,
                criadoEm = DateTime.Now,
                valido = true,
                ultimoPing = DateTime.Now,
                AspNetUserID = id
            };

            _logAcessoServico.Adicionar(logAcessoEntity);
        }

        public bool SessaoLogAcesso(string userId, bool ativo)
        {
            try
            {
                var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
                where.Predicates.Add(Predicates.Field<LogAcesso>(f => f.AspNetUserID, Operator.Eq, userId));
                var logAcessoEntity = _logAcessoServico.ObterPor(where);
                foreach (var log in logAcessoEntity)
                {
                    if (!log.valido) continue;
                    log.valido = ativo;
                    _logAcessoServico.Atualizar(log);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool VerificarUsuarioDisponivel()
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<LogAcesso>(f => f.valido, Operator.Eq, true));
            var lstServAcesso = _logAcessoServico.ObterPor(where);
            if (lstServAcesso.Any())
                return true;
            return false;
        }
    }
}
