using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class PausaMapper : ClassMapper<Pausa>
    {
        public PausaMapper()
        {
            Table("Pausas");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.CanalIds).Column("CanalIds");
            Map(m => m.UsuarioId).Column("UsuarioId");
            Map(m => m.IniciadoEm).Column("IniciadoEm");
            Map(m => m.FinalizadoEm).Column("FinalizadoEm");
            Map(m => m.MotivoPausaId).Column("MotivoPausaId");
            Map(m => m.CriadoEm).Column("CriadoEm");
            Map(m => m.CriadoPor).Column("CriadoPor");
            Map(m => m.Ativo).Column("Ativo");
        }
    }
}
