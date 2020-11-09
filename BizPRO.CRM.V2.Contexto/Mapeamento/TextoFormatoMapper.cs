using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
   public class TextoFormatoMapper : ClassMapper<TextoFormato>
    {
        public TextoFormatoMapper()
        {
            Table("TextoFormatos");
            Map(m => m.Id).Column("Id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("Nome");
            Map(m => m.CriadoEm).Column("CriadoEm");
            Map(m => m.CriadoPor).Column("CriadoPor");
            Map(m => m.AtualizadoEm).Column("AtualizadoEm");
            Map(m => m.AtualizadoPor).Column("AtualizadoPor");
            Map(m => m.Ativo).Column("Ativo");
        }
    }
}
