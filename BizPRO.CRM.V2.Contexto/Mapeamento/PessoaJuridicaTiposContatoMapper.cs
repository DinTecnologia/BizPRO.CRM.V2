using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    class PessoaJuridicaTiposContatoMapper: ClassMapper<PessoaJuridicaTiposContato>
    {
        public PessoaJuridicaTiposContatoMapper()
        {
            Table("PessoaJuridicaTiposContato");
            Map(m => m.id).Column("id").Key(KeyType.Identity);
            Map(m => m.nome).Column("nome");
            Map(m => m.padrao).Column("padrao");
            Map(m => m.criadoPorUserID).Column("criadoPorUserID");
            Map(m => m.criadoEm).Column("criadoEm");
            Map(m => m.ativo).Column("ativo");
        }
    }
}