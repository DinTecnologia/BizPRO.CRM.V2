using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System;
using Dapper;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        dynamic Adicionar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        bool Atualizar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        bool Deletar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null);
        TEntity ObterPorId(long id, IDbTransaction transaction = null, int? commandTimeout = null);
        IEnumerable<TEntity> ObterTodos(IDbTransaction transaction = null, int? commandTimeout = null);
        IEnumerable<TEntity> ObterPor(object where = null, object order = null, IDbTransaction transaction = null, int? commandTimeout = null);
        IEnumerable<TEntity> ObterPorProcedimento(string nomeProcedimento, DynamicParameters parametros);
        void ExecutarProcedimento(string nomeProcedimento, DynamicParameters parametros);
        void Dispose();
    }
    public interface IRepositorioEntity<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(long id);
        IEnumerable<TEntity> ObterTodos();
        TEntity Atualizar(TEntity obj);
        void Remover(long id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterPorProcedimento(string nomeProcedimento, Expression<Func<TEntity, bool>> parametros);
    }
}
