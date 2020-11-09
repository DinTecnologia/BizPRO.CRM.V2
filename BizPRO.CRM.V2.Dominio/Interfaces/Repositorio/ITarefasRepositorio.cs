using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface ITarefaRepositorio : IRepositorio<Tarefa>
    {
        void AtualizarDados(Tarefa tarefas);
        IEnumerable<Tarefa> ObterPorOcorrencia(long ocorrenciaId);
        Tarefa BuscarPorAtividadeId(long atividadeId);
    }
}
