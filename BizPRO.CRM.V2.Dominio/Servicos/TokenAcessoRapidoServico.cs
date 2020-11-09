using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class TokenAcessoRapidoServico : Servico<TokenAcessoRapido>, ITokenAcessoRapidoServico
    {
        private readonly ITokenAcessoRapidoRepositorio _repositorio;        

        public TokenAcessoRapidoServico(ITokenAcessoRapidoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public TokenAcessoRapido ObterPorId(string id)
        {
            return _repositorio.ObterPorId(id);
        }
    }
}
