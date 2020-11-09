using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ProdutoContratoIntegracao
    {
        public string Apolice { get; set; }
        public string DescricaoItem { get; set; }
        public string PequenoPorte { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Segmento { get; set; }
        public string Cobertura { get; set; }
        public string Marca { get; set; }
        public string PlanoAxa { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public ProdutoContratoIntegracao()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
