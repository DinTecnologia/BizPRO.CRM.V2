using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class ContratoAppServico : AppServicoDapper, IContratoAppServico
    {
        private readonly IContratoServico _contratoServico;
        private readonly IProdutoServico _produtoServico;
        private readonly IStatusEntidadeServico _statusEntidadeServico;
        private readonly IProdutoTipoServico _produtoTipoServico;
        readonly IViewDinamicaAppServico _viewDinamicaAppServico;

        public ContratoAppServico(IContratoServico contratoServico, IProdutoServico produtoServico,
            IStatusEntidadeServico statusEntidadeServico, IProdutoTipoServico servicoProdutoTipo,
            IViewDinamicaAppServico viewDinamicaAppServico)
        {
            _contratoServico = contratoServico;
            _produtoServico = produtoServico;
            _statusEntidadeServico = statusEntidadeServico;
            _produtoTipoServico = servicoProdutoTipo;
            _viewDinamicaAppServico = viewDinamicaAppServico;
        }

        public ContratoViewModel ObterPorId(long contratoId)
        {
            var contratoDetalhe = _contratoServico.ObterContratoDetalhe(contratoId);
            var viewDinamicaModel = _viewDinamicaAppServico.Carregar("CONTRATOS ", "padrão", null, contratoId, false);
            return new ContratoViewModel(contratoDetalhe, viewDinamicaModel);

            //var contrato = _contratoServico.ObterPorId(contratoId);
            //var statusEntidade = _statusEntidadeServico.ObterPorId(contrato.StatusEntidadeId);

            //var listaProduto = _produtoServico.ObterProdutoPorContratoId(contratoId);
            //var viewDinamicaModel = _viewDinamicaAppServico.Carregar("CONTRATOS ", "padrão", null, contratoId, false);
            //return new ContratoViewModel(contrato, listaProduto, statusEntidade, viewDinamicaModel);
        }

        public IEnumerable<ContratoListaViewModel> ObterContratosPorCliente(long? pessoaFisicaId, long? pessoaJuridicaId, long? atendimentoId)
        {
            var retorno = new List<ContratoListaViewModel>();
            var contratos = _contratoServico.ObterContratosPorCliente(pessoaFisicaId, pessoaJuridicaId, 10);
            if (contratos == null) return retorno;

            foreach (var contrato in contratos)
            {
                contrato.Produtos = _produtoServico.ObterProdutoPorContratoId(contrato.Id);
                retorno.Add(new ContratoListaViewModel(contrato, atendimentoId));
            }
            return retorno;
        }

        public IEnumerable<ContratoListaViewModel> ListarContratos()
        {
            var retorno = new List<ContratoListaViewModel>();
            var contratos = _contratoServico.ObterTodos();

            if (contratos.Any())
                foreach (var contrato in contratos)
                {
                    retorno.Add(new ContratoListaViewModel(contrato, null));
                }

            return retorno;
        }

        public ContratoFormViewModel NovoContrato(long? pessoaFisicaId, long? pessoaJuridicaId)
        {
            var viewDinamicaModel = _viewDinamicaAppServico.Carregar("CONTRATOS ", "padrão", null, null, true);
            var listaProdutoTipo = _produtoTipoServico.ObterTodos().OrderBy(x => x.nome);
            return new ContratoFormViewModel(pessoaFisicaId, pessoaJuridicaId, listaProdutoTipo, viewDinamicaModel,
                new List<Produto>());
        }

        public DomainValidation.Validation.ValidationResult Adicionar(ContratoFormViewModel model, string usuarioId)
        {
            var contratoProdutos = new List<ContratoProduto>();
            if (model.ProdutoId.HasValue)
                contratoProdutos.Add(new ContratoProduto((long) model.ProdutoId, 0));

            var retorno = _contratoServico.AdicionarNovoContrato(model.CriadoPorUserId, model.NumeroContrato,
                model.ValorContrato, model.ValorDesconto, model.ClientePessoaFisicaId, model.ClientePessoaJuridicaId,
                model.DataInicio, model.DataTermino, model.TipoContrato, model.ContratoPaiId, model.StatusEntidadeId,
                model.Apelido, model.DataEncerramento, contratoProdutos);

            if (retorno != null)
            {
                if (model.ViewDinamica != null)
                {
                    model.ViewDinamica.ChaveEntidadeId = retorno.Id;
                    _viewDinamicaAppServico.Atualizar(model.ViewDinamica,usuarioId);
                }
            }

            return retorno.ValidationResult;
        }

        public IEnumerable<Produto> ObterProdutos(long produtoTipoId)
        {
            return _produtoServico.ObterProdutoPorTipoId(produtoTipoId);
        }
    }
}