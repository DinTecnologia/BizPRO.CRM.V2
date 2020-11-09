using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class TextoCategoriaMapper : ClassMapper<TextoCategoria>
    {
        public TextoCategoriaMapper()
        {
            Table("TextoCategorias");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("Nome");
            Map(m => m.TextoCategoriaPaiId).Column("TextoCategoriaPaiId");
            Map(m => m.NomeExibicao).Column("NomeExibicao");
            Map(m => m.EstruturaDeIds).Column("EstruturaDeIds");
            Map(m => m.EhUltimoNivel).Column("EhUltimoNivel");
            Map(m => m.CriadoEm).Column("CriadoEm");
            Map(m => m.CriadoPor).Column("CriadoPor");
            Map(m => m.AtualizadoEm).Column("AtualizadoEm");
            Map(m => m.AtualizadoPor).Column("AtualizadoPor");
            Map(m => m.Ativo).Column("Ativo");
        }
    }
}
