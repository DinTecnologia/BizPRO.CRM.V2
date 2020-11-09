using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class StatusEntidadeMapper : ClassMapper<StatusEntidade>
    {
        public StatusEntidadeMapper()
        {
            Table("StatusEntidade");
            Map(m => m.id).Column("id").Key(KeyType.Identity);
            Map(m => m.nome).Column("nome");
            Map(m => m.ativo).Column("ativo");
            Map(m => m.entidadesValidas).Column("entidadesValidas");
            Map(m => m.padrao).Column("padrao");
            Map(m => m.finalizador).Column("finalizador");            
        }
    }
}
