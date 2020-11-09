using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class EmailLogMapper : ClassMapper<EmailLog>
    {
        public EmailLogMapper()
        {
            Table("emailsLOG");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.EmailsId).Column("EmailsID");
            Map(m => m.Texto).Column("texto");
            Map(m => m.CriadoEm).Column("criadoEm");
        }
    }
}
