using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Pausa
    {
        public long Id { get; set; }
        public string CanalIds { get; set; }
        public string UsuarioId { get; set; }
        public DateTime IniciadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public int MotivoPausaId { get; set; }
        public string CriadoPor { get; set; }
        public DateTime CriadoEm { get; set; }
        public bool Ativo { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public PausaMotivo Motivo { get; set; }
        public Canal Canal { get; set; }


        public Pausa()
        {
            IniciadoEm = DateTime.Now;
            CriadoEm = DateTime.Now;
            ValidationResult = new ValidationResult();
        }
    }
}
