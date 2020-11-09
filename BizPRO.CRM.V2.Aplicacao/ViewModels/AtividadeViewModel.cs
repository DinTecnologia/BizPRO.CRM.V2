using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AtividadeViewModel
    {
        public long id { get; set; }
        public int? atividadeTipoID { get; set; }
        public DateTime criadoEm { get; set; }
        public string criadoPorUserID { get; set; }
        public string responsavelPorUserID { get; set; }
        public int statusAtividadeID { get; set; }
        public long ocorrenciaID { get; set; }
        public long contratoID { get; set; }
        public long? atendimentoID { get; set; }
        public DateTime? previsaoDeExecucao { get; set; }
        public DateTime? finalizadoEm { get; set; }
        public string finalizadoPorUserID { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public PessoaFisicaFormViewModel PessoaFisicaFormViewModel { get; set; }
        public PessoaJuridicaFormViewModel PessoaJuridicaFormViewModel { get; set; }
        public PotenciaisClienteViewModel PotenciaisClienteViewModel { get; set; }
        public LigacaoViewModel LigacaoViewModel { get; set; }
        public AtendimentoViewModel AtendimentoViewModel { get; set; }
        public StatusAtividadeViewModel statusAtividadeViewModel { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public long? pessoaFisicaID { get; set; }
        public long? pessoaJuridicaID { get; set; }
        public long? potenciaisClientesID { get; set; }
        public int? filaID { get; set; }
        public ClientePerfilViewModel Cliente { get; set; }

        public IEnumerable<StatusAtividade> ListaStatusAtividade { get; set; }
        public SelectList Midias { get; set; }
        public long? MidiasID { get; set; }
        public string UsuarioId { get; set; }

        public AtividadeViewModel(long id, int? atividadeTipoId, long? pessoaFisicaId, long? pessoaJuridicaId)
        {
            this.id = id;
            atividadeTipoID = atividadeTipoId;
            PessoaFisicaFormViewModel = new PessoaFisicaFormViewModel();
            PessoaJuridicaFormViewModel = new PessoaJuridicaFormViewModel();
            PotenciaisClienteViewModel = new PotenciaisClienteViewModel();
            LigacaoViewModel = new LigacaoViewModel();
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            pessoaFisicaID = pessoaFisicaId;
            pessoaJuridicaID = pessoaJuridicaId;
            Cliente = new ClientePerfilViewModel();
        }

        public AtividadeViewModel(long id, int? atividadeTipoId)
        {
            this.id = id;
            atividadeTipoID = atividadeTipoId;
            Cliente = new ClientePerfilViewModel();
        }

        public AtividadeViewModel()
        {
            PessoaFisicaFormViewModel = new PessoaFisicaFormViewModel();
            PessoaJuridicaFormViewModel = new PessoaJuridicaFormViewModel();
            PotenciaisClienteViewModel = new PotenciaisClienteViewModel();
            LigacaoViewModel = new LigacaoViewModel();
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            Cliente = new ClientePerfilViewModel();
        }
    }

    public class AtividadeNewViewModel
    {
        [Required(ErrorMessage = "Informe o Tipo de Atividade")]
        public int atividadeTipoID { get; set; }

        public long? id { get; set; }
        public long? ocorrenciaID { get; set; }
        public long? contratoID { get; set; }
        public long? atendimentoID { get; set; }
        public DateTime criadoEm { get; set; }
        public DateTime? finalizadoEm { get; set; }
        public DateTime? previsaoDeExecucao { get; set; }
        public long? pessoaFisicaID { get; set; }
        public long? pessoaJuridicaID { get; set; }
        public long? potencialClienteID { get; set; }
        public int? statusAtividadeID { get; set; }
        public int? filaID { get; set; }
        public string descricao { get; set; }
        public string criadoPor { get; set; }
        public string titulo { get; set; }
        public IEnumerable<StatusAtividade> listaStatusAtividade { get; set; }
        public SelectList listaMidia { get; set; }
        public SelectList listaFila { get; set; }
        public int? midiaID { get; set; }
        public LigacaoFormViewModel Ligacao { get; set; }
        public TarefaFormViewModel Tarefa { get; set; }
        public EmailViewModel Email { get; set; }
        public ChatViewModel Chat { get; set; }
        public string protocolo { get; set; }
        public string midia { get; set; }
        public DateTime? dataAgendamento { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public string UsuarioId { get; set; }        
        public string UsuarioFinalizador { get; set; }

        public string tipoReferente
        {
            get
            {
                return ocorrenciaID.HasValue
                    ? "Ocorrência"
                    : (atendimentoID.HasValue
                        ? "Atendimento"
                        : (potencialClienteID.HasValue ? "Potencial Cliente" : "Cliente"));
            }
        }

        public string tempoAtividade
        {
            get
            {
                var ts = (finalizadoEm ?? DateTime.Now).Subtract(criadoEm);
                var periodo = new DateTime(ts.Ticks);

                return string.Format("{0} dia(s) {1}hrs {2}min", periodo.Day - 1,
                    periodo.Hour.ToString().PadLeft(2, '0'),
                    periodo.Minute.ToString().PadLeft(2, '0'));
            }
        }


        public bool podeEditar { get; set; }
        public string referente { get; set; }
        public string responsavel { get; set; }
        public bool tarefaFinalizada { get; set; }

        //Propiedade utilizada para edição/visualização da atividade
        public bool atividadeFinalizada { get; set; }
        public bool? agendamentoPrivado { get; set; }
        public string nomeStatusAtividade { get; set; }

        //Colocado de forma provisória conforme necessidade de implementação urgencial da AIG, deveremos desenvolver módulo atendimento

        public long? ContatoPessoaFisicaId { get; set; }
        public long? ContatoPessoaJuridicaId { get; set; }

        public AtividadeNewViewModel()
        {
            listaStatusAtividade = new List<StatusAtividade>();
            listaMidia = new SelectList(new List<Midia>());
            listaFila = new SelectList(new List<Fila>());
            Ligacao = new LigacaoFormViewModel();
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            midia = "Não Informado";
            protocolo = "Não Informado";
            titulo = "Não Informado";
            nomeStatusAtividade = "Não Informado";
            Tarefa = new TarefaFormViewModel();
        }

        public bool ClienteContatoDiferente()
        {
            if (ContatoPessoaFisicaId.HasValue)
                return ContatoPessoaFisicaId != pessoaFisicaID;
            return ContatoPessoaJuridicaId != pessoaJuridicaID;
        }
    }

    public class LigacaoFormViewModel
    {
        public long? ligacaoID { get; set; }
        public string sentido { get; set; }
        public long? telefoneID { get; set; }
        public string numeroOriginal { get; set; }
        public string telefoneFormatado { get; set; }

        public LigacaoFormViewModel()
        {
            sentido = "Não Identificado";
            numeroOriginal = "Não identificado";
            telefoneFormatado = "Não identificado";
        }
    }
}
