using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AtendimentoChatViewModel
    {
        public long AtividadeId { get; set; }
        public long AtendimentoId { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public SelectList Midias { get; set; }
        public ICollection<StatusAtividade> ListaStatus { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public string Protocolo { get; set; }
        public bool Finalizada { get; set; }
        public int? MidiaId { get; set; }
        public long? StatusId { get; set; }
        public string Status { get; set; }
        public ICollection<ChatMensagem> Mensagens { get; set; }

        public AtendimentoChatViewModel()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
