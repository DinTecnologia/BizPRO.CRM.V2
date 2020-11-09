using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class TimelineApoioServico : ITimelineApoioServico
    {
        private readonly ITimelineApoioRepositorio _repositorio;
        private readonly ITarefaServico _servicoTarefa;
        private readonly IAnotacaoServico _servicoAnotacao;

        public TimelineApoioServico(ITimelineApoioRepositorio repositorio, ITarefaServico servicoTarefa,
            IAnotacaoServico servicoAnotacao)
        {
            this._repositorio = repositorio;
            this._servicoTarefa = servicoTarefa;
            this._servicoAnotacao = servicoAnotacao;
        }

        public IEnumerable<TimelineApoio> CarregarTimeline(long? pessoaFisicaId, long? pessoaJuridicaId)
        {
            var retorno = _repositorio.ObterPor(pessoaFisicaId, pessoaJuridicaId);

            if (retorno == null) return retorno;

            foreach (var item in retorno)
            {
                if (item.plaTipo == 5)
                {
                    item.Tarefas = _servicoTarefa.ObterPorOcorrencia((long)item.plaTipoID);
                    item.Anotacoes = _servicoAnotacao.ObterPorOcorrenciaId((long)item.plaTipoID);

                    if (item.Tarefas != null)
                        foreach (var tarefa in item.Tarefas)
                        {
                            tarefa.Anotacoes = _servicoAnotacao.ObterPorTarefaId(tarefa.Id);
                        }
                }
            }

            return retorno;
        }
    }
}
