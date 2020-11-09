using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class EquipeMapper : ClassMapper<Equipe>
    {
        public EquipeMapper()
        {
            Table("equipes");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("nome");
            Map(m => m.Ativo).Column("ativo");
            Map(m => m.DepartamentoId).Column("departamentoID");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPor");
        }
    }
}
