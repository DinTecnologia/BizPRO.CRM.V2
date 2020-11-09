using System.Data.Entity.ModelConfiguration;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Contexto.EntityConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            Property(c => c.Id)
                .HasColumnName("id");

            Property(c => c.EnderecoEmail)
                .HasColumnName("email");

            Property(c => c.Nome)
                .HasColumnName("nome");

            Property(c => c.CriadoEm)
                .HasColumnName("criadoEm");

            Property(c => c.CriadoPor)
                .HasColumnName("criadoPor");

            Property(c => c.AlteradoPor)
                .HasColumnName("alteradoPor");

            Property(c => c.DepartamentoId)
                .HasColumnName("departamentoId");

            Ignore(c => c.Token);
            Ignore(c => c.Email);
            Ignore(c => c.ValidationResult);
            ToTable("AspNetUsers");
        }
    }
}
