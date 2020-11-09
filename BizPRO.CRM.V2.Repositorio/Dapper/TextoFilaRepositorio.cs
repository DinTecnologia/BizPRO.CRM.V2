using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using BizPRO.CRM.V2.Contexto.Interfaces;
using System.Collections.Generic;
using DapperExtensions;
using System;
using Dapper;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class TextoFilaRepositorio : Repositorio<TextoFila>, ITextoFilaRepositorio
    {
        public TextoFilaRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public void DeletarTodosAtivo(long textoId, string usuarioId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@TextoId", textoId);
            parametros.Add("@UsuarioId", usuarioId);
            ExecutarProcedimento("usp_front_del_TextoFila", parametros);
        }        

        public IEnumerable<TextoFila> ObterPorTextoId(long id)
        {
            var where = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            where.Predicates.Add(Predicates.Field<TextoFila>(f => f.Ativo, Operator.Eq, true));
            where.Predicates.Add(Predicates.Field<TextoFila>(f => f.TextoId, Operator.Eq, id));
            return ObterPor(where);
        }
    }
}
