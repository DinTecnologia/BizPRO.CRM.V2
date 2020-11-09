using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AtividadeApoioServico : IAtividadeApoioServico
    {
        private readonly IAtividadeApoioRepositorio _repositorio;

        public AtividadeApoioServico(IAtividadeApoioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<AtividadeApoio> ObterPor(int? atividadeTipoId, DateTime? criadoEm, string criadoPor,
            int? statusAtividadeId, long? ocorrenciaId, long? contratoId, long? atendimentoId,
            DateTime? previsaoExecucao, long? pessoaFisicaId, long? pessoaJuridicaId, long? potencialClienteId,
            int? canalId, int? midiaId, string responsavel, int? filaId, string protocolo, int? situacaoId,
            bool? atividadeEmFila, int? departamentoId)
        {
            return _repositorio.ObterPor(atividadeTipoId, criadoEm, criadoPor, statusAtividadeId, ocorrenciaId,
                contratoId, atendimentoId, previsaoExecucao, pessoaFisicaId, pessoaJuridicaId, potencialClienteId,
                canalId, midiaId, responsavel, filaId, protocolo, situacaoId, atividadeEmFila, departamentoId);
        }
    }
}
