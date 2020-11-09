using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class AnotacaoTipoMapper : ClassMapper<AnotacaoTipo>
    {
        public AnotacaoTipoMapper()
        {
            Table("AnotacoesTipos");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("nome");
            Map(m => m.Padrao).Column("padrao");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserId");
            Map(m => m.Ativo).Column("ativo");
        }
    }
}
