using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class EntidadeSecaoCampoDinamico
    {
        public int Id { get; private set; }
        public long CamposDinamicosId { get; set; }
        public long EntidadesSecoesId { get; set; }
        public bool Ativo { get; set; }
        public int Ordem { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public EntidadeSecaoCampoDinamico()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
