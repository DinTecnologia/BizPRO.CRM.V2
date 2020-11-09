using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class TarefaServico : ITarefaServico
    {
        private readonly ITarefaRepositorio _repositorio;
        private readonly IUsuarioServico _usuarioServico;
        private readonly IAtividadeServico _atividadeServico;
        private readonly IAtividadeFilaServico _atividadeFilaServico;

        public TarefaServico(ITarefaRepositorio repositorio, IUsuarioServico usuarioServico,
            IAtividadeServico atividadeServico, IAtividadeFilaServico atividadeFilaServico)
        {
            _repositorio = repositorio;
            _usuarioServico = usuarioServico;
            _atividadeServico = atividadeServico;
            _atividadeFilaServico = atividadeFilaServico;
        }

        public void AtualizarDados(Tarefa tarefa)
        {
            _repositorio.AtualizarDados(tarefa);
        }

        public IEnumerable<Tarefa> ObterPorOcorrencia(long ocorrenciaId)
        {
            return _repositorio.ObterPorOcorrencia(ocorrenciaId);
        }

        public Tarefa BuscarPorAtividadeId(long atividadeId)
        {
            return _repositorio.BuscarPorAtividadeId(atividadeId);
        }

        public ValidationResult Adicionar(Tarefa entidade, int? filaId)
        {
            var Retorno = new ValidationResult();

            if (!entidade.IsValid())
                return entidade.ValidationResult;

            if (!entidade.ValidationResult.IsValid)
                return entidade.ValidationResult;

            var Id = _repositorio.Adicionar(entidade);

            if (Id != null && filaId.HasValue)
                Retorno = _atividadeFilaServico.Adicionar(new AtividadeFila(entidade.AtividadeId, (int) filaId, null));

            return Retorno;
        }

        public Tarefa Adicionar(string titulo, string descricao, int? filaId, long? ocorrenciaId,
            long? atividadeDeOrigemId, long? pessoaFisicaId, long? pessoaJuridicaId, long? potencialClienteId,
            long? atendimentoId, long? contratoId, string userId, DateTime? previsaoExecucao)
        {
            var retorno = new Tarefa();

            if (string.IsNullOrEmpty(userId))
            {
                var usuarioAdm = _usuarioServico.ObterPorEmail("sistemas@bizpro.com.br");
                if (usuarioAdm != null)
                    userId = usuarioAdm.Id;
                else
                {
                    retorno.ValidationResult.Add(
                        new ValidationError(
                            "Não foi informado o usuario (Criado Por) e também não possui usuario padrão cadastrado (sistemas@bizpro.com.br)"));
                    return retorno;
                }
            }

            var atividade = _atividadeServico.AdicionarAtividadeTarefa(userId, ocorrenciaId, contratoId, atendimentoId,
                titulo, descricao, pessoaFisicaId, pessoaJuridicaId, potencialClienteId, null, null,
                filaId.HasValue ? null : userId, atividadeDeOrigemId, filaId.HasValue ? null : userId, previsaoExecucao);

            if (!atividade.ValidationResult.IsValid)
            {
                retorno.ValidationResult = atividade.ValidationResult;
                return retorno;
            }

            var tarefa = new Tarefa(userId, descricao, atividade.Id);

            if (tarefa.ValidationResult.IsValid)
                retorno.ValidationResult = Adicionar(tarefa, filaId);

            return tarefa;
        }
    }
}
