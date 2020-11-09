using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IAnotacoesApoioServico : IServico<AnotacoesApoio>
    {
        IEnumerable<AnotacoesApoio> ObterAnotacoesApoio(long? ocorrenciaId, long? atividadeId, long? pessoaFisicaId,
            long? pessoaJuridicaId, long? potenciaisClienteId);
    }
}
