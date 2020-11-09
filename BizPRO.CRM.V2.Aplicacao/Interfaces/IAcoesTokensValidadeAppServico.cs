using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IAcoesTokensValidadeAppServico
    {
        AcoesTokensValidadeViewModel Adicionar(string userName);
        AcoesTokensValidadeViewModel Carregar(string token);
        AcoesTokensValidadeViewModel AtualizarToken(string token);
    }
}
