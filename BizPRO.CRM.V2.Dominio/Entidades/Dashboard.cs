using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Dashboard
    {
        public long PlaId { get; set; }
        public string PlaSigla { get; set; }
        public string PlaDescricao { get; set; }
        public int PlaQuantidade { get; set; }
        public double PlaPorcentagem { get; set; }
        public string PlaUsuario { get; set; }
        public string PlaUsuarioId { get; set; }
        public int PlaAtividadeTipoId { get; set; }
        public string PlaAtividadeTipoNome { get; set; }
        public int PlaStatusAtividadeId { get; set; }
        public int PlaSituacaoId { get; set; }
        public int PlaOrdem { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public Dashboard()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
