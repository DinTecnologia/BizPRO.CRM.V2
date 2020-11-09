using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class EmailAnexoMapper : ClassMapper<EmailAnexo>
    {
        public EmailAnexoMapper()
        {
            Table("EmailsAnexo");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.EmailId).Column("EmailsId");
            Map(m => m.Nome).Column("Nome");
            Map(m => m.Extensao).Column("Extensao");
            Map(m => m.Tamanho).Column("Tamanho");
            Map(m => m.Path).Column("Path");
            Map(m => m.CriadoEm).Column("CriadoEm");
            Map(m => m.Ativo).Column("Ativo");
            Map(m => m.ImagemCorpo).Column("ImagemCorpo");
            Map(m => m.ContentId).Column("ContentId");
            Map(m => m.IdentificadorAnexoItem).Column("IdentificadorAnexoItem");
        }
    }
}
