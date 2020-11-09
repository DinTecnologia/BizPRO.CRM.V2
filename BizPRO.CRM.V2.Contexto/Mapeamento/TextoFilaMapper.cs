using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class TextoFilaMapper : ClassMapper<TextoFila>
    {
        public TextoFilaMapper()
        {
            Table("TextoFilas");
            Map(m => m.Id).Column("Id").Key(KeyType.Identity);
            Map(m => m.TextoId).Column("TextoId");
            Map(m => m.FilaId).Column("FilaId");
            Map(m => m.CriadoEm).Column("CriadoEm");
            Map(m => m.CriadoPor).Column("CriadoPor");
            Map(m => m.Ativo).Column("Ativo");
        }
    }
}