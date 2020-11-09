using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class EntidadeSecao
    {
        public long Id { get; set; }
        public long EntidadesId { get; set; }
        public string Nome { get; set; }
        public int Ordem { get; set; }
        public string Aba { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public EntidadeSecao()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
