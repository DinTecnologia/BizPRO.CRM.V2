using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class EmailModeloMapper : ClassMapper<EmailModelo>
    {
        public EmailModeloMapper()
        {
            Table("EMailsModelo");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.NomeDoModelo).Column("nomeDoModelo");
            Map(m => m.Html).Column("HTML");
            Map(m => m.Ativo).Column("ativo");
            Map(m => m.CriadoPorAspNetUsersId).Column("criadoPorAspNetUsersID");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.AlteradoPorAspNetUsersId).Column("alteradoPorAspNetUsersID");
            Map(m => m.AlteradoEm).Column("alteradoEm");
        }
    }
}
