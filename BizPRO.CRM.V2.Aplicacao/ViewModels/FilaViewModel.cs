using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class FilaViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserID { get; set; }
        public bool aceitaLigacoes { get; set; }
        public bool aceitaEmails { get; set; }
        public bool aceitaTarefas { get; set; }
        public bool aceitaChatSMS { get; set; }
        public bool aceitaChatWeb { get; set; }
        public bool aceitaChatMessenger { get; set; }
        public int? contaParaDisparoDeEmail_ConfiguracaoContasEmailsID { get; set; }
        public string alteradoPorUserID { get; set; }
        public DateTime? alteradoEm { get; set; }
        public List<ConfiguracoesContaEmailsViewModel> ContaEmails { get; set; }
        public SelectList Opcoes { get; set; }
        public string[] roles { get; set; }
        public Usuario Usuario { get; set; }
        public Usuario UsuarioCriador { get; set; }
        public int tempoEmMinutosParaSLADeFechamento { get; set; }
        public int tempoEmMinutosParaSLAPrimeiroAtendimento { get; set; }
        public bool? GerarProtocoloLeituraEmail { get; set; }
        public bool? EnviarEmailRespostaLeitura { get; set; }
        public int? EmailModelId { get; set; }
        public int? DepartamentoId { get; set; }
        
        public int? TempoEmSegundoInatividadeContato { get; set; }
        public int? TempoEmSegundoAvisoInatividadeContato { get; set; }

        public FilaViewModel(int Id, string Nome)
        {
            this.Id = Id;
            this.Nome = Nome;
        }
        public FilaViewModel()
        {
            ContaEmails = new List<ConfiguracoesContaEmailsViewModel>();
        }

        public FilaViewModel(int id, string nome, bool ativo, string userID, DateTime criadoEm,
            bool AceitaLigacao, bool AceitaEmail, bool AceitaTarefa, bool AceitaChatSMS, bool AceitaChatWeb,
            int? contaParaDisparo, string AlteradoPorUserID, DateTime? AlteradoEm,
            IEnumerable<ConfiguracaoContasEmails> opcoes, int? departamentoId, int? tempoEmSegundoInatividadeContato)
        {
            Id = id;
            Nome = nome;
            Ativo = ativo;
            CriadoPorUserID = userID;
            aceitaChatSMS = AceitaChatSMS;
            aceitaChatWeb = AceitaChatWeb;
            aceitaEmails = AceitaEmail;
            aceitaLigacoes = AceitaLigacao;
            aceitaTarefas = AceitaTarefa;
            alteradoEm = AlteradoEm;
            alteradoPorUserID = AlteradoPorUserID;
            contaParaDisparoDeEmail_ConfiguracaoContasEmailsID = contaParaDisparo;
            Opcoes = new SelectList(opcoes, "id", "descricao");
            CriadoEm = criadoEm;
            DepartamentoId = departamentoId;
            TempoEmSegundoInatividadeContato = tempoEmSegundoInatividadeContato;
        }

        public FilaViewModel(int id, string nome, bool ativo, string userID, DateTime criadoEm,
            bool AceitaLigacao, bool AceitaEmail, bool AceitaTarefa, bool AceitaChatSMS, bool AceitaChatWeb,
            string AlteradoPorUserID, DateTime? AlteradoEm, Usuario Usuario, Usuario UsuarioCriador,
            int tempoEmMinutosParaSLADeFechamento, int tempoEmMinutosParaSLAPrimeiroAtendimento, int? departamentoId,
            int? tempoEmSegundoInatividadeContato)
        {
            Id = id;
            Nome = nome;
            Ativo = ativo;
            CriadoPorUserID = userID;
            aceitaChatSMS = AceitaChatSMS;
            aceitaChatWeb = AceitaChatWeb;
            aceitaEmails = AceitaEmail;
            aceitaLigacoes = AceitaLigacao;
            aceitaTarefas = AceitaTarefa;
            alteradoEm = AlteradoEm;
            alteradoPorUserID = AlteradoPorUserID;
            this.Usuario = Usuario;
            this.UsuarioCriador = UsuarioCriador;
            this.tempoEmMinutosParaSLADeFechamento = tempoEmMinutosParaSLADeFechamento;
            this.tempoEmMinutosParaSLAPrimeiroAtendimento = tempoEmMinutosParaSLAPrimeiroAtendimento;
            CriadoEm = criadoEm;
            DepartamentoId = departamentoId;
            TempoEmSegundoInatividadeContato = tempoEmSegundoInatividadeContato;
        }
    }
}
