using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ChatSolicitacaoServico : Servico<ChatSolicitacao>, IChatSolicitacaoServico
    {
        private readonly IChatSolicitacaoRepositorio _repositorio;

        public ChatSolicitacaoServico(IChatSolicitacaoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
