using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class IntegracaoControleMapper : ClassMapper<IntegracaoControle>
    {
        public IntegracaoControleMapper()
        {
            Table("IntegracoesControle");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.PessoaFisicaId).Column("PessoaFisicaId");
            Map(m => m.PessoaJuridicaId).Column("PessoaJuridicaId");
            Map(m => m.ContratoId).Column("ContratoId");
            Map(m => m.TelefoneId).Column("TelefoneId");
            Map(m => m.IdentificadorIntegracao).Column("IdentificadorIntegracao");
            Map(m => m.CriadoEm).Column("CriadoEm");
            Map(m => m.CriadoPor).Column("CriadoPor");
            Map(m => m.UltimaAtualizacaoEm).Column("UltimaAtualizacaoEm");
            Map(m => m.Ativo).Column("Ativo");
        }
    }
}
