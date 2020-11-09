using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;


namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class OcorrenciaLocalTipoAtendimentoRepositorio : Repositorio<OcorrenciaLocalTipoAtendimento>,
        IOcorrenciaLocalTipoAtendimentoRepositorio
    {
        public OcorrenciaLocalTipoAtendimentoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public void DeletarOcorrenciasLocaisTipoAtendimentoPorOcorrenciaId(long ocorrenciaId)
        {
            var where = new DynamicParameters();
            where.Add("@OcorrenciaID", ocorrenciaId);
            ExecutarProcedimento("usp_front_del_OcorrenciasLocaisTipoAtendimento_PorOcorrenciaID", where);
        }
    }
}
