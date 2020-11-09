using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;


namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class AnotacaoMapper : ClassMapper<Anotacao>
    {
        public AnotacaoMapper()
        {
            Table("Anotacoes");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Texto).Column("texto");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.OcorrenciaId).Column("ocorrenciaID");
            Map(m => m.AtividadeId).Column("atividadeID");
            Map(m => m.PessoaFisicaId).Column("pessoaFisicaID");
            Map(m => m.PessoaJuridicaId).Column("pessoaJuridicaID");
            Map(m => m.PotenciaisClienteId).Column("PotenciaisClientesID");
            Map(m => m.AcompanhamentoOcorrencia).Column("acompanhamentoOcorrencia");
            Map(m => m.AnotacaoTipoId).Column("anotacaoTipoId");
            
        }
    }
}
