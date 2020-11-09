using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class VendasServico : Servico<Vendas>, IVendasServico
    {
        private readonly IVendasRepositorio _repositorio;
        private readonly DynamicParameters _parametros = null;

        public VendasServico(IVendasRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Vendas> ListarVendas()
        {
            return _repositorio.ObterPorProcedimento("usp_front_sel_Vendas", _parametros);
        }

        public Vendas ObterVendaPorId(long idVenda)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ID", idVenda);
            return _repositorio.ObterPorProcedimento("usp_front_sel_VendasPorID", parametros).FirstOrDefault();
        }

        public Vendas SalvarVendas(Vendas venda)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@PessoasFisicasID", venda.PessoasFisicasID);
            parametros.Add("@PessoasJuridicasID", venda.PessoasJuridicasID);
            parametros.Add("@criadoPorUserID", venda.criadoPorUserID);
            parametros.Add("@valorTotal", venda.valorTotal);
            parametros.Add("@qtdItens", venda.qtdItens);
            parametros.Add("@listaPrecoID", venda.ListasDePrecosID);
            return _repositorio.ObterPorProcedimento("usp_front_ins_vendas", parametros).FirstOrDefault();
        }

        public Vendas EditarVendas(Vendas venda)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ID", venda.id);
            parametros.Add("@PessoasFisicasID", venda.PessoasFisicasID);
            parametros.Add("@PessoasJuridicasID", venda.PessoasJuridicasID);
            parametros.Add("@alteradoPorUserID", venda.alteradoPorUserID);
            parametros.Add("@valorTotal", venda.valorTotal);
            parametros.Add("@qtdItens", venda.qtdItens);
            parametros.Add("@listaPrecoID", venda.ListasDePrecosID);
            parametros.Add("@StatusID", venda.StatusEntidadeID);
            return _repositorio.ObterPorProcedimento("usp_front_upd_vendas", parametros).FirstOrDefault();
        }
    }
}
