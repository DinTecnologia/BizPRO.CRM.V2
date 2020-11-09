using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;


namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class MenuMapper : ClassMapper<Menu>
    {
        public MenuMapper()
        {
            Table("Menus");
            Map(m => m.id).Column("id").Key(KeyType.Identity);
            Map(m => m.nome).Column("nome");
            Map(m => m.menuPai).Column("menuPai");
            Map(m => m.tipo).Column("tipo");
            Map(m => m.funcionalidadeID).Column("funcionalidadeID");
            Map(m => m.tipoAbertura).Column("tipoAbertura");
            Map(m => m.ordem).Column("ordem");
            Map(m => m.icone).Column("icone");
            Map(m => m.aplicacaoId).Column("aplicacaoId");
        }
    }
}
