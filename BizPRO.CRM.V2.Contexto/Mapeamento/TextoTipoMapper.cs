using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class TextoTipoMapper : ClassMapper<TextoTipo>
    {
        public TextoTipoMapper()
        {
            Table("TextoTipos");
            Map(m => m.Id).Column("Id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("Nome");
        }
    }
}
