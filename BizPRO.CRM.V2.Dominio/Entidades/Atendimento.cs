using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Atendimento
    {
        public long Id { get; set; }
        public string Protocolo { get; set; }
        public int? CanalOrigemId { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public string FinalizadoPorUserId { get; set; }
        public long? MidiasId { get; set; }
        public bool ClienteSomenteContato { get; set; }
        public long? TipoClienteContatoEntidadesCamposValoresId { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public Atendimento()
        {
            ValidationResult = new ValidationResult();
        }

        public Atendimento(string criadoPorId, string protocolo, int? canalOrigemId, long? midiaId)
        {
            CriadoPorUserId = criadoPorId;
            Protocolo = protocolo;
            CriadoEm = DateTime.Now;
            CanalOrigemId = canalOrigemId;
            MidiasId = midiaId;
            ValidationResult = new ValidationResult();
            ClienteSomenteContato = false;
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Protocolo))
                return false;
            else
                return true;
        }
    }
}