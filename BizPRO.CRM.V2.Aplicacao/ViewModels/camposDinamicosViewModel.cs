using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class camposDinamicosViewModel
    {
        public long id { get; private set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public long entidadeID { get; set; }
        public bool obrigatorio { get; set; }
        public bool ativo { get; set; }
        public bool multiplaEscolha { get; set; }   
        public ValidationResult ValidationResult { get; private set; }

        public camposDinamicosViewModel(long id, string nome, bool ativo)
        {
            this.id = id;
            this.nome = nome;
            this.ativo = ativo;
        }
    }
}
