using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao
{

    public class AbordagemAppServico : AppServicoDapper, IAbordagemAppServico
    {
        private readonly IOcorrenciaServico _servicoOcorrencia;
        private readonly IPessoaJuridicaServico _servicoPessoaJuridica;
        private readonly IPessoaFisicaServico _servicoPessoaFisica;
        private readonly ILigacaoServico _servicoLigacao;

        public AbordagemAppServico(IOcorrenciaServico servicoOcorrencia, IPessoaJuridicaServico servicoPessoaJuridica,
            IPessoaFisicaServico servicoPessoaFisica, ILigacaoServico servicoLigacao)
        {
            _servicoOcorrencia = servicoOcorrencia;
            _servicoPessoaJuridica = servicoPessoaJuridica;
            _servicoPessoaFisica = servicoPessoaFisica;
            _servicoLigacao = servicoLigacao;
        }

        public AbordagemViewModel Carregar(AbordagemViewModel viewModel)
        {
            #region Carregando Dados do Cliente

            if (viewModel.PessoaJuridicaId != null)
            {
                var pessoaJuridica = _servicoPessoaJuridica.ObterPorId((long)viewModel.PessoaJuridicaId);
                viewModel.Nome = pessoaJuridica.NomeFantasia;
                viewModel.Documento = pessoaJuridica.Cnpj;
                viewModel.Email = pessoaJuridica.EmailPrincipal;
            }
            else if (viewModel.PessoaFisicaId != null)
            {
                var pessoaFisica = _servicoPessoaFisica.ObterPorId((long)viewModel.PessoaFisicaId);
                viewModel.Nome = pessoaFisica.Nome;
                viewModel.Documento = pessoaFisica.Cpf;
                viewModel.Email = null;
            }

            #endregion

            viewModel.OcorrenciaLista =
                _servicoOcorrencia.Obter(new Ocorrencia(viewModel.PessoaFisicaId, viewModel.PessoaJuridicaId));

            if (viewModel.LigacaoId != null)
            {
                viewModel.Telefone = _servicoLigacao.ObterPorId((long)viewModel.LigacaoId).NumeroOriginal;
            }

            return viewModel;
        }
    }
}
