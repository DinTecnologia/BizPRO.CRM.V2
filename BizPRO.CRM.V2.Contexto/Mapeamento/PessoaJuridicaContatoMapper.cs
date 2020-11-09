using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class PessoaJuridicaContatoMapper : ClassMapper<PessoaJuridicaContato>
    {
        public PessoaJuridicaContatoMapper()
        {
            Table("PessoaJuridicaContatos");
            Map(m => m.id).Column("id").Key(KeyType.Identity);
            Map(m => m.PessoasFisicasID).Column("PessoasFisicasID");
            Map(m => m.principal).Column("principal");
            Map(m => m.tiposContatoPessoaJuridicaID).Column("tiposContatoPessoaJuridicaID");
            Map(m => m.criadoEm).Column("criadoEm");
            Map(m => m.criadoPorUserID).Column("criadoPorUserID");
            Map(m => m.PessoasJuridicasID).Column("PessoasJuridicasID");
            Map(m => m.removidoEm).Column("removidoEm");
            Map(m => m.removidoPorUserID).Column("removidoPorUserID");
        }
    }
}
