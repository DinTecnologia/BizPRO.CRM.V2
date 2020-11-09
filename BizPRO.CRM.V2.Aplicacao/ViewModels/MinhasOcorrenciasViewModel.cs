using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class MinhasOcorrenciasViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string EntidadesValidas { get; set; }
        public bool Padrao { get; set; }
        public bool Finalizador { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public MinhasOcorrenciasViewModel
        (
            long id
            , string nome
            , bool ativo
            , string entidadesValidas
            , bool padrao
            , bool finalizador
        )
        {
            Id = id;
            Nome = nome;
            Ativo = ativo;
            EntidadesValidas = entidadesValidas;
            Padrao = padrao;
            Finalizador = finalizador;
            ValidationResult = new ValidationResult();
        }
    }
}
