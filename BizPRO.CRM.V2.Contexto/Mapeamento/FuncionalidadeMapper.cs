using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class FuncionalidadeMapper : ClassMapper<Funcionalidade>
    {
        public FuncionalidadeMapper()
        {
            Table("Funcionalidades");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("nome");
            Map(m => m.ControllerName).Column("controllerName");
            Map(m => m.ActionName).Column("actionName");
            Map(m => m.PatternParametros).Column("patternParametros");
        }
    }
}
