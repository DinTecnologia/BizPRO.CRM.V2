using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ChatMensagemViewModel
    {
        public long Id { get; set; }
        public long ChatId { get; set; }

        [AllowHtml]
        public string mensagem { get; set; }

        public string sentido { get; set; }
        public string tipo { get; set; }
        public long? ArquivoID { get; set; }
        public DateTime criadoEm { get; set; }
        public string conectorCodigo { get; set; }
        public string dataHora { get; set; }
        public string statusMensagemID { get; set; }
    }

    public class ChatMensagemUraViewModel
    {
        public long Id { get; set; }
        public long? ChatUraId { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public List<ChatMensagemUraViewModel> Opcoes { get; set; }

        public ChatMensagemUraViewModel()
        {
            Opcoes = new List<ChatMensagemUraViewModel>();
        }

        public ChatMensagemUraViewModel(ChatUra chatUra)
        {
            Id = chatUra.Id;
            ChatUraId = chatUra.ChatUraId;
            Descricao = chatUra.Descricao;
            Ordem = chatUra.Ordem;
            Opcoes = new List<ChatMensagemUraViewModel>();

            if (chatUra.Opcoes == null) return;

            foreach (var opcao in chatUra.Opcoes)
            {
                Opcoes.Add(new ChatMensagemUraViewModel
                {
                    Id = opcao.Id,
                    ChatUraId = opcao.ChatUraId,
                    Descricao = string.Format("{0} - {1}", opcao.Ordem, opcao.Descricao),
                    Ordem = opcao.Ordem
                });
            }
        }
    }
}
