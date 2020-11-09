using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Contexto.Mapeamento
{
    public class AcessoMapper : ClassMapper<Acesso>
    {
        public AcessoMapper()
        {
            Table("acessos");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.UserId).Column("userId");
            Map(m => m.Token).Column("token");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.FinalizadoEm).Column("finalizadoEm");
        }
    }
}