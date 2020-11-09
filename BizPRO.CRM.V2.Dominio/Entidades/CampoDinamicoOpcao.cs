using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class CampoDinamicoOpcao
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public long CamposDinamicosId { get; set; }        
        public CampoDinamico CampoDinamico { get; set; }
        public ValidationResult ValidationResult { get; private set; }
        public bool Selecionado { get; set; }
        public CampoDinamicoOpcao()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
