using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class AnotacaoAppServico : AppServicoDapper, IAnotacaoAppServico
    {
        private readonly IOcorrenciaServico _servicoOcorrencia;
        private readonly IAnotacaoServico _servicoAnotacao;
        private readonly IAnotacoesApoioServico _servicoAnotacoesApoio;
        private readonly IAtividadeServico _servicoAtividade;
        private readonly IAtendimentoOcorrenciaServico _servicoAtendimentoOcorrencia;
        private readonly IAnotacaoTipoServico _anotacaoTipoServico;

        public AnotacaoAppServico(IOcorrenciaServico servicoOcorrencia,
            IAnotacaoServico servicoAnotacao, IAnotacoesApoioServico servicoAnotacoesApoio,
            IAtividadeServico servicoAtividade, IAtendimentoOcorrenciaServico servicoAtendimentoOcorrencia,
            IAnotacaoTipoServico anotacaoTipoServico)
        {
            _servicoOcorrencia = servicoOcorrencia;
            _servicoAnotacao = servicoAnotacao;
            _servicoAnotacoesApoio = servicoAnotacoesApoio;
            _servicoAtividade = servicoAtividade;
            _servicoAtendimentoOcorrencia = servicoAtendimentoOcorrencia;
            _anotacaoTipoServico = anotacaoTipoServico;
        }

        public IEnumerable<AnotacoesViewForm> ObterPor(long? ocorrenciaId, long? atividadeId, long? pessoaFisicaId,
            long? pessoaJuridicaId, long? potenciaisClienteId)
        {
            var viewModel = new List<AnotacoesViewForm>();
            var listaAnotacaoApoio = _servicoAnotacoesApoio.ObterAnotacoesApoio(ocorrenciaId, atividadeId,
                pessoaFisicaId, pessoaJuridicaId, potenciaisClienteId);

            if (listaAnotacaoApoio == null) return viewModel;

            viewModel.AddRange(
                listaAnotacaoApoio.Select(anotacaoApoio => new AnotacoesViewForm(anotacaoApoio)));

            return viewModel;
        }

        public AnotacaoFormViewModel CarregarAdicionarAnotacao(long? ocorrenciaId, long? atividadeId)
        {
            var retorno = new AnotacaoFormViewModel();
            if (ocorrenciaId != null)
            {
                var ocorrencia = _servicoOcorrencia.ObterPorId((long) ocorrenciaId);

                if (ocorrencia != null)
                {
                    retorno.OcorrenciaId = ocorrencia.Id;
                    retorno.PessoaFisicaId = ocorrencia.PessoaFisicaId;
                    retorno.PessoaJuridicaId = ocorrencia.PessoaJuridicaId;
                    retorno.AnotacaoTipos =
                        new SelectList(_anotacaoTipoServico.ObterOcorrenciaTipoId(ocorrencia.OcorrenciasTiposId), "id",
                            "nome");
                }
            }
            else if (atividadeId != null)
            {
                var atividade = _servicoAtividade.ObterPorId((long) atividadeId);
                if (atividade != null)
                {
                    retorno.OcorrenciaId = atividade.OcorrenciaId;
                    retorno.PessoaFisicaId = atividade.PessoasFisicasId;
                    retorno.PessoaJuridicaId = atividade.PessoasJuridicasId;
                    retorno.PotenciaisClienteId = atividade.PotenciaisClientesId;
                    retorno.AnotacaoTipos = new SelectList(_anotacaoTipoServico.ObterPadrao(), "id", "nome");
                }
            }

            return retorno;
        }

        public AnotacaoFormViewModel Adicionar(long? ocorrenciaId, long? atividadeId, long? pessoaFisicaId,
            long? pessoaJuridicaId, long? potenciaisClienteId, long? atendimentoId)
        {
            IEnumerable<AnotacaoTipo> listaAnotacaoTipo = new List<AnotacaoTipo>();

            if (ocorrenciaId.HasValue)
            {
                var ocorrencia = _servicoOcorrencia.ObterPorId((long) ocorrenciaId);

                if (ocorrencia != null)
                {
                    listaAnotacaoTipo = _anotacaoTipoServico.ObterOcorrenciaTipoId(ocorrencia.OcorrenciasTiposId);
                }
            }
            else
                listaAnotacaoTipo = _anotacaoTipoServico.ObterPadrao();

            return new AnotacaoFormViewModel(ocorrenciaId, atividadeId, pessoaFisicaId, pessoaJuridicaId,
                potenciaisClienteId, atendimentoId, new SelectList(listaAnotacaoTipo, "id", "nome"));
        }

        public AnotacaoFormViewModel Salvar(AnotacaoFormViewModel viewModel)
        {
            var anotacao = new Anotacao(viewModel.Texto, viewModel.CriarPorUserId, viewModel.OcorrenciaId,
                viewModel.AtividadeId, viewModel.PessoaFisicaId, viewModel.PessoaJuridicaId,
                viewModel.PotenciaisClienteId, viewModel.AcompanhamentoOcorrencia, viewModel.AnotacaoTipoId);
            var resultado = _servicoAnotacao.Adicionar(anotacao);

            if (resultado.IsValid)
            {
                if (viewModel.SolicitarLigacao)
                {
                    resultado = _servicoAtividade.AdicionarSolicitacaoLigacaoCorretor((long) viewModel.OcorrenciaId,
                        viewModel.CriarPorUserId, viewModel.Texto);
                }

                /// Adicionado em 18/09/17, troca de regra no vínculo da Ocorrência com o Atendimento.                
                if (viewModel.AtendimentoId != null && viewModel.OcorrenciaId != null)
                {
                    _servicoAtendimentoOcorrencia.Adicionar((long) viewModel.AtendimentoId,
                        (long) viewModel.OcorrenciaId);
                }
            }

            viewModel.ValidationResult = resultado;
            return viewModel;
        }


        public bool OcorrenciaFinalizada(long ocorrenciaId)
        {
            return _servicoOcorrencia.OcorrenciaFinalizada(ocorrenciaId);
        }
    }
}