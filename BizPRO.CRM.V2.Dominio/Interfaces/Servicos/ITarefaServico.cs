using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface ITarefaServico
    {
        void AtualizarDados(Tarefa tarefa);
        IEnumerable<Tarefa> ObterPorOcorrencia(long ocorrenciaId);
        Tarefa BuscarPorAtividadeId(long atividadeId);

        Tarefa Adicionar(string titulo, string descricao, int? filaId, long? ocorrenciaId, long? atividadeDeOrigemId,
            long? pessoaFisicaId, long? pessoaJuridicaId, long? potencialClienteId, long? atendimentoId,
            long? contratoId, string userId, DateTime? previsaoExecucao);
    }
}
