using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class TarefaAtividadeOcorrenciaServico : Servico<TarefaAtividadeOcorrencia>,
        ITarefaAtividadeOcorrenciaServico
    {
        private readonly ITarefaAtividadeOcorrenciaRepositorio _tarefaAtividadeOcorrenciaRepositorio;
        private DynamicParameters _parametros = null;

        public TarefaAtividadeOcorrenciaServico(
            ITarefaAtividadeOcorrenciaRepositorio tarefaAtividadeOcorrenciaRepositorio)
            : base(tarefaAtividadeOcorrenciaRepositorio)
        {
            _tarefaAtividadeOcorrenciaRepositorio = tarefaAtividadeOcorrenciaRepositorio;
        }

        public IEnumerable<TarefaAtividadeOcorrencia> ObterTarefaAtividadeOcorrenciaApoio(long atividadeId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@atividadeID", atividadeId);
            return _tarefaAtividadeOcorrenciaRepositorio.ObterPorProcedimento("usp_front_TarefaAtividadeOcorrencia",
                _parametros);
        }
    }
}
