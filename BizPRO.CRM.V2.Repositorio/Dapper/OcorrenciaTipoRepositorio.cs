using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Collections.Generic;
using Dapper;
using System;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class OcorrenciaTipoRepositorio : Repositorio<OcorrenciaTipo>, IOcorrenciaTipoRepositorio
    {
        public OcorrenciaTipoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<OcorrenciaTipo> ObterOcorrenciasPai()
        {
            return ObterPorProcedimento("usp_front_sel_ocorrenciasTipoPai", null);
        }

        public IEnumerable<OcorrenciaTipo> ObterPor(long ocorrenciasTiposPaiId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ocorrenciasTiposPaiID", ocorrenciasTiposPaiId);
            return ObterPorProcedimento("usp_front_sel_ocorrenciasTipo", parametros);
        }


        public IEnumerable<OcorrenciaTipo> ObterPrevisaoInicial(long ocorrenciaTipoId, DateTime? dataInicial)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@OcorrenciaTipoId", ocorrenciaTipoId);

            if (dataInicial.HasValue)
                parametros.Add("@DataInicio", dataInicial.Value);

            return ObterPorProcedimento("usp_front_sel_CalculoSLA", parametros);
        }
    }
}
