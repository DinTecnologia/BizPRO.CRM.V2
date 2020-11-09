using System;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;
using System.Collections.Generic;
using System.Linq;
using DapperExtensions;


namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class IntegracaoControleServico : Servico<IntegracaoControle>, IIntegracaoControleServico
    {
        private readonly IIntegracaoControleRepositorio _repositorio;

        public IntegracaoControleServico(IIntegracaoControleRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<IntegracaoControle> ObterPorIdentificadorIntegracao(long id)
        {
            return _repositorio.ObterPorIdentificadorIntegracao(id);
        }

        public IEnumerable<IntegracaoControle> ObterClientesJaIntegrados(long? identificadorIntegracao)
        {
            return _repositorio.ObterClientesJaIntegrados(identificadorIntegracao);
        }

        public IEnumerable<IntegracaoControle> ObterContratosJaIntegrados(long? contratoId)
        {
            return _repositorio.ObterContratosJaIntegrados(contratoId);
        }

        //public IntegracaoControle ObterUltimoClienteIntegrado(long? pessoaFisicaId, long? pessoaJuridicaId)
        //{
        //    throw new System.NotImplementedException();
        //}

        public ValidationResult AtualizarIntegracaoControle(IntegracaoControle entidade)
        {
            var retorno = new ValidationResult();

            var integracaoControle = _repositorio.ObterPor(entidade.PessoaFisicaId, entidade.PessoaJuridicaId,
                entidade.ContratoId, entidade.TelefoneId, entidade.IdentificadorIntegracao);

            if (integracaoControle == null || integracaoControle.Id == 0)
            {
                try
                {
                    _repositorio.Adicionar(entidade);
                    integracaoControle = new IntegracaoControle();
                }
                catch (Exception ex)
                {
                    integracaoControle.ValidationResult.Add(new ValidationError(ex.Message));
                }

                retorno = integracaoControle.ValidationResult;
            }
            else
            {
                integracaoControle.UltimaAtualizacaoEm = DateTime.Now;
                _repositorio.Atualizar(integracaoControle);
            }

            return retorno;
        }

        public IntegracaoControle ObterUltimoControlePor(long? pessoaFisicaId, long? pessoaJuridicaId, long? contratoId)
        {
            var where = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };

            if (pessoaFisicaId.HasValue)
                where.Predicates.Add(Predicates.Field<IntegracaoControle>(f => f.PessoaFisicaId, Operator.Eq,
                    pessoaFisicaId));

            if (pessoaJuridicaId.HasValue)
                where.Predicates.Add(Predicates.Field<IntegracaoControle>(f => f.PessoaJuridicaId, Operator.Eq,
                    pessoaJuridicaId));

            if (contratoId.HasValue)
                where.Predicates.Add(Predicates.Field<IntegracaoControle>(f => f.ContratoId, Operator.Eq, contratoId));

            return _repositorio.ObterPor(where).OrderByDescending(x => x.UltimaAtualizacaoEm).FirstOrDefault();
        }

        public IntegracaoControle ObterDataUltimaAtualizacaoContrato(long pessoaFisicaId)
        {
            return _repositorio.ObterDataUltimaAtualizacaoContrato(pessoaFisicaId);
        }
    }
}
