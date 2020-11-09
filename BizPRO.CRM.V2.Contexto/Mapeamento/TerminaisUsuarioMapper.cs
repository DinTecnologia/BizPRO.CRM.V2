using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class TerminaisUsuarioMapper : ClassMapper<TerminaisUsuario>
    {
        public TerminaisUsuarioMapper()
        {
            Table("TerminaisUsuario");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.NumeroTerminal).Column("numeroTerminal");
            Map(m => m.Agente).Column("agente");
            Map(m => m.AtivarScreenPopUp).Column("ativarScreenPopUP");
            Map(m => m.UserId).Column("UserID");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.AlteradoEm).Column("alteradoEm");
            Map(m => m.AlteradoPorUserId).Column("alteradoPorUserID");
        }
    }
}
