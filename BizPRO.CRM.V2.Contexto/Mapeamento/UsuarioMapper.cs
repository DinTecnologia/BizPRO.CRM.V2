using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Contexto.Mapeamento
{
    public class UsuarioMapper : ClassMapper<Usuario>
    {
        public UsuarioMapper()
        {
            Table("Usuarios");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("nome");
            Map(m => m.Email.Endereco).Column("email");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPor).Column("criadoPor");
            Map(m => m.Ativo).Column("ativo");
            Map(m => m.EnderecoEmail).Column("email");
        }
    }
}
