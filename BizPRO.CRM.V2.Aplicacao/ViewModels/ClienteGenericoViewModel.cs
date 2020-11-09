namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ClienteGenericoViewModel
    {
        public long AtividadeId { get; set; }
        public bool? PermitirClienteContato { get; set; }
        public string NomeAction { get; set; }
        public string NomeController { get; set; }
        public string NomeParametro { get; set; }
        public string ComponenteHtmlPerfilId { get; set; }
        public long? AtualClienteId { get; set; }
        public string AtualClienteTipo { get; set; }

        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public ClienteGenericoViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }

        public ClienteGenericoViewModel(long atividadeId, bool? permitirClienteContato, string nomeAction,
            string nomeController, string nomeParametro, string componenteHtmlPerfilId, long? atualClienteId,
            string atualClienteTipo)
        {
            AtividadeId = atividadeId;
            PermitirClienteContato = PermitirClienteContato;
            NomeAction = nomeAction;
            NomeController = nomeController;
            NomeParametro = nomeParametro;
            ComponenteHtmlPerfilId = componenteHtmlPerfilId;
            AtualClienteId = atualClienteId;
            AtualClienteTipo = atualClienteTipo;
            ValidationResult = new DomainValidation.Validation.ValidationResult();
            PermitirClienteContato = permitirClienteContato;
        }
    }
}
