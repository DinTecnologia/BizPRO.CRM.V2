using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IAnotacaoRepositorio : IRepositorio<Anotacao>
    {
        IEnumerable<Anotacao> ObterPorTarefaId(long id);
        IEnumerable<Anotacao> ObterPorOcorrenciaId(long id);

        IEnumerable<Anotacao> ObterPor(long? ocorrenciaId, long? atividadeId, long? pessoaFisicaId,
            long? pessoaJuridicaId);
    }
}
