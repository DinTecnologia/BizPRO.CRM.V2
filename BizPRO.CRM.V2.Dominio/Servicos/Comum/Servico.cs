using System.Collections.Generic;
using System.Data;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Validacoes;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class Servico<TEntity> : IServico<TEntity> where TEntity : class
    {
        private readonly IRepositorio<TEntity> _repositorio;
        private readonly ValidationResult _validationResult;

        public Servico(IRepositorio<TEntity> repositorio)
        {
            _repositorio = repositorio;
            _validationResult = new ValidationResult();
        }

        protected ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }

        public ValidationResult Adicionar(TEntity entity, IDbTransaction transaction = null,
            int? commandTimeout = default(int?))
        {
            if (!_validationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            var adicionou = _repositorio.Adicionar(entity);
            if (adicionou == null)
                _validationResult.Add(
                    new ValidationError(
                        "A Entidade que você está tentando gravar está nula, por favor tente novamente!" + entity));
            return _validationResult;
        }

        public ValidationResult Atualizar(TEntity entity, IDbTransaction transaction = null,
            int? commandTimeout = default(int?))
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            var atualizar = _repositorio.Atualizar(entity);
            if (!atualizar)
                _validationResult.Add(
                    new ValidationError(
                        "A Entidade que você está tentando atualizar está nula, por favor tente novamente! Nome: " +
                        entity));
            return _validationResult;
        }

        public ValidationResult Deletar(TEntity entity, IDbTransaction transaction = null,
            int? commandTimeout = default(int?))
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var deletou = _repositorio.Deletar(entity);
            if (!deletou)
                _validationResult.Add(
                    new ValidationError(
                        "A Entidade que você está tentando deletar está nula, por favor tente novamente! Nome: " +
                        entity));
            return _validationResult;
        }

        public TEntity ObterPorId(long id, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return _repositorio.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos(IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var entidade = _repositorio.ObterTodos().ToList();
            _repositorio.Dispose();
            return entidade;
        }

        public IEnumerable<TEntity> ObterPor(object @where = null, object order = null,
            IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return _repositorio.ObterPor(@where);
        }

        public IEnumerable<TEntity> ObterPorProcedimento(string nomeProcedimento, Dapper.DynamicParameters parametros)
        {
            return _repositorio.ObterPorProcedimento(nomeProcedimento, parametros);
        }
    }
}
