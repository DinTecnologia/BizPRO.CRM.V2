using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface ITokenAcessoRapidoServico : IServico<TokenAcessoRapido>
    {
        TokenAcessoRapido ObterPorId(string id);
    }
}
