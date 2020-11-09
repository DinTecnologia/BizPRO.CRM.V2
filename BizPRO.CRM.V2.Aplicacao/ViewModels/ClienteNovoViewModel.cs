namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ClienteNovoViewModel
    {
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public long? AtividadeId { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public bool CarregarComPost { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public bool? ClienteContato { get; set; }
        public long? AtualClienteId { get; set; }
        public string AtualClienteTipo { get; set; }

        public string Documento { get; set; }


        public ClienteNovoViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
    }
}
