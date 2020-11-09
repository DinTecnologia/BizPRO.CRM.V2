using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IChatMensagemRepositorio:IRepositorio<ChatMensagem>
    {
        IEnumerable<ChatMensagem> ObterMensagensPorConector(string conectorCli);
        ICollection<ChatMensagem> ObterMensagensChat(long chatId);
        ChatMensagem UltimaMensagemChat(long chatId);
    }
}