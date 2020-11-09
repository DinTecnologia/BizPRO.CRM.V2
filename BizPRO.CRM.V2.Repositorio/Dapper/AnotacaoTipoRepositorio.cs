using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Collections.Generic;
using Dapper;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class AnotacaoTipoRepositorio : Repositorio<AnotacaoTipo>, IAnotacaoTipoRepositorio
    {
        public AnotacaoTipoRepositorio(IDapperContexto context)
            : base(context)
        {


        }

        public IEnumerable<AnotacaoTipo> ObterPorOcorrenciaTipoId(long ocorrenciaTipoId)
        {
            var Parametros = new DynamicParameters();
            Parametros.Add("@ocorrenciaTipoId", ocorrenciaTipoId);
            return ObterPorProcedimento("usp_front_sel_AnotacoesTiposPorOcorrenciaTipoId", Parametros);
        }
    }
}
