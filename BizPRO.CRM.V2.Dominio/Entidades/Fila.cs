using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Fila
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }
        public bool AceitaLigacoes { get; set; }
        public bool AceitaEmails { get; set; }
        public bool AceitaTarefas { get; set; }
        public bool AceitaChatSms { get; set; }
        public bool AceitaChatWeb { get; set; }
        public bool AceitaChatMessenger { get; set; }
        public int? ContaParaDisparoDeEmailConfiguracaoContasEmailsId { get; set; }
        public string AlteradoPorUserId { get; set; }
        public DateTime? AlteradoEm { get; set; }
        public int TempoEmMinutosParaSlaDeFechamento { get; set; }
        public int TempoEmMinutosParaSlaPrimeiroAtendimento { get; set; }
        public bool? GerarProtocoloNaEntradaDeEmail { get; set; }
        public bool? EnviarEmailComProtocoloGerado { get; set; }
        public int? EmailModeloEnvioProtocoloEmailsModeloId { get; set; }
        public ConfiguracaoContasEmails ContaEmailDisparo { get; set; }
        public IEnumerable<Atividade> Atividades { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public int? DepartamentoId { get; set; }
        public int? TempoEmMinutosTma { get; set; }
        public int? TempoEmMinutosSemInteracao { get; set; }
        public int? TempoEmSegundosInatividadeContato { get; set; }
        public int? TempoEmSegundosAvisoInatividadeContato { get; set; }

        public int? CanalId { get; set; }

        public bool IsValid()
        {
            return ValidationResult.IsValid;
        }

        public Fila()
        {
            ValidationResult = new ValidationResult();
            Atividades = new List<Atividade>();
            ContaEmailDisparo = new ConfiguracaoContasEmails();
        }

        public Fila(int? id,
            string nome,
            bool ativo,
            string criadoPorUserId,
            bool aceitaLigacoes,
            bool aceitaEmails,
            bool aceitaTarefas,
            bool aceitaChatSms,
            bool aceitaChatWeb,
            int? contaParaDisparoDeEmailConfiguracaoContasEmailsId,
            string alteradoPorUserId,
            DateTime? alteradoEm,
            int tempoEmMinutosParaSlaDeFechamento,
            int tempoEmMinutosParaSlaPrimeiroAtendimento,
            bool? gerarProtocoloNaEntradaDeEmail,
            bool? enviarEmailComProtocoloGerado,
            int? emailModeloEnvioProtocoloEmailsModeloId,
            int? departamentoId,
            int? tempoEmSegundosInatividadeContto,
            int? tempoEmSegundosAvisoInatividadeContato)
        {
            Id = id ?? 0;
            Nome = nome;
            Ativo = ativo;
            CriadoEm = DateTime.Now;
            CriadoPorUserId = criadoPorUserId;
            AceitaLigacoes = aceitaLigacoes;
            AceitaEmails = aceitaEmails;
            AceitaTarefas = aceitaTarefas;
            AceitaChatSms = aceitaChatSms;
            AceitaChatWeb = aceitaChatWeb;
            ContaParaDisparoDeEmailConfiguracaoContasEmailsId = contaParaDisparoDeEmailConfiguracaoContasEmailsId;
            AlteradoPorUserId = alteradoPorUserId;
            AlteradoEm = alteradoEm;
            TempoEmMinutosParaSlaDeFechamento = tempoEmMinutosParaSlaDeFechamento == 0
                ? -1
                : tempoEmMinutosParaSlaDeFechamento;
            TempoEmMinutosParaSlaPrimeiroAtendimento = tempoEmMinutosParaSlaPrimeiroAtendimento == 0
                ? -1
                : tempoEmMinutosParaSlaPrimeiroAtendimento;
            GerarProtocoloNaEntradaDeEmail = gerarProtocoloNaEntradaDeEmail;
            EnviarEmailComProtocoloGerado = enviarEmailComProtocoloGerado;
            EmailModeloEnvioProtocoloEmailsModeloId = emailModeloEnvioProtocoloEmailsModeloId;
            DepartamentoId = departamentoId;
            TempoEmSegundosInatividadeContato = tempoEmSegundosInatividadeContto;
            TempoEmSegundosAvisoInatividadeContato = tempoEmSegundosAvisoInatividadeContato;
        }

        public void AtualizarEntidade(Fila entidade, string atualizadoPorUserId)
        {
            Nome = entidade.Nome;
            Ativo = entidade.Ativo;
            AceitaLigacoes = entidade.AceitaLigacoes;
            AceitaEmails = entidade.AceitaEmails;
            AceitaTarefas = entidade.AceitaTarefas;
            AceitaChatSms = entidade.AceitaChatSms;
            AceitaChatWeb = entidade.AceitaChatWeb;
            ContaParaDisparoDeEmailConfiguracaoContasEmailsId =
                entidade.ContaParaDisparoDeEmailConfiguracaoContasEmailsId;
            AlteradoPorUserId = atualizadoPorUserId;
            AlteradoEm = DateTime.Now;
            TempoEmMinutosParaSlaDeFechamento = entidade.TempoEmMinutosParaSlaDeFechamento == 0
                ? -1
                : entidade.TempoEmMinutosParaSlaDeFechamento;
            TempoEmMinutosParaSlaPrimeiroAtendimento = entidade.TempoEmMinutosParaSlaPrimeiroAtendimento == 0
                ? -1
                : entidade.TempoEmMinutosParaSlaPrimeiroAtendimento;
            GerarProtocoloNaEntradaDeEmail = entidade.GerarProtocoloNaEntradaDeEmail;
            EnviarEmailComProtocoloGerado = entidade.EnviarEmailComProtocoloGerado;
            EmailModeloEnvioProtocoloEmailsModeloId = entidade.EmailModeloEnvioProtocoloEmailsModeloId;
            DepartamentoId = entidade.DepartamentoId;
            TempoEmSegundosInatividadeContato = entidade.TempoEmSegundosInatividadeContato;
            TempoEmSegundosAvisoInatividadeContato = entidade.TempoEmSegundosAvisoInatividadeContato;
        }
    }
}

