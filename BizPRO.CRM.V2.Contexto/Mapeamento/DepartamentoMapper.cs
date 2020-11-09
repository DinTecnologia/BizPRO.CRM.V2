using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class DepartamentoMapper : ClassMapper<Departamento>
    {
        public DepartamentoMapper()
        {
            Table("Departamentos");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("nome");
            Map(m => m.Ativo).Column("ativo");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserId");
        }
    }
}
