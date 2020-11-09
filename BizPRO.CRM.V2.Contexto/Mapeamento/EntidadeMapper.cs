using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class EntidadeMapper : ClassMapper<Entidade>
    {
        public EntidadeMapper()
        {
            Table("Entidades");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("nome");
            Map(m => m.NomeLogico).Column("nomeLogico");
            Map(m => m.Sigla).Column("sigla");
            Map(m => m.CampoChave).Column("campoChave");
            Map(m => m.ScriptOnPage).Column("scriptOnPage");
        }
    }
}
