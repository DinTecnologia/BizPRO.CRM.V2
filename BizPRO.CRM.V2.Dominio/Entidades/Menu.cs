using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Menu
    {
        public int id { get; private set; }
        public string nome { get; set; }
        public int? menuPai { get; set; }
        public string tipo { get; set; }
        public int? funcionalidadeID { get; set; }
        public Funcionalidade Funcionalidade { get; set; }
        public IEnumerable<Fila> Filas { get; set; }
        public string tipoAbertura { get; set; }
        public int ordem { get; set; }
        public string icone { get; set; }
        public int aplicacaoId { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public Menu()
        {
            ValidationResult = new ValidationResult();
            Funcionalidade = new Funcionalidade();
            Filas = new List<Fila>();
        }
    }
}
