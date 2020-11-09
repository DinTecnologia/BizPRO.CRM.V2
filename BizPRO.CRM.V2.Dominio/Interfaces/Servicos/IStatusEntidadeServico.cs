using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IStatusEntidadeServico
    {
        IEnumerable<StatusEntidade> ObterStatusEntidadeNovaOcorrencia();
        StatusEntidade ObterPorId(long id);
        IEnumerable<StatusEntidade> ObterStatusEntidadeOcorrencia();
        IEnumerable<StatusEntidade> ObterStatusEntidadeVendas();
        StatusEntidade AxaObterStatusEntidadeNovoLaudo();
        IEnumerable<StatusEntidade> AxaObterStatusEntidadeLaudo();
        IEnumerable<StatusEntidade> AxaObterStatusLojista();
        StatusEntidade ObterStatusEntidadeNovoContrato();
        IEnumerable<StatusEntidade> ObterPorOcorrenciaTipoId(long ocorrenciaTipoId);
        StatusEntidade ObterStatusOcorrenciaFinalizadoraPadrao();
    }
}
