using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using System;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IChatMensagemServico : IServico<ChatMensagem>, IDisposable
    {
        IEnumerable<ChatMensagem> ObterMensagensPorConector(string conectorCli);
        ICollection<ChatMensagem> ObterMensagensChat(long chatId);
        ChatMensagem UltimaMensagemChat(long chatId);
    }
}