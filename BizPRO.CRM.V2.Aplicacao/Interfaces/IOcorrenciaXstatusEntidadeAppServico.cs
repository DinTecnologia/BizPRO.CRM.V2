using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IOcorrenciaXstatusEntidadeAppServico
    {
        OcorrenciaXstatusEntidadeViewModel LIstarOcorrenciaXstatusEntidade(string userId, string inicio, string fim,
            string status, string cliente, long? ocorrenciaTipoId);
    }
}
