using System;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class TarefaAppServico : ITarefaAppServico
    {
        private readonly IAnotacaoServico _anotacaoServico;
        private readonly IAnotacoesApoioServico _anotacaoApoioServico;
        private readonly IStatusAtividadeServico _statusAtividadeServico;
        private readonly ITarefaAtividadeOcorrenciaServico _tarefaAtividadeOcorrenciaServico;
        private readonly ITarefaServico _tarefaServico;
        private readonly IAtividadeServico _atividadeServico;
        private readonly IFilaServico _filaServico;

        public TarefaAppServico
        (
            IAnotacaoServico anotacoesServico
            , IAnotacoesApoioServico anotacaoApoioServico
            , IStatusAtividadeServico statusAtividadeServico
            , ITarefaAtividadeOcorrenciaServico tarefaAtividadeOcorrenciaServico
            , ITarefaServico tarefaServico
            , IAtividadeServico atividadeServico
            , IFilaServico filaServico
        )
        {
            _anotacaoServico = anotacoesServico;
            _anotacaoApoioServico = anotacaoApoioServico;
            _statusAtividadeServico = statusAtividadeServico;
            _tarefaAtividadeOcorrenciaServico = tarefaAtividadeOcorrenciaServico;
            _tarefaServico = tarefaServico;
            _atividadeServico = atividadeServico;
            _filaServico = filaServico;
        }

        public TarefaViewModel SalvarAnotacao(string anotacao, string userID, long atividadeId)
        {
            var retorno = new TarefaViewModel
            {
                Anotacoes = new Anotacao()
                {
                    AtividadeId = atividadeId,
                    CriadoPorUserId = userID,
                    Texto = anotacao,
                    CriadoEm = DateTime.Now
                }
            };

            _anotacaoServico.Adicionar(retorno.Anotacoes);
            retorno.AnotacoesApoio = _anotacaoApoioServico.ObterAnotacoesApoio(null, atividadeId, null, null, null);
            return retorno;
        }

        public TarefaViewModel CarregarTela(string userId, long atividadeId)
        {
            var retorno = new TarefaViewModel
            {
                AnotacaoViewModal =
                {
                    AnotacoesApoio = _anotacaoApoioServico.ObterAnotacoesApoio(null, atividadeId, null,
                        null, null)
                },
                StatusAtividade = _statusAtividadeServico.ObterTodos(),
                TarefaAtividadeOcorrencia =
                    _tarefaAtividadeOcorrenciaServico.ObterTarefaAtividadeOcorrenciaApoio(atividadeId).FirstOrDefault()
            };

            retorno.TarefaAtividadeOcorrencia.CalcularTempo();
            _tarefaServico.AtualizarDados(new Tarefa(retorno.TarefaAtividadeOcorrencia.tarefaID, userId,
                retorno.TarefaAtividadeOcorrencia.AtividadeID));
            retorno.AtividadeId = atividadeId;
            var atividade = _atividadeServico.ObterPorId(atividadeId);

            if (atividadeId > 0)
                retorno.PodeEditar = string.IsNullOrEmpty(atividade.ResponsavelPorUserId)
                    ? atividade.CriadoPorUserId == userId
                    : atividade.ResponsavelPorUserId == userId;

            return retorno;
        }

        public TarefaViewModel CarregarTarefa(string userId, long atividadeId)
        {
            var retorno = new TarefaViewModel
            {
                AnotacaoViewModal =
                {
                    AnotacoesApoio = _anotacaoApoioServico.ObterAnotacoesApoio(null, atividadeId, null,
                        null, null)
                },
                StatusAtividade = _statusAtividadeServico.ObterTodos(),
                TarefaAtividadeOcorrencia =
                    _tarefaAtividadeOcorrenciaServico.ObterTarefaAtividadeOcorrenciaApoio(atividadeId).FirstOrDefault(),
                AtividadeId = atividadeId
            };

            var atividade = _atividadeServico.ObterPorId(atividadeId);
            retorno.PodeEditar = string.IsNullOrEmpty(atividade.ResponsavelPorUserId)
                ? atividade.CriadoPorUserId == userId
                : atividade.ResponsavelPorUserId == userId;

            return retorno;
        }

        public TarefaFormViewModel CarregarAdicionar(long? ocorrenciaId, long? atividadeDeOrigemId, long? pessoaFisicaId,
            long? pessoaJuridicaId, long? potencialClienteId, long? atendimentoId)
        {
            var filas = _filaServico.ObterPor(null, null, true, null, null, null);
            return new TarefaFormViewModel(filas, ocorrenciaId, atividadeDeOrigemId, pessoaFisicaId, pessoaJuridicaId,
                potencialClienteId, atendimentoId);
        }

        public TarefaFormViewModel Salvar(TarefaFormViewModel viewModel, string userId)
        {
            var tarefa = _tarefaServico.Adicionar(viewModel.Titulo, viewModel.Descricao, viewModel.FilaId,
                viewModel.OcorrenciaId, viewModel.AtividadeDeOrigemId, viewModel.PessoaFisicaId,
                viewModel.PessoaJuridicaId, viewModel.PotencialClienteId, viewModel.AtendimentoId, viewModel.ContratoId,
                userId, viewModel.PrevisaoDeExecucao);
            viewModel.ValidationResult = tarefa.ValidationResult;
            viewModel.TarefaId = tarefa.Id;
            return viewModel;
        }
    }
}
