using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DapperExtensions;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Contexto.Mapeamento;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Dapper;
using Camadas.Infra.Dados.Contexto.Mapeamento;

namespace Camadas.Infra.Repositorio.Dapper.Comum
{
    public class Repositorio<TEntity> : IRepositorio<TEntity>, IDisposable where TEntity : class
    {
        public IDbConnection Conn { get; set; }

        public Repositorio(IDapperContexto context)
        {
            Conn = context.Connection;
            InicializaMapperDapper();
        }

        public static void InicializaMapperDapper()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] {typeof(ProdutoMapper).Assembly});
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] {typeof(TimelineApoioMapper).Assembly});
        }

        public dynamic Adicionar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return entity == null ? null : Conn.Insert(entity, transaction, commandTimeout);
        }

        public bool Atualizar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return entity != null && Conn.Update(entity, transaction, commandTimeout);
        }

        public bool Deletar(TEntity entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return entity != null && Conn.Delete(entity, transaction, commandTimeout);
        }

        //repositorio


        public TEntity ObterPorId(long id, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return Conn.Get<TEntity>(id, transaction, commandTimeout);
        }

        public IEnumerable<TEntity> ObterTodos(IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return Conn.GetList<TEntity>(null, null, transaction, commandTimeout);
        }

        public void ExecutarProcedimento(string nomeProcedimento, DynamicParameters parametros)
        {
            Conn.Execute(nomeProcedimento, parametros, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<TEntity> ObterPor(object @where = null, object order = null,
            IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return Conn.GetList<TEntity>(@where);
        }

        public IEnumerable<TEntity> ObterPorProcedimento(string nomeProcedimento, DynamicParameters parametros)
        {
            return Conn.Query<TEntity>(nomeProcedimento, parametros, commandType: CommandType.StoredProcedure).ToList();
        }

        public IEnumerable<dynamic> ObterPorProcedimentoDinamico(string nomeProcedimento, DynamicParameters parametros)
        {
            return Conn.Query<dynamic>(nomeProcedimento, parametros, commandType: CommandType.StoredProcedure).ToList();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
