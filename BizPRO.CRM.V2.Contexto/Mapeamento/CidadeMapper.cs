using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class CidadeMapper : ClassMapper<Cidade>
    {
        public CidadeMapper()
        {
            Table("Cidades");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);            
            Map(m => m.Nome).Column("nome");
            Map(m => m.Uf).Column("uf");
        }
    }
}
