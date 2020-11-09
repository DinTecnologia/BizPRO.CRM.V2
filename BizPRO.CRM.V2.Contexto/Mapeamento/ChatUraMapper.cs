using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class ChatUraMapper : ClassMapper<ChatUra>
    {
        public ChatUraMapper()
        {
            Table("ChatUras");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.ChatUraId).Column("chatUraId");
            Map(m => m.ProximaUraId).Column("proximaUraId");
            Map(m => m.Descricao).Column("descricao");
            Map(m => m.Padrao).Column("padrao");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserId");
            Map(m => m.Titulo).Column("titulo");
            Map(m => m.Ordem).Column("ordem");
        }
    }
}
