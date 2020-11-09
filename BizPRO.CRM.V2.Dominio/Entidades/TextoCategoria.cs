using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class TextoCategoria
    {
        public long Id { get; set; }

        public string Nome { get; set; }

        public long? TextoCategoriaPaiId { get; set; }


        public string NomeExibicao { get; set; }

        public string EstruturaDeIds { get; set; }

        public bool EhUltimoNivel { get; set; }

        public DateTime CriadoEm { get; set; }

        public string CriadoPor { get; set; }

        public DateTime? AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; }

        public bool Ativo { get; set; }        

        public ValidationResult ValidationResult { get; set; }

        public TextoCategoria()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
