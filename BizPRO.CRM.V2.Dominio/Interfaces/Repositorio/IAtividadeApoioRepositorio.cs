using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IAtividadeApoioRepositorio : IRepositorio<AtividadeApoio>
    {
        IEnumerable<AtividadeApoio> ObterPor(int? atividadeTipoId, DateTime? criadoEm, string criadoPor,
            int? statusAtividadeId, long? ocorrenciaId, long? contratoId, long? atendimentoId,
            DateTime? previsaoExecucao, long? pessoaFisicaId, long? pessoaJuridicaId, long? potencialClienteId,
            int? canalId, int? midiaId, string responsavel, int? filaId, string protocolo, int? situacaoId,
            bool? atividadeEmFila, int? departamentoId);
    }
}
