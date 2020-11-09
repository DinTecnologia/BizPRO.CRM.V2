using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IChatAppServico
    {
        ChatViewModel AdicionarAtendimento(string userId, string k);
        ChatViewModel AdicionarAtendimentoMessenger(string userId, string k);
        ChatViewModel BuscarMsg(long id);
        ChatMensagemUraViewModel BuscarChatUraPadrao(long atividadeId);
        ChatMensagemUraViewModel BuscarChatUra(long atividadeId, long chatUraId, int ordem);
        AtendimentoChatViewModel Carregar(long atividadeId, string usuarioId);
        ChatClienteViewModel RegistrarChatRequisicao(ChatClienteViewModel viewModel);
        long ObterEntidadeChatId();
        AtendimentoFormViewModel CarregarChat(long? chatId, long? atividadeId);
        bool ChatOnline(int? filaId);
        ICollection<ChatMensagem> ListarMensagens(long chatId);
        bool MensagemNaoLidaAgente(long chatId, string usuarioId);
    }
}