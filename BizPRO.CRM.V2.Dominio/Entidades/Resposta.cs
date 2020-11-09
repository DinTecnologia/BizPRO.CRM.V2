using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Resposta
    {
        public long Id { get; set; }
        public int EntidadeId { get; set; }
        public long RespostaPaiId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public string AtualizadoPor { get; set; }
        public bool Ativo { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public Resposta()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
