using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class MidiaMapper : ClassMapper<Midia>
    {
        public MidiaMapper()
        {
            Table("Midias");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("nome");
            Map(m => m.CanaisId).Column("CanaisID");
            Map(m => m.Ativo).Column("Ativo");
            Map(m => m.CriadoPorAspNetUserId).Column("criadoPorAspNetUserID");
            Map(m => m.CriadoEm).Column("criadoEm");
        }
    }
}
