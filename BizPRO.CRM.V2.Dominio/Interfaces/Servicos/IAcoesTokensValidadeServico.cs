using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IAcoesTokensValidadeServico : IServico<AcoesTokensValidade>
    {
        AcoesTokensValidade CarregarPorToken(string token);
        AcoesTokensValidade AdicionarToken(AcoesTokensValidade acoesTokensValidade);
        AcoesTokensValidade AtualizarToken(string token);
    }
}
