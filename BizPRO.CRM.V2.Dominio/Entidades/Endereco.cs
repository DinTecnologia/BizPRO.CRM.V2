using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Endereco
    {
        public long EntidadeId { get; set; }
        public string TipoEntidade { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public string EnderecoCompleto
        {
            get { return string.Format("{0},{1},{2},{3}", Logradouro, Numero, Bairro, Estado); }
        }

        public string ValorCombo
        {
            get { return string.Format("{0}|{1}", TipoEntidade, EntidadeId); }
        }
        
        public Endereco()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
