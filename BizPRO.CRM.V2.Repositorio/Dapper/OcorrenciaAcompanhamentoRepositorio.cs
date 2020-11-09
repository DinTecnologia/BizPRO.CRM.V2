using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Collections.Generic;
using Dapper;
using System;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class OcorrenciaAcompanhamentoRepositorio : Repositorio<OcorrenciaAcompanhamento>,
        IOcorrenciaAcompanhamentoRepositorio
    {
        public OcorrenciaAcompanhamentoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<OcorrenciaAcompanhamento> ObterAcompanhamentoPadrao(DateTime? dataInicio, DateTime? dataFinal,
            string criadoPorId, string responsavelId, bool? slaExcedido, string cliente, string status,
            long? ocorrenciaTipoId, long? departamentoId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@dataInicio", dataInicio);
            parametros.Add("@dataFinal", dataFinal);
            parametros.Add("@criadoPorId", string.IsNullOrEmpty(criadoPorId) ? null : criadoPorId);
            parametros.Add("@responsavelPorId", string.IsNullOrEmpty(responsavelId) ? null : responsavelId);
            parametros.Add("@slaExcedido", slaExcedido);
            parametros.Add("@cliente", string.IsNullOrEmpty(cliente) ? null : cliente);
            parametros.Add("@status", string.IsNullOrEmpty(status) ? null : status);
            parametros.Add("@ocorrenciaTipoId", ocorrenciaTipoId);
            parametros.Add("@departamentoId", departamentoId);

            return ObterPorProcedimento("usp_rpt_OcorrenciaAcompanhamento", parametros);
        }
    }
}
