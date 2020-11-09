using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AtendimentoOcorrenciaServico : Servico<AtendimentoOcorrencia>, IAtendimentoOcorrenciaServico
    {
        private readonly IAtendimentoOcorrenciaRepositorio _repositorio;

        public AtendimentoOcorrenciaServico(IAtendimentoOcorrenciaRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adicionar(long atendimentoId, long ocorrenciaId)
        {
            var atendimentoOcorrencias = _repositorio.BuscarAtendimentoOcorrencia(atendimentoId, ocorrenciaId);
            if (atendimentoOcorrencias.Any())
                return;

            _repositorio.Adicionar(new AtendimentoOcorrencia(ocorrenciaId, atendimentoId));
        }

        public bool PossuiVinculo(long atendimentoId, long ocorrenciaId)
        {
            var atendimentoOcorrencias = _repositorio.BuscarAtendimentoOcorrencia(atendimentoId, ocorrenciaId);
            return atendimentoOcorrencias.Any();
        }

        public IEnumerable<AtendimentoOcorrencia> ObterOcorrenciasVinculadasAoAtendimento(long atendimentoId)
        {
            return _repositorio.ObterOcorrenciasVinculadasAoAtendimento(atendimentoId);
        }

        
    }
}
