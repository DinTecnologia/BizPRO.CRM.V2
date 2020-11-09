using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class EmailMapper : ClassMapper<Email>
    {
        public EmailMapper()
        {
            Table("Emails");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Endereco).Column("endereco");
            Map(m => m.Ativo).Column("ativo");
            Map(m => m.Principal).Column("principal");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.ClientePessoaJuridicaId).Column("clientePessoaJuridicaID");
            Map(m => m.ClientePessoaFisicaId).Column("clientePessoaFisicaID");
            Map(m => m.AtividadeId).Column("atividadeID");
            Map(m => m.CorpoDoEmail).Column("corpoDoEmail");
            Map(m => m.QuantidadeDeEnvios).Column("quantidadeDeEnvios");

            Map(m => m.Uid).Column("UID");
            Map(m => m.MessageId).Column("MessageID");
            Map(m => m.Sentido).Column("sentido");
            Map(m => m.Assunto).Column("assunto");
            Map(m => m.EmailPaiId).Column("emailPaiId");
            Map(m => m.ConfiguracaoContasEmailId).Column("configuracaoContasEmailID");
            Map(m => m.Texto).Column("texto");
            Map(m => m.IdentificadorEmail).Column("identificadorEmail");

        }
    }
}
