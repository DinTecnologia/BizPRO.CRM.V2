using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class LigacaoMapper : ClassMapper<Ligacao>
    {
        public LigacaoMapper()
        {
            Table("Ligacoes");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.PessoaFisicaId).Column("pessoaFisicaID");
            Map(m => m.PessoaJuridicaId).Column("pessoaJuridicaID");
            Map(m => m.UserId).Column("userId");
            Map(m => m.NumeroOriginal).Column("numeroOriginal");
            Map(m => m.TelefoneId).Column("telefoneID");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.FinalizadoEm).Column("finalizadoEm");
            Map(m => m.Sentido).Column("sentido");
            Map(m => m.AtividadeId).Column("atividadeID");
            Map(m => m.PotencialClientesId).Column("PotenciaisClientesID");
            Map(m => m.Documento).Column("Documento");
        }
    }
}
