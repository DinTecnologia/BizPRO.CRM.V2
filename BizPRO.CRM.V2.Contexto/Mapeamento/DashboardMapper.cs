using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class DashboardMapper : ClassMapper<Dashboard>
    {
        public DashboardMapper()
        {
            Map(m => m.PlaId).Column("PLA_ID").Key(KeyType.Identity);
            Map(m => m.PlaSigla).Column("PLA_SILGLA");
            Map(m => m.PlaDescricao).Column("PLA_DESCRICAO");
            Map(m => m.PlaQuantidade).Column("PLA_QUANTIDADE");
            Map(m => m.PlaPorcentagem).Column("PLA_PORCENTAGEM");
            Map(m => m.PlaUsuario).Column("PLA_USUARIO");
        }
    }
}
