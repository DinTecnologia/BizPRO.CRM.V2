using System.Linq;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using DomainValidation.Validation;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class StatusAtividadeAppServico : IStatusAtividadeAppServico
    {
        private readonly IStatusAtividadeServico _statusAtividadeServico;
        private readonly IAtividadeServico _atividadeServico;
        private readonly IAtendimentoServico _atendimentoServico;
        private readonly StatusAtendimentoViewModel _statusAtendimentoViewModal = new StatusAtendimentoViewModel();

        public StatusAtividadeAppServico(IStatusAtividadeServico statusAtividadeServico,
            IAtividadeServico atividadeServico, IAtendimentoServico atendimentoServico)
        {
            _statusAtividadeServico = statusAtividadeServico;
            _atividadeServico = atividadeServico;
            _atendimentoServico = atendimentoServico;
        }

        public StatusAtendimentoViewModel Carregar(long atividadeId)
        {
            _statusAtendimentoViewModal.AtividadeId = atividadeId;
            var atividade = _atividadeServico.ObterPorId(atividadeId);
            _statusAtendimentoViewModal.StatusAtividade = _statusAtividadeServico.ObterStatusAtividadeTarefa();
            _statusAtendimentoViewModal.Descricao =
                _statusAtividadeServico.ObterPorId(atividade.StatusAtividadeId).Descricao;
            return _statusAtendimentoViewModal;
        }

        public StatusAtendimentoViewModel CarregarStatusAtividadeTipos(long atividadeId, string tipos)
        {
            _statusAtendimentoViewModal.AtividadeId = atividadeId;
            var atividade = _atividadeServico.ObterPorId(atividadeId);
            _statusAtendimentoViewModal.StatusAtividade =
                _statusAtividadeServico.ObterTodos().Where(c => c.Ativo == true && c.AtividadesValidas.Contains(tipos));
            _statusAtendimentoViewModal.Descricao =
                _statusAtividadeServico.ObterPorId(atividade.StatusAtividadeId).Descricao;
            return _statusAtendimentoViewModal;
        }

        public StatusAtendimentoViewModel CarregarObjeto(string tipo)
        {
            _statusAtendimentoViewModal.StatusAtividade =
                _statusAtividadeServico.ObterTodos().Where(c => c.Ativo == true && c.AtividadesValidas.Contains(tipo));
            return _statusAtendimentoViewModal;
        }

        public ValidationResult AtualizarStatusAtividade(long atividadeId, int statusAtividadeId, string userId,
            int? midiaId,
            long? atendimentoId)
        {
            var retorno = new ValidationResult();

            if (atendimentoId.HasValue && atendimentoId > 0)
            {
                var statusAtividade = _statusAtividadeServico.ObterPorId(statusAtividadeId);

                if (!string.IsNullOrEmpty(statusAtividade.EntidadeNecessaria))
                {
                    var podeAtualizar =
                        _statusAtividadeServico.VerificarEntidadeRequeridaAtendimento((long)atendimentoId,
                            statusAtividadeId);

                    if (!podeAtualizar)
                    {
                        retorno.Add(
                            new ValidationError(
                                string.Format(
                                    "Não é possível alterar o status desse atendimento, pois ainda não houve criação e/ou interação de uma: {0}",
                                    statusAtividade.EntidadeNecessaria)));
                        return retorno;
                    }
                }

                if (!string.IsNullOrEmpty(statusAtividade.EntidadeNaoNecessaria))
                {
                    var podeAtualizar =
                        _statusAtividadeServico.VerificarEntidadeNaoRequeridaAtendimento((long)atendimentoId,
                            statusAtividadeId);

                    if (!podeAtualizar)
                    {
                        retorno.Add(
                            new ValidationError(
                                string.Format(
                                    "Não é possível alterar o status desse atendimento, pois houve criação e/ou interação de uma: {0}",
                                    statusAtividade.EntidadeNaoNecessaria)));
                        return retorno;
                    }
                }

                if (statusAtividade.TempoMaximoAtividadeEmMinutos.HasValue)
                {
                    var podeAtualizar = _statusAtividadeServico.VerificarTempoAtividade(atividadeId, statusAtividadeId);
                    if (!podeAtualizar)
                    {
                        retorno.Add(
                            new ValidationError(
                                string.Format(
                                    "Não é possível alterar o status desse atendimento para {0}, pois já foi ultrapassado o tempo máximo para essa classificação.",
                                    statusAtividade.Descricao)));
                        return retorno;
                    }
                }

                if (statusAtividade.StatusAtividadeIdRequerida.HasValue)
                {
                    var podeAtualizar = _statusAtividadeServico.VerificarStatusAtividadeRequerida(atividadeId, statusAtividadeId);
                    if (!podeAtualizar)
                    {
                        retorno.Add(
                            new ValidationError(
                                string.Format(
                                    "Não é possível alterar o status desse atendimento para {0}, pois o status atual não condiz com o status requerido para essa alteração.",
                                    statusAtividade.Descricao)));
                        return retorno;
                    }
                }

                if (midiaId.HasValue && midiaId > 0)
                    _atendimentoServico.AtualizarMidia((long)atendimentoId, (int)midiaId);
            }

            _atividadeServico.AtualizarStatus(atividadeId, statusAtividadeId, userId, midiaId);

            return retorno;
        }

        public StatusAtendimentoViewModel ObterStatusAtividadePorId(int statusAtividadeId)
        {
            var retorno = new StatusAtendimentoViewModel();
            var statusEntity = _statusAtividadeServico.ObterPorId(statusAtividadeId);
            if (statusEntity == null) return null;
            retorno.StatusId = statusEntity.Id;
            retorno.Descricao = statusEntity.Descricao;
            retorno.Ativo = statusEntity.Ativo;
            retorno.FinalizaAtendimento = statusEntity.FinalizaAtendimento;
            retorno.GerarEntidade = statusEntity.GerarEntidade;
            retorno.EntidadeNecessaria = statusEntity.EntidadeNecessaria;
            retorno.AtividadesValidas = statusEntity.AtividadesValidas;
            retorno.StatusPadrao = statusEntity.StatusPadrao;
            retorno.FinalizaAtividade = statusEntity.FinalizaAtividade;
            return retorno;
        }

        public IEnumerable<StatusAtividade> Obter(int canal, string sentido, bool? padrao)
        {
            return _statusAtividadeServico.ObterPor(canal, sentido, padrao);
        }
    }
}
