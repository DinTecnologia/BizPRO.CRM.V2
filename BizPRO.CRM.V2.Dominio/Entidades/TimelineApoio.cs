using System;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class TimelineApoio
    {
        public long plaid { get; set; }
        //Qual o Tipo do Registro
        /// <summary>
        ///     1 - Criacao Cliente
        /// 	2 - Contrato
        /// 	3 - Atendimento
        /// 	4 - Ligação
        /// 	5 - Ocorrência
        /// 	6 - Tarefa
        /// </summary>        
        public long? plaTipo { get; set; }
        public long? plaTipoID { get; set; }
        public long? plaAtendimentoID { get; set; }
        public string plaNomeTipo { get; set; }
        public DateTime? plaData { get; set; }
        public string plaStatus { get; private set; }
        public DateTime? plaDataTermino { get; private set; }
        public string plaCriadoPor { get; private set; }
        public string plaResponsavel { get; private set; }
        public string plaTitulo { get; private set; }
        public string pladescricao { get; private set; }
        public string plasentido { get; private set; }
        public DateTime? pladataHoraPrevistaExecucao { get; private set; }
        public IEnumerable<Tarefa> Tarefas { get; set; }
        public IEnumerable<Anotacao> Anotacoes { get; set; }
        public Ocorrencia Ocorrencia { get; set; }
        public bool possuiFilho
        {
            get
            {
                bool retorno = false;

                if (!String.IsNullOrEmpty(pladescricao) || !String.IsNullOrEmpty(plasentido) || (Anotacoes != null ? (Anotacoes.Any() ? true : false) : false))
                    retorno = true;

                return retorno;
            }
        }

        public TimelineApoio()
        {

        }
        public TimelineApoio(long? plaTipo, long? plaTipoID, long? plaAtendimentoID, string plaNomeTipo, DateTime? plaData, string plaStatus,
       DateTime? plaDataTermino, string plaCriadoPor, string plaResponsavel, string plaTitulo, string pladescricao, string plasentido, DateTime? pladataHoraPrevistaExecucao)
        {
            this.plaTipo = plaTipo;
            this.plaTipoID = plaTipoID;
            this.plaAtendimentoID = plaAtendimentoID;
            this.plaNomeTipo = plaNomeTipo;
            this.plaData = plaData;
            this.plaStatus = plaStatus;
            this.plaDataTermino = plaDataTermino;
            this.plaCriadoPor = plaCriadoPor;
            this.plaResponsavel = plaResponsavel;
            this.plaTitulo = plaTitulo;
            this.pladescricao = pladescricao;
            this.plasentido = plasentido;
            this.pladataHoraPrevistaExecucao = pladataHoraPrevistaExecucao;
        }
    }
}
