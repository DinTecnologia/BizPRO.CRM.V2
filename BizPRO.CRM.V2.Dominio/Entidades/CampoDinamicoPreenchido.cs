using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class CampoDinamicoPreenchido
    {
        public long Id { get;  set; }
        public long ChaveEntidade { get; set; }
        public long CamposDinamicosId { get; set; }
        public long? CamposDinamicosOpcoesId { get; set; }
        public string ValorPreenchido { get; set; }
        public int EntidadesSecoesCamposDinamicosId { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public string AtualizadoPor { get; set; }
        public bool Ativo { get; set; }

        public CampoDinamicoOpcao CampoDinamicoOpcao { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public CampoDinamicoPreenchido()
        {
            ValidationResult = new ValidationResult();
            CriadoEm = DateTime.Now;
            Ativo = true;
        }
    }
}
