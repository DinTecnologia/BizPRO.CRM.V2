using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class ChatMapper : ClassMapper<Chat>
    {
        public ChatMapper()
        {
            Table("Chat");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.AtividadeId).Column("AtividadeId");
            Map(m => m.ChatSolicitacaoId).Column("ChatSolicitacaoId");
            Map(m => m.ConexaoClienteId).Column("ConexaoClienteId");
            Map(m => m.ConexaoOperadorId).Column("ConexaoOperadorId");
            Map(m => m.Tipo).Column("Tipo");
        }
    }
}
