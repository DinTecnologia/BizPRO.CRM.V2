using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class AcoesTokensValidadeMapper: ClassMapper<AcoesTokensValidade>
    {
        public AcoesTokensValidadeMapper()
        {
            Table("AcoesTokensValidade");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Acao).Column("acao");
            Map(m => m.Token).Column("token");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.UtilizadoEm).Column("utilizadoEm");
            Map(m => m.ValidadePrevistaEmHoras).Column("validadePrevistaEmHoras");
            Map(m => m.ValoresDaAcao).Column("valoresDaAcao");

        }
    }
}
