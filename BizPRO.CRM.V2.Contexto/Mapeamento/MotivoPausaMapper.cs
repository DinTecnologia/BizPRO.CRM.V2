using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class PausaMotivoMapper : ClassMapper<PausaMotivo>
    {
        public PausaMotivoMapper()
        {
            Table("PausaMotivos");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("Nome");
            Map(m => m.Tempo).Column("Tempo");
            Map(m => m.CanalIds).Column("CanalIds");
            Map(m => m.CriadoEm).Column("CriadoEm");
            Map(m => m.CriadoPor).Column("CriadoPor");
            Map(m => m.AtualizadoEm).Column("AtualizadoEm");
            Map(m => m.AtualizadoPor).Column("AtualizadoPor");
            Map(m => m.Ativo).Column("Ativo");
        }
    }
}
