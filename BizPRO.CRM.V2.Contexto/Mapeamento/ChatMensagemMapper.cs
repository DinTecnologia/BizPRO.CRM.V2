using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class ChatMensagemMapper : ClassMapper<ChatMensagem>
    {
        public ChatMensagemMapper()
        {
            Table("ChatMensagens");
            Map(m => m.Id).Column("Id").Key(KeyType.Identity);
            Map(m => m.ChatId).Column("ChatId");
            Map(m => m.Mensagem).Column("Mensagem");
            Map(m => m.Tipo).Column("Tipo");
            Map(m => m.ArquivoId).Column("ArquivoId");
            Map(m => m.CriadoEm).Column("CriadoEm");
            Map(m => m.LidoEm).Column("LidoEm");
            Map(m => m.StatusMensagemId).Column("StatusMensagemId");
            Map(m => m.AtividadeParteEnvolvidaId).Column("AtividadeParteEnvolvidaId");
            Map(m => m.Nome).Column("Nome");
        }
    }
}
