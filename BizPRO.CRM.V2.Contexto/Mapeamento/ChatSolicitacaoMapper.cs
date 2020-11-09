using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class ChatSolicitacaoMapper : ClassMapper<ChatSolicitacao>
    {
        public ChatSolicitacaoMapper()
        {
            Table("ChatSolicitacao");
            Map(m => m.Id).Column("Id").Key(KeyType.Identity);
            Map(m => m.CampanhaId).Column("CampanhaId");
            Map(m => m.FilaId).Column("FilaId");
            Map(m => m.CriadoEm).Column("CriadoEm");
            Map(m => m.SaidoEm).Column("SaidoEm");
            Map(m => m.AtendidoEm).Column("AtendidoEm");
            Map(m => m.ConexaoClienteId).Column("ConexaoClienteId");
            Map(m => m.AtendimentoId).Column("AtendimentoId");
            Map(m => m.Nome).Column("Nome");
            Map(m => m.Documento).Column("Documento");
        }
    }
}
