using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IAtendimentoOcorrenciaRepositorio : IRepositorio<AtendimentoOcorrencia>
    {
        IEnumerable<AtendimentoOcorrencia> BuscarAtendimentoOcorrencia(long atendimentoId, long ocorrenciaId);
        IEnumerable<AtendimentoOcorrencia> ObterOcorrenciasVinculadasAoAtendimento(long atendimentoId);
    }
}
