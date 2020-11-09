using System.Collections.Generic;
using System.Data;
using System;
using BizPRO.CRM.V2.Dominio.Entidades;
using Dapper;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IServico<TEntity> where TEntity : class
    {
        ValidationResult Adicionar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        ValidationResult Atualizar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        ValidationResult Deletar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        TEntity ObterPorId(long id, IDbTransaction transaction = null, int? commandTimeout = null);
        IEnumerable<TEntity> ObterTodos(IDbTransaction transaction = null, int? commandTimeout = null);

        IEnumerable<TEntity> ObterPor(object where = null, object order = null, IDbTransaction transaction = null,
            int? commandTimeout = null);

        IEnumerable<TEntity> ObterPorProcedimento(string nomeProcedimento, DynamicParameters parametros);
    }

    public interface IServicoEntity : IDisposable
    {
        Usuario Adicionar(Usuario usuario);
        Usuario ObterPorId(long id);
        Usuario ObterPorEmail(string email);
        IEnumerable<Usuario> ObterTodos();
        Usuario Atualizar(Usuario cliente);
        void Remover(long id);
    }
}
