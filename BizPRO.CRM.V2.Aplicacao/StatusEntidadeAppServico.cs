using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Dominio.Entidades;
using System.Linq;
using System;
using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class StatusEntidadeAppServico : IStatusEntidadeAppServico
    {
        private readonly IStatusEntidadeServico _statusEntidadeServico;
        private readonly IOcorrenciaServico _ocorrenciaServico;
        private readonly IAtividadeServico _atividadeServico;

        public StatusEntidadeAppServico(IStatusEntidadeServico statusEntidadeServico, IOcorrenciaServico ocorrenciaServico, IAtividadeServico atividadeServico)
        {
            _statusEntidadeServico = statusEntidadeServico;
            _ocorrenciaServico = ocorrenciaServico;
            _atividadeServico = atividadeServico;
        }
        public statusEntidadeViewModal CarregarStatusOcorrencia()
        {
            var statusEntidadeViewModal = new statusEntidadeViewModal
            {
                statusEntidade = _statusEntidadeServico.ObterStatusEntidadeOcorrencia()
            };
            return statusEntidadeViewModal;
        }
        public statusEntidadeViewModal CarregarStatusVendas()
        {
            var statusEntidadeViewModal = new statusEntidadeViewModal
            {
                statusEntidade = _statusEntidadeServico.ObterStatusEntidadeVendas()
            };
            return statusEntidadeViewModal;
        }
        public StatusEntidadeAlterarViewModel CarregarAlterarStatus(long? ocorrenciaId)
        {
            var ocorrencia = new Ocorrencia();
            var statusEntidade = new StatusEntidade();

            if (ocorrenciaId != null)
            {
                ocorrencia = _ocorrenciaServico.ObterPorId((long)ocorrenciaId);
                statusEntidade = _statusEntidadeServico.ObterPorId(ocorrencia.StatusEntidadesId);
            }

            //var ListaStatusEntidade = this._servicoStatusEntidade.ObterStatusEntidadeOcorrencia();
            //var ListaStatusEntidade = this._servicoStatusEntidade.AxaObterStatusLojista();
            //Carregar Somente os Status Vinculados
            var listaStatusEntidade = _statusEntidadeServico.ObterPorOcorrenciaTipoId(ocorrencia.OcorrenciasTiposId);

            if (!listaStatusEntidade.Any(w => w.finalizador))
            {
                ((List<StatusEntidade>)listaStatusEntidade).Add(_statusEntidadeServico.ObterStatusOcorrenciaFinalizadoraPadrao());
            }

            return new StatusEntidadeAlterarViewModel(statusEntidade, listaStatusEntidade, ocorrencia.Id);
        }

        //// Vou precisar Passar isso pro externo
        public StatusEntidadeAlterarViewModel AxaCarregarAlterarStatusLojista(long? ocorrenciaId)
        {
            var ocorrencia = new Ocorrencia();
            var statusEntidade = new StatusEntidade();

            if (ocorrenciaId != null)
            {
                ocorrencia = _ocorrenciaServico.ObterPorId((long)ocorrenciaId);
                statusEntidade = _statusEntidadeServico.ObterPorId(ocorrencia.StatusEntidadesId);
            }

            var listaStatusEntidade = _statusEntidadeServico.AxaObterStatusLojista();
            return new StatusEntidadeAlterarViewModel(statusEntidade, listaStatusEntidade, ocorrencia.Id);
        }
        public StatusEntidadeAlterarViewModel SalvarAlterarStatus(StatusEntidadeAlterarViewModel viewModel, string userId)
        {
            if (viewModel.StatusEntidadeId != null)
            {
                var statusEntidade = _statusEntidadeServico.ObterPorId((long)viewModel.StatusEntidadeId);

                if (statusEntidade != null)
                {
                    if (viewModel.OcorrenciaId != null)
                    {
                        if (statusEntidade.finalizador)
                        {
                            var atividadesOcorrencia = _atividadeServico.ObterNaoFinalizadasPorOcorrenciaId((long)viewModel.OcorrenciaId);

                            if (atividadesOcorrencia.Any())
                            {
                                viewModel.ValidationResult.Add(new ValidationError("Não é possível finalizar a Ocorrência, a mesma possui atividades em aberto."));
                                return viewModel;
                            }
                        }

                        var ocorrencia = _ocorrenciaServico.ObterPorId((long)viewModel.OcorrenciaId);
                        ocorrencia.StatusEntidadesId = (long)viewModel.StatusEntidadeId;
                        ocorrencia.AtualizadoEm = DateTime.Now;
                        ocorrencia.AtualizadoPorAspNetUserId = userId;

                        if (statusEntidade.finalizador)
                        {
                            ocorrencia.FinalizadoEm = DateTime.Now;
                            ocorrencia.FinalizadoPorUserId = userId;
                        }

                        _ocorrenciaServico.Atualizar(ocorrencia);
                    }
                }
            }

            return viewModel;
        }
        public StatusEntidadeAlterarViewModel CarregarAlterarStatusTroca(long? ocorrenciaId)
        {
            var ocorrencia = new Ocorrencia();
            var statusEntidade = new StatusEntidade();

            if (ocorrenciaId != null)
            {
                ocorrencia = _ocorrenciaServico.ObterPorId((long)ocorrenciaId);
                statusEntidade = _statusEntidadeServico.ObterPorId(ocorrencia.StatusEntidadesId);
            }

            var listaStatusEntidade = _statusEntidadeServico.ObterStatusEntidadeOcorrencia().Where(c => c.nome.Equals("Troca realizada") && c.ativo.Equals(true));
            return new StatusEntidadeAlterarViewModel(statusEntidade, listaStatusEntidade, ocorrencia.Id);
        }
    }
}
