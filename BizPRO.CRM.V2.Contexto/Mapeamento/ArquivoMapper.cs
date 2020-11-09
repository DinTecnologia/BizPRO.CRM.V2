using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class ArquivoMapper : ClassMapper<Arquivo>
    {
        public ArquivoMapper()
        {
            Table("arquivos");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Caminho).Column("Caminho");
            Map(m => m.Nome).Column("Nome");
            Map(m => m.Tamanho).Column("Tamanho");
            Map(m => m.Extensao).Column("Extensao");
            Map(m => m.CriadoEm).Column("CriadoEm");
            Map(m => m.CriadoPor).Column("CriadoPor");
            Map(m => m.ChaveEntidadeId).Column("ChaveEntidadeId");
            Map(m => m.EntidadeId).Column("EntidadeId");
        }
    }
}
