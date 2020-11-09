using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class AtividadeParteEnvolvidaMapper : ClassMapper<AtividadeParteEnvolvida>
    {
        public AtividadeParteEnvolvidaMapper()
        {
            Table("AtividadesPartesEnvolvidas");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.AtividadesId).Column("AtividadesID");
            Map(m => m.PessoasFisicasId).Column("PessoasFisicasID");
            Map(m => m.PessoasJuridicasId).Column("PessoasJuridicasID");
            Map(m => m.PotenciaisClientesId).Column("PotenciaisClientesID");
            Map(m => m.AspNetUsersId).Column("AspNetUsersID");
            Map(m => m.TipoParteEnvolvida).Column("TipoParteEnvolvida");
            Map(m => m.Email).Column("Email");
            Map(m => m.Nome).Column("Nome");
            Map(m => m.Ordem).Column("Ordem");
        }
    }
}
