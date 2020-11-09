using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class OcorrenciaXstatusEntidadeApoioRepositorio : Repositorio<OcorrenciaXstatusEntidadeApoio>, IOcorrenciaXstatusEntidadeApoioRepositorio
    {
        public OcorrenciaXstatusEntidadeApoioRepositorio(IDapperContexto context)
            : base(context)
        {

        }
    }
}
