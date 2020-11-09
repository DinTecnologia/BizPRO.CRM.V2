using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class EntidadeSecaoMapper : ClassMapper<EntidadeSecao>
    {
        public EntidadeSecaoMapper()
        {
            Table("EntidadesSecoes");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.EntidadesId).Column("entidadesID");
            Map(m => m.Nome).Column("nome");
            Map(m => m.Ordem).Column("ordem");
            Map(m => m.Aba).Column("aba");
        }
    }
}
