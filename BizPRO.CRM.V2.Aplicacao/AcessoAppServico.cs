using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using DapperExtensions;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class AcessoAppServico : AppServicoDapper, IAcessoAppServico
    {
        private readonly IAcessoServico _servico;

        public AcessoAppServico(IAcessoServico servico)
        {
            _servico = servico;
        }
        public ValidationResult Adicionar(Acesso acesso)
        {
            ValidationResult.Add(_servico.Adicionar(acesso));
            return ValidationResult;
        }
        public ValidationResult Atualizar(Acesso acesso)
        {
            ValidationResult.Add(_servico.Atualizar(acesso));
            return ValidationResult;
        }
        public ValidationResult Deletar(Acesso acesso)
        {
            ValidationResult.Add(_servico.Deletar(acesso));
            return ValidationResult;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public Acesso ObterPorId(int id)
        {
            return _servico.ObterPorId(id);
        }
        public IEnumerable<Acesso> ObterTodos()
        {
            return _servico.ObterTodos();
        }
        public IEnumerable<Acesso> ObterPor(object @where = null, object order = null)
        {
            var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            pg.Predicates.Add(Predicates.Field<Acesso>(f => f.Id, Operator.Eq, 7));
            return _servico.ObterPor(pg);
        }             
        public void SairCrm(string token)
        {
            _servico.AtualizarFimDeAcesso(token);
        }
    }
}
