using DapperExtensions.Mapper;
using BizPRO.CRM.V2.Dominio.Entidades;


namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class ConfiguracaoContasEmailsMapper : ClassMapper<ConfiguracaoContasEmails>
    {
        public ConfiguracaoContasEmailsMapper()
        {
            Table("ConfiguracaoContasEmails");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Descricao).Column("descricao");
            Map(m => m.ServidorPop).Column("servidorPop");
            Map(m => m.ServidorSmtp).Column("servidorSMTP");
            Map(m => m.NecessarioSsl).Column("necessarioSSL");
            Map(m => m.Email).Column("email");
            Map(m => m.SenhaEmail).Column("senhaEmail");
            Map(m => m.UsuarioEmail).Column("usuarioEmail");
            Map(m => m.FilasId).Column("FilasID");
            Map(m => m.PortaServidorSaida).Column("portaServidorSaida");
            Map(m => m.PortaServidorEntrada).Column("portaServidorEntrada");
            Map(m => m.ProtocoloServidorEntrada).Column("protocoloServidorEntrada");
            Map(m => m.ContaPadrao).Column("contaPadrao");
            Map(m => m.Assinatura).Column("Assinatura");
        }
    }
}
