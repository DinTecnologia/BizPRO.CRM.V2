using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class TokenAcessoRapidoMapper : ClassMapper<TokenAcessoRapido>
    {
        public TokenAcessoRapidoMapper()
        {
            Table("TokensAcessoRapido");
            //Map(m => m.id).Column("id").Key(KeyType.Identity);
            Map(m => m.Id).Column("id");
            Map(m => m.AspNetUsersId).Column("AspNetUsersID");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.ExpiraEm).Column("expiraEm");
            Map(m => m.ativo).Column("ativo");
        }
    }
}
