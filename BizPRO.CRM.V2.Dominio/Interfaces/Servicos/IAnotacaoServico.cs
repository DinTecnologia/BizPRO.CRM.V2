using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IAnotacaoServico : IServico<Anotacao>
    {
        Anotacao AdicionarAnotacao(Anotacao anotacao);
        IEnumerable<Anotacao> ObterPorOcorrenciaId(long id);
        IEnumerable<Anotacao> ObterPor(long? ocorrenciaId, long? atividadeId, long? pessoaFisicaId, long? pessoaJuridicaId);
        IEnumerable<Anotacao> ObterPorTarefaId(long id);
    }
}
