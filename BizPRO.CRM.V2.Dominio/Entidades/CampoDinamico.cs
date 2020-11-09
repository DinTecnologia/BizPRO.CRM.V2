using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class CampoDinamico
    {
        public long Id { get;  set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public long EntidadeId { get; set; }
        public bool Obrigatorio { get; set; }
        public bool Ativo { get; set; }
        public bool MultiplaEscolha { get; set; }
        public bool CarregarOpcoes { get; set; }

        public IEnumerable<CampoDinamicoOpcao> ListaOpcoes { get; set; }
        public EntidadeSecaoCampoDinamico EntidadeSecaoCampoDinamico { get; set; }
        public IEnumerable<CampoDinamicoPreenchido> ListaCampoDinamicoPreenchido { get; set; }
        public ValidationResult ValidationResult { get; private set; }
        public Entidade Entidade { get;  set; }
        public EntidadeSecao EntidadeSecao { get; set; }

        public CampoDinamico()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
