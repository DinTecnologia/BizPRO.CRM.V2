using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;
using DapperExtensions;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ProdutoServico : Servico<Produto>, IProdutoServico
    {
        private readonly IProdutoRepositorio _repositorio;

        public ProdutoServico(IProdutoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Produto> ObterProdutoAtivo(long? idProduto)
        {
            return _repositorio.ObterProdutoAtivo(idProduto);
        }

        public IEnumerable<Produto> ObterProdutoPorContratoId(long contratoId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@contratoID", contratoId);
            return _repositorio.ObterPorProcedimento("usp_front_sel_produtosPorContratoID", parametros);
        }

        public IEnumerable<Produto> ObterProdutoPorTipoId(long produtoTipoId)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<Produto>(f => f.tipoProdutoID, Operator.Eq, produtoTipoId));
            where.Predicates.Add(Predicates.Field<Produto>(f => f.ativo, Operator.Eq, true));

            return _repositorio.ObterPor(where);
        }
    }
}
