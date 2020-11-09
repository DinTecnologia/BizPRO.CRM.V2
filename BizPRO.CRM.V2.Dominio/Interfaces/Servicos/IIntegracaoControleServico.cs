using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IIntegracaoControleServico : IServico<IntegracaoControle>
    {
        IEnumerable<IntegracaoControle> ObterPorIdentificadorIntegracao(long id);
        IEnumerable<IntegracaoControle> ObterClientesJaIntegrados(long? identificadorIntegracao);
        IEnumerable<IntegracaoControle> ObterContratosJaIntegrados(long? contratoId);
        //IntegracaoControle ObterUltimoClienteIntegrado(long? pessoaFisicaId, long? pessoaJuridicaId);
        ValidationResult AtualizarIntegracaoControle(IntegracaoControle entidade);
        IntegracaoControle ObterUltimoControlePor(long? pessoaFisicaId, long? pessoaJuridicaId, long? contratoId);
        IntegracaoControle ObterDataUltimaAtualizacaoContrato(long pessoaFisicaId);
    }
}
