using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class AtividadeFila
    {
        public long Id { get; set; }
        public long AtividadeId { get; set; }
        public int FilaId { get; set; }
        public DateTime EntrouNaFilaEm { get; set; }
        public DateTime? SaiuDaFilaEm { get; set; }
        public ValidationResult ValidatoinResult { get; set; }

        public AtividadeFila()
        {
            ValidatoinResult = new ValidationResult();
        }

        public AtividadeFila(long atividadeId, int filaId, DateTime? saiuDaFilaEm = null)
        {
            ValidatoinResult = new ValidationResult();
            AtividadeId = atividadeId;
            FilaId = filaId;
            EntrouNaFilaEm = DateTime.Now;
            SaiuDaFilaEm = saiuDaFilaEm;
        }
    }
}
