using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class VendasProdutosServico : Servico<VendasProdutos>, IVendasProdutosServico
    {
        private readonly IVendasProdutosRepositorio _repositorio;

        public VendasProdutosServico(IVendasProdutosRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public void RemoverVendaProduto(long idVenda)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@VendasID", idVenda);
            _repositorio.ExecutarProcedimento("usp_front_del_VendasProdutos", parametros);
        }
    }
}
