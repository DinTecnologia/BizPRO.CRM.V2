using System.Collections.Generic;
using System.Web.Mvc;
using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AtendimentoFormViewModel
    {
        public long? AtendimentoId { get; set; }
        public long? AtividadeId { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? ContatoPessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public long? ContatoPessoaJuridicaId { get; set; }

        public int CanalId { get; set; }
        public int? StatusId { get; set; }
        public string NomeCanal { get; set; }
        public bool AtendimentoEmail { get; set; }
        public bool AtendimentoTelefone { get; set; }
        public bool AtendimentoChat { get; set; }
        public string Procotolo { get; set; }
        public SelectList Midias { get; set; }
        public SelectList Sentidos { get; set; }
        public long? MidiaId { get; set; }
        public string Sentido { get; set; }
        public string Status { get; set; }
        public bool AtendimentoFinalizado { get; set; }
        public bool PodeEditar { get; set; }
        public ICollection<StatusAtividade> ListaStatus { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public string UsuarioId { get; set; }
        public long? EmailId { get; set; }
        public long? LigacaoId { get; set; }
        public long? ChatId { get; set; }
        public string Documento { get; set; }
        

        public EmailFormViewModel Email { get; set; }
        public LigacaoViewModel Ligacao { get; set; }
        public ChatViewModel Chat { get; set; }

        public AtendimentoFormViewModel()
        {
            ValidationResult = new ValidationResult();
            Procotolo = "--";
            ListaStatus = new List<StatusAtividade>();
            PodeEditar = true;
        }
    }
}
