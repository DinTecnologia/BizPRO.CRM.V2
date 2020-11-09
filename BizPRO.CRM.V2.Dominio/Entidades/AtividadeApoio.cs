using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class AtividadeApoio
    {
        public string Tipo { get; set; }
        public string Titulo { get; set; }
        public DateTime CriadoEm { get; set; }
        public string Descricao { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public string Responsavel { get; set; }
        public DateTime? PrevisaoDeExecucao { get; set; }
        public long AtividadeId { get; set; }
        public long AtividadeTipoId { get; set; }
        public string Cliente { get; set; }
        public string Fila { get; set; }
        public string Referente { get; set; }
        public string Status { get; set; }
        public string CriadoPor { get; set; }
        public bool AtrasadoAtribuicao { get; set; }
        public bool AtrasadoFechamento { get; set; }
        public bool PossuiSlaAtribuicao { get; set; }
        public bool PossuiSlaFechamento { get; set; }
        public string MotivoOcorrencia { get; set; }
        public bool AtividadeFinalizada { get; set; }


        public ValidationResult ValidationResult { get; set; }
        public AtividadeApoio()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
