using BizPRO.CRM.V2.Dominio.Entidades;
using DapperExtensions.Mapper;

namespace Camadas.Infra.Dados.Contexto.Mapeamento
{
    public class FilaMapper : ClassMapper<Fila>
    {
        public FilaMapper()
        {
            Table("Filas");
            Map(m => m.Id).Column("id").Key(KeyType.Identity);
            Map(m => m.Nome).Column("nome");
            Map(m => m.Ativo).Column("ativo");
            Map(m => m.CriadoEm).Column("criadoEm");
            Map(m => m.CriadoPorUserId).Column("criadoPorUserID");
            Map(m => m.AceitaLigacoes).Column("aceitaLigacoes");
            Map(m => m.AceitaChatSms).Column("aceitaChatSMS");
            Map(m => m.AceitaChatWeb).Column("aceitaChatWeb");
            Map(m => m.AceitaEmails).Column("aceitaEmails");
            Map(m => m.AceitaTarefas).Column("aceitaTarefas");
            Map(m => m.AlteradoEm).Column("alteradoEm");
            Map(m => m.AlteradoPorUserId).Column("alteradoPorUserID");
            Map(m => m.ContaParaDisparoDeEmailConfiguracaoContasEmailsId)
                .Column("contaParaDisparoDeEmail_ConfiguracaoContasEmailsID");
            Map(m => m.TempoEmMinutosParaSlaDeFechamento).Column("tempoEmMinutosParaSLADeFechamento");
            Map(m => m.TempoEmMinutosParaSlaPrimeiroAtendimento).Column("tempoEmMinutosParaSLAPrimeiroAtendimento");
            Map(m => m.GerarProtocoloNaEntradaDeEmail).Column("gerarProtocoloNaEntradaDeEmail");
            Map(m => m.EnviarEmailComProtocoloGerado).Column("enviarEmailComProtocoloGerado");
            Map(m => m.EmailModeloEnvioProtocoloEmailsModeloId).Column("emailModeloEnvioProtocolo_EmailsModeloId");
            Map(m => m.DepartamentoId).Column("departamentoId");
            Map(m => m.TempoEmMinutosTma).Column("tempoEmMinutosTma");
            Map(m => m.TempoEmMinutosSemInteracao).Column("tempoEmMinutosSemInteracao");
            Map(m => m.TempoEmSegundosInatividadeContato).Column("TempoEmSegundosInatividadeContato");
            Map(m => m.TempoEmSegundosAvisoInatividadeContato).Column("TempoEmSegundosAvisoInatividadeContato");
            Map(m => m.CanalId).Column("CanalId");
        }
    }
}
