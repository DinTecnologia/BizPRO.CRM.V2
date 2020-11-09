using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class ProdutoAppServico : IProdutoAppServico
    {
        private readonly IProdutoServico _servicoProduto;
        private readonly IProdutoTipoServico _servicoTipoProduto;

        public ProdutoAppServico(IProdutoServico servicoProduto, IProdutoTipoServico servicoTipoProduto)
        {
            _servicoProduto = servicoProduto;
            _servicoTipoProduto = servicoTipoProduto;
        }

        public ProdutoFormViewModel Carregar()
        {
            var viewModel = new ProdutoFormViewModel();
            viewModel.ProdutoTipos = this._servicoTipoProduto.ObterProdutoTipoAtivo(null);

            return viewModel;
        }

        public IEnumerable<Produto> ObterProdutosPorContratoId(long contratoID)
        {
            return this._servicoProduto.ObterProdutoPorContratoId(contratoID);
        }

        public IEnumerable<Produto> ObterProdutoAtivo(int? idProduto)
        {
            return this._servicoProduto.ObterProdutoAtivo(idProduto);
        }

        public ProdutoFormViewModel ObterProdutoPorId(int idProduto)
        {
            Produto Produto = this._servicoProduto.ObterPorId(idProduto);
            ProdutoFormViewModel viewModel = new ProdutoFormViewModel();
            viewModel.Id = Produto.id;
            viewModel.codigo = Produto.codigo;
            viewModel.nome = Produto.nome;
            viewModel.criadoEm = Produto.criadoEm;
            viewModel.tipoProdutoID = Produto.tipoProdutoID;
            viewModel.Ativo = Produto.ativo;
            viewModel.descritivo = Produto.descritivo;
            viewModel.alteradoEm = Produto.alteradoEm;
            viewModel.ProdutoTipos = this._servicoTipoProduto.ObterProdutoTipoAtivo(null);
            viewModel.ProdutoTipo = this._servicoTipoProduto.ObterPorId(Produto.tipoProdutoID);

            return viewModel;
        }

        public ProdutoFormViewModel Edit(ProdutoFormViewModel viewModel)
        {
            var produto = new Produto
            {
                id = viewModel.Id,
                codigo = viewModel.codigo,
                nome = viewModel.nome,
                tipoProdutoID = viewModel.tipoProdutoID,
                criadoEm = (DateTime) viewModel.criadoEm,
                alteradoEm = DateTime.Now,
                ativo = viewModel.Ativo,
                descritivo = viewModel.descritivo
            };

            _servicoProduto.Atualizar(produto);

            return viewModel;
        }

        public ProdutoFormViewModel Create(ProdutoFormViewModel viewModel)
        {
            var Produto = new Produto
            {
                codigo = viewModel.codigo,
                nome = viewModel.nome,
                tipoProdutoID = viewModel.tipoProdutoID,
                criadoEm = DateTime.Now,
                ativo = true,
                descritivo = viewModel.descritivo,
                criadoPorUserID = viewModel.criadoPor
            };

            _servicoProduto.Adicionar(Produto);

            return viewModel;
        }
    }
}