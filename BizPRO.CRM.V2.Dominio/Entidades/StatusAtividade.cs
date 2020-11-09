using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class StatusAtividade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public bool FinalizaAtendimento { get; set; }
        public bool GerarEntidade { get; set; }
        public string EntidadeNecessaria { get; set; }
        public string AtividadesValidas { get; set; }
        public bool StatusPadrao { get; set; }
        public bool FinalizaAtividade { get; set; }
        public int TipoAgendamento { get; set; }
        public string SentidosValidos { get; set; }
        public ValidationResult ValidationResult { get; private set; }
        public bool StatusDeSistema { get; set; }
        public string EntidadeNaoNecessaria { get; set; }
        public string TipoStatusAtividade { get; set; }
        public int? StatusAtividadeIdRequerida { get; set; }
        public int? TempoMaximoAtividadeEmMinutos { get; set; }

        public StatusAtividade()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
