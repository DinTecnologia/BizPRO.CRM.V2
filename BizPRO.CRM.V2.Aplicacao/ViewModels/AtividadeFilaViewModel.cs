using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class AtividadeFilaViewModel
    {
        public long Id { get; set; }
        public long AtividadeId { get; set; }
        public int FilaId { get; set; }
        public DateTime EntrouNaFilaEm { get; set; }
        public DateTime? SaiuDaFilaEm { get; set; }
        public ValidationResult ValidationResult { get; set; }


        public AtividadeFilaViewModel(long id, long atividadeId, int filaId, DateTime entrouNaFilaEm, ValidationResult validationResult)
        {
            Id = id;
            AtividadeId = atividadeId;
            FilaId = filaId;
            EntrouNaFilaEm = entrouNaFilaEm;
            ValidationResult = validationResult ?? new ValidationResult();
        }
        public AtividadeFilaViewModel(long atividadeId, int filaId, ValidationResult validationResult)
        {
            AtividadeId = atividadeId;
            FilaId = filaId;
            ValidationResult = validationResult ?? new ValidationResult();
        }
    }
}
