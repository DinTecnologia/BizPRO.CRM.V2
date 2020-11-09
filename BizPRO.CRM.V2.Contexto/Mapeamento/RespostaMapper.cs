using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class RespostaMapper : ClassMapper<Resposta>
    {
        public RespostaMapper()
        {
            Table("respostas");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.EntidadeId).Column("EntidadeId");
            Map(m => m.RespostaPaiId).Column("RespostaPaiId");
            Map(m => m.Titulo).Column("Titulo");
            Map(m => m.Descricao).Column("Descricao");
            Map(m => m.CriadoEm).Column("CriadoEm");
            Map(m => m.CriadoPor).Column("CriadoPor");
            Map(m => m.AtualizadoEm).Column("AtualizadoEm");
            Map(m => m.AtualizadoPor).Column("AtualizadoPor");
            Map(m => m.Ativo).Column("Ativo");
        }
    }
}
