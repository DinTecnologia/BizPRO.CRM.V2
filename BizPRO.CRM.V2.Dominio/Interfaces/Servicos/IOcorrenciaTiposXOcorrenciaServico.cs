using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IOcorrenciaTiposXOcorrenciaServico : IServico<OcorrenciaTiposXOcorrencia> 
    {
        OcorrenciaTiposXOcorrencia ObterDadosOcorrenciaTiposXOcorrencia(long ocorrenciaId);
    }
}
