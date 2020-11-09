using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IStatusEntidadeRepositorio : IRepositorio<StatusEntidade>
    {
        StatusEntidade AxaObterStatusNovoLaudo();
        IEnumerable<StatusEntidade> AxaObterStatusLaudo();
        IEnumerable<StatusEntidade> AxaObterStatusLojista();
        IEnumerable<StatusEntidade> ObterPor(string entidadeValida, bool? padrao, bool? finalizador);
        IEnumerable<StatusEntidade> ObterPorOcorrenciaTipoId(long ocorrenciaTipoId);
        StatusEntidade ObterStatusOcorrenciaFinalizadoraPadrao();
    }
}
