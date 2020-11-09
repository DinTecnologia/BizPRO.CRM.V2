using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class AspNetClaimMapper : ClassMapper<AspNetClaim>
    {
        public AspNetClaimMapper()
        {
            Table("AspNetClaims");
            Map(m => m.Id).Column("id");
            Map(m => m.Name).Column("name");
        }
    }
}
