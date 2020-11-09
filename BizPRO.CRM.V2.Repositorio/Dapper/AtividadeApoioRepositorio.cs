using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class AtividadeApoioRepositorio : Repositorio<AtividadeApoio>, IAtividadeApoioRepositorio
    {
        public AtividadeApoioRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<AtividadeApoio> ObterPor(int? atividadeTipoId, DateTime? criadoEm, string criadoPor,
            int? statusAtividadeId, long? ocorrenciaId, long? contratoId, long? atendimentoId,
            DateTime? previsaoExecucao, long? pessoaFisicaId, long? pessoaJuridicaId, long? potencialClienteId,
            int? canalId, int? midiaId, string responsavel, int? filaId, string protocolo, int? situacaoId,
            bool? atividadeEmFila, int? departamentoId)
        {
            var parametros = new DynamicParameters();

            if (atividadeTipoId.HasValue)
                parametros.Add("@atividadeTipoId", atividadeTipoId);

            if (criadoEm.HasValue)
                parametros.Add("@criadoEm", criadoEm);

            if (!string.IsNullOrEmpty(criadoPor))
                parametros.Add("@criadoPor", criadoPor);

            if (statusAtividadeId.HasValue && statusAtividadeId > 0)
                parametros.Add("@statusAtividadeId", statusAtividadeId);

            if (ocorrenciaId.HasValue && ocorrenciaId > 0)
                parametros.Add("@ocorrenciaId", ocorrenciaId);

            if (contratoId.HasValue && contratoId > 0)
                parametros.Add("@contratoId", contratoId);

            if (atendimentoId.HasValue && atendimentoId > 0)
                parametros.Add("@atendimentoId", atendimentoId);

            if (previsaoExecucao.HasValue)
                parametros.Add("@previsaoExecucao", previsaoExecucao);

            if (pessoaFisicaId.HasValue && pessoaFisicaId > 0)
                parametros.Add("@pessoaFisicaId", pessoaFisicaId);

            if (pessoaJuridicaId.HasValue && pessoaJuridicaId > 0)
                parametros.Add("@pessoaJuridicaId", pessoaJuridicaId);

            if (potencialClienteId.HasValue && potencialClienteId > 0)
                parametros.Add("@potencialClienteId", potencialClienteId);

            if (canalId.HasValue && canalId > 0)
                parametros.Add("@canalId", canalId);

            if (midiaId.HasValue && midiaId > 0)
                parametros.Add("@midiaId", midiaId);

            if (!string.IsNullOrEmpty(responsavel))
                parametros.Add("@responsavel", responsavel);

            if (filaId.HasValue && filaId > 0)
                parametros.Add("@filaId", filaId);

            if (!string.IsNullOrEmpty(protocolo))
                parametros.Add("@protocolo", protocolo);

            if (situacaoId.HasValue && situacaoId > 0)
                parametros.Add("@situacaoId", situacaoId);

            if (atividadeEmFila.HasValue)
                parametros.Add("@atividadeEmFila", atividadeEmFila);

            if (departamentoId.HasValue)
                parametros.Add("@departamentoId", departamentoId);

            return ObterPorProcedimento("usp_front_sel_Atividades_Filtro_Generico", parametros);
        }
    }
}
