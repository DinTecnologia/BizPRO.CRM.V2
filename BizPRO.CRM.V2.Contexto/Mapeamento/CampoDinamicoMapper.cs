using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;


namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class CampoDinamicoMapper : ClassMapper<CampoDinamico>
    {
        public CampoDinamicoMapper()
        {
            Table("CamposDinamicos");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("nome");
            Map(m => m.Tipo).Column("tipo");
            Map(m => m.EntidadeId).Column("entidadeID");
            Map(m => m.Obrigatorio).Column("obrigatorio");
            Map(m => m.Ativo).Column("ativo");
            Map(m => m.MultiplaEscolha).Column("multiplaEscolha");            
        }
    }
}
