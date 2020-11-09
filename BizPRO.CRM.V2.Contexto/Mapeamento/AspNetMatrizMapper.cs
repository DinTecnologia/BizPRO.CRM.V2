using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class AspNetMatrizMapper : ClassMapper<AspNetMatriz>
    {
        public AspNetMatrizMapper()
        {
            Table("AspNetMatriz");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Sentido).Column("sentido");
            Map(m => m.Valor).Column("valor");
            Map(m => m.Texto).Column("texto");
        }
    }
}
