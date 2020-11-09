using System;
using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class VendasAppServico : IVendasAppServico
    {
        private readonly IVendasServico _servicoVendas;
        private readonly IVendasProdutosServico _servicoVendasProdutos;
        private readonly IClienteAppServico _servicoCliente;
        private readonly IStatusEntidadeServico _servicoStatusEntidade;


        public VendasAppServico(IVendasServico servicoVendas,
            IVendasProdutosServico servicoVendasProdutos,
            IClienteAppServico servicoCliente,
            IStatusEntidadeServico servicoStatusEntidade)
        {
            _servicoVendas = servicoVendas;
            _servicoVendasProdutos = servicoVendasProdutos;
            _servicoCliente = servicoCliente;
            _servicoStatusEntidade = servicoStatusEntidade;
        }

        public List<VendasFormViewModel> PesquisarVendas(string dataInicial, string dataFinal, string valorInicial,
            string valorFinal, string nomeCliente, string _status)
        {
            var _filtroVendas = _servicoVendas.ListarVendas();
            List<VendasFormViewModel> _vendas = new List<VendasFormViewModel>();
            DateTime dataIni;
            DateTime dataFim;

            if (DateTime.TryParse(dataInicial, out dataIni))
            {

                _filtroVendas = _filtroVendas.Where(x => x.criadoEm >= dataIni);
            }

            if (DateTime.TryParse(dataFinal, out dataFim))
            {
                _filtroVendas =
                    _filtroVendas.Where(x => x.criadoEm <= dataFim.AddHours(29).AddMinutes(59).AddSeconds(59));
            }

            if (valorInicial != null)
            {
                valorInicial = valorInicial.Replace('.', ',');
                _filtroVendas = _filtroVendas.Where(x => x.valorTotal >= Convert.ToDecimal(valorInicial));
            }

            if (valorFinal != "0")
            {
                valorFinal = valorFinal.Replace('.', ',');
                _filtroVendas = _filtroVendas.Where(x => x.valorTotal <= Convert.ToDecimal(valorFinal));
            }


            foreach (var item in _filtroVendas)
            {
                _vendas.Add(new VendasFormViewModel
                {

                    id = item.id,
                    criadoEm = item.criadoEm,
                    valorTotal = item.valorTotal,
                    qtdItens = item.qtdItens,
                    ListasDePrecosID = item.ListasDePrecosID,
                    Cliente = _servicoCliente.Carregar(item.PessoasFisicasID, item.PessoasJuridicasID, false),
                    StatusEntidadeID = item.StatusEntidadeID,
                    StatusEntidade = this._servicoStatusEntidade.ObterStatusEntidadeVendas()
                });
            }


            if (nomeCliente != null)
            {
                _vendas = _vendas.Where(x => x.Cliente.Nome.ToUpper().Contains(nomeCliente.ToUpper())).ToList();
            }

            if (_status != "")
            {
                _vendas = _vendas.Where(x => _status.Contains(x.StatusEntidadeID.ToString())).ToList();
            }


            return _vendas;
        }

        public Vendas SalvarVendas(VendasFormViewModel VendaView)
        {


            Vendas venda = new Vendas();
            venda.ListasDePrecosID = VendaView.ListasDePrecosID;
            venda.qtdItens = VendaView.qtdItens;
            venda.valorTotal = VendaView.valorTotal;
            venda.criadoEm = DateTime.Now;
            venda.criadoPorUserID = VendaView.criadoPorUserID;
            venda.PessoasFisicasID = VendaView.PessoasFisicasID;
            venda.PessoasJuridicasID = VendaView.PessoasJuridicasID;



            venda = this._servicoVendas.SalvarVendas(venda);

            foreach (var item in VendaView.ListaVendasProduto)
            {
                VendasProdutos vp = new VendasProdutos();
                vp.criadoEm = DateTime.Now;
                vp.criadoPorUserID = VendaView.criadoPorUserID;
                vp.valorVenda = item.valorVenda;
                vp.valorSugerido = item.valorSugerido;
                vp.qtd = item.qtd;
                vp.VendasID = venda.id;
                vp.valorDaLinha = 0;
                vp.ProdutosID = item.ProdutosID;
                vp.ListasDePrecosID = VendaView.ListasDePrecosID;
                this._servicoVendasProdutos.Adicionar(vp);
            }

            return venda;
        }


        public Vendas EditarVendas(VendasFormViewModel VendaView)
        {


            Vendas venda = new Vendas();
            venda.id = VendaView.id;
            venda.ListasDePrecosID = VendaView.ListasDePrecosID;
            venda.qtdItens = VendaView.qtdItens;
            venda.valorTotal = VendaView.valorTotal;
            venda.criadoEm = VendaView.criadoEm;
            venda.alteradoPorUserID = venda.alteradoPorUserID;
            venda.alteradoEm = DateTime.Now;
            venda.alteradoPorUserID = VendaView.alteradoPorUserID;
            venda.PessoasFisicasID = VendaView.PessoasFisicasID;
            venda.PessoasJuridicasID = VendaView.PessoasJuridicasID;
            venda.StatusEntidadeID = VendaView.StatusEntidadeID;



            venda = this._servicoVendas.EditarVendas(venda);

            this._servicoVendasProdutos.RemoverVendaProduto(venda.id);

            foreach (var item in VendaView.ListaVendasProduto)
            {
                VendasProdutos vp = new VendasProdutos();
                vp.criadoEm = DateTime.Now;
                vp.criadoPorUserID = VendaView.criadoPorUserID;
                vp.valorVenda = item.valorVenda;
                vp.valorSugerido = item.valorSugerido;
                vp.qtd = item.qtd;
                vp.VendasID = venda.id;
                vp.valorDaLinha = 0;
                vp.ProdutosID = item.ProdutosID;
                vp.ListasDePrecosID = VendaView.ListasDePrecosID;
                this._servicoVendasProdutos.Adicionar(vp);
            }

            return venda;
        }

        public VendasFormViewModel ObterVendaPorId(long idVenda)
        {
            var retorno = this._servicoVendas.ObterVendaPorId(idVenda);
            VendasFormViewModel VendaVW = new VendasFormViewModel();
            VendaVW.id = retorno.id;
            VendaVW.alteradoEm = retorno.alteradoEm;
            VendaVW.alteradoPorUserID = retorno.alteradoPorUserID;
            VendaVW.criadoEm = retorno.criadoEm;
            VendaVW.criadoPorUserID = retorno.criadoPorUserID;
            VendaVW.PessoasFisicasID = retorno.PessoasFisicasID;
            VendaVW.PessoasJuridicasID = retorno.PessoasJuridicasID;
            VendaVW.valorTotal = retorno.valorTotal;
            VendaVW.qtdItens = retorno.qtdItens;
            VendaVW.ListasDePrecosID = retorno.ListasDePrecosID;
            VendaVW.StatusEntidadeID = retorno.StatusEntidadeID;
            VendaVW.StatusEntidade = this._servicoStatusEntidade.ObterStatusEntidadeVendas();


            return VendaVW;
        }

        public List<VendasProdutosFormViewModel> ObterVendaProdutosPorId(long idVenda)
        {
            List<VendasProdutosFormViewModel> Lista = new List<VendasProdutosFormViewModel>();
            var obterProdutos = this._servicoVendasProdutos.ObterTodos().Where(x => x.VendasID == idVenda);

            foreach (var item in obterProdutos)
            {
                Lista.Add(new VendasProdutosFormViewModel
                {
                    id = item.id,
                    valorSugerido = item.valorSugerido,
                    VendasID = item.VendasID,
                    valorVenda = item.valorVenda,
                    qtd = item.qtd,
                    ListasDePrecosID = item.ListasDePrecosID,
                    ProdutosID = item.ProdutosID
                });

            }

            return Lista;

        }

        public List<VendasFormViewModel> ListarVendas()
        {
            var retorno = _servicoVendas.ListarVendas();
            List<VendasFormViewModel> _vendas = new List<VendasFormViewModel>();

            foreach (var item in retorno)
            {
                _vendas.Add(new VendasFormViewModel
                {

                    id = item.id,
                    criadoEm = item.criadoEm,
                    valorTotal = item.valorTotal,
                    qtdItens = item.qtdItens,
                    ListasDePrecosID = item.ListasDePrecosID,
                    StatusEntidadeID = item.StatusEntidadeID,
                    StatusEntidade = this._servicoStatusEntidade.ObterStatusEntidadeVendas(),
                    Cliente = this._servicoCliente.Carregar(item.PessoasFisicasID, item.PessoasJuridicasID, false)
                });
            }

            return _vendas;
        }
    }
}
