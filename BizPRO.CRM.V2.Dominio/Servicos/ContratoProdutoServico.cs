using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ContratoProdutoServico : Servico<ContratoProduto>, IContratoProdutoServico
    {
        private readonly IContratoProdutoRepositorio _repositorio;

        public ContratoProdutoServico(IContratoProdutoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<ContratoProduto> ListarContratoProduto(long? contratoId, long? produtoId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@contratoID", contratoId);
            parametros.Add("@produtoID", produtoId);

            var listaCampoDinamico = _repositorio.ListarContratoProduto(
                "usp_front_sel_ObterContratoProdutoPorEntidade", parametros);

            return listaCampoDinamico;
        }
    }
}
