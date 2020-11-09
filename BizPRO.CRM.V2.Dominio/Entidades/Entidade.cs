using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Entidade
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string NomeLogico { get; set; }
        public string Sigla { get; set; }
        public string CampoChave { get; set; }
        public string ScriptOnPage { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public Entidade()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
