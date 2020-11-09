using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Feriado
    {
        public long Id { get; private set; }
        public int Ano { get; private set; }
        public int Mes { get; private set; }
        public int Dia { get; private set; }
        public string Uf { get; private set; }
        public DateTime Data { get; private set; }
        public string Descricao { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public string CriadoPorUserId { get; private set; }
        public DateTime? AtualizadoEm { get; private set; }
        public string AtualizadoPorUserId { get; private set; }
        public bool Ativo { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public Feriado()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
