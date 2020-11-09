using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ChatDashboard
    {
        public int TotalConversas { get; set; }
        public int TotalClientesFila { get; set; }
        public int TotalAgentesDisponivel { get; set; }
        public int TotalAgentesPausa { get; set; }
        public int TotalAgentesOnline { get; set; }
        public DateTime LidoEm { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public List<ChatConversa> Conversas { get; set; }
        public List<ChatFila> Filas { get; set; }
        public List<ChatAgente> AgentesDisponiveis { get; set; }
        public List<ChatAgente> AgentesEmPausa { get; set; }


        public ChatDashboard()
        {
            ValidationResult = new ValidationResult();
            LidoEm = DateTime.Now;
        }
    }

    public class ChatConversa
    {
        public string AgenteConexaoOriginalId { get; set; }
        public long ChatId { get; set; }
        public long AtividadeId { get; set; }
        public DateTime IniciadoEm { get; set; }
        public List<Participante> Participantes { get; set; }
        public string Protocolo { get; set; }
        public ChatFila ChatFila { get; set; }
        public bool AgenteDesconectou { get; set; }

        public ChatConversa()
        {
            IniciadoEm = DateTime.Now;
            Participantes = new List<Participante>();
        }
    }

    public class Participante
    {
        public string ConexaoId { get; set; }
        public long AtividadeParteEnvolvidaId { get; set; }
        public string Nome { get; set; }
        public ParticipanteTipo ParticipanteTipo { get; set; }
        public string Documento { get; set; }
        public DateTime EntrouEm { get; set; }
        public DateTime? SaiuEm { get; set; }

        public Participante()
        {
            Nome = "--";
            EntrouEm = DateTime.Now;
        }
    }

    public enum ParticipanteTipo
    {
        Agente = 1,
        Cliente = 2
    }

    public class ChatFila
    {
        public string ConexaoId { get; set; }
        public DateTime EntrouEm { get; set; }
        public long FilaId { get; set; }
        public long SolicitacaoId { get; set; }
        public long ChatId { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public int QuantidadeTentativas { get; set; }
        public int Prioridade { get; set; }
        public string Protocolo { get; set; }
        public long AtividadeId { get; set; }
        public long ParteEnvolvidaId { get; set; }
        public DateTime? AgenteConectando { get; set; }
        public string AgenteConexaoId { get; set; }
        public int? TempoInatividade { get; set; }

       

        

        public ChatFila()
        {
            EntrouEm = DateTime.Now;
            Prioridade = 1;
        }

        public string TempoFila
        {
            get
            {
                var agora = new DateTime();
                var segundos = EntrouEm.Subtract(agora).TotalSeconds;
                var hor = (int) (segundos / (60 * 60));
                var min = (int) ((segundos - (hor * 60 * 60)) / 60);
                var seg = (int) (segundos - (hor * 60 * 60) - (min * 60));
                return string.Format("{0}:{1}:{2}", hor, min, seg);
            }
        }
    }

    public class ChatAgente
    {
        public string ConexaoId { get; set; }
        public DateTime EntrouEm { get; set; }
        public string UsuarioId { get; set; }
        public int TotalConversa { get; set; }
        public string Nome { get; set; }
        public bool EmPausa { get; set; }
        public string Motivo { get; set; }
        public int MaxAtendimentoSimultaneos { get; set; }
        public DateTime? PausaEntrouEm { get; set; }
        public int TotalAtendimentosConexao { get; set; }
        public int TotalTentativaProximoCliente { get; set; }

        public DateTime? TempoSemCliente { get; set; }


        public ChatAgente()
        {
            EntrouEm = DateTime.Now;
            TempoSemCliente = DateTime.Now;
        }
    }

    public class ChatConversaProvisoria
    {
        public string AgenteConexaoOriginalId { get; set; }
        public long ChatId { get; set; }
    }
}
