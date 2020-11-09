using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ChatMensagemServico : Servico<ChatMensagem>, IChatMensagemServico
    {
        private readonly IChatMensagemRepositorio _repositorio;

        public ChatMensagemServico(IChatMensagemRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<ChatMensagem> ObterMensagensPorConector(string conectorCli)
        {
            return _repositorio.ObterMensagensPorConector(conectorCli);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public ICollection<ChatMensagem> ObterMensagensChat(long chatId)
        {
            return _repositorio.ObterMensagensChat(chatId);
        }

        public ChatMensagem UltimaMensagemChat(long chatId)
        {
            return _repositorio.UltimaMensagemChat(chatId);
        }
    }
}
