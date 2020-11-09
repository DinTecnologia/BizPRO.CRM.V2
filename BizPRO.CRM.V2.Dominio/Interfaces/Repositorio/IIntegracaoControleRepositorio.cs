using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IIntegracaoControleRepositorio : IRepositorio<IntegracaoControle>
    {
        IEnumerable<IntegracaoControle> ObterPorIdentificadorIntegracao(long id);
        IEnumerable<IntegracaoControle> ObterClientesJaIntegrados(long? identificadorIntegracao);
        IEnumerable<IntegracaoControle> ObterContratosJaIntegrados(long? contratoId);

        IntegracaoControle ObterPor(long? pessoaFisiciaId, long? pessoaJuridicaId, long? contratoId, long? telefoneId,
            long? identificadorIntegracao);

        IntegracaoControle ObterDataUltimaAtualizacaoContrato(long pessoaFisicaId);
    }
}
