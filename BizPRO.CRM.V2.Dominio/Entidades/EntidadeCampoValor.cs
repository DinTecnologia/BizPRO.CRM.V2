using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class EntidadeCampoValor
    {
        public long Id { get; private set; }
        public long EntidadeId { get; private set; }
        public string NomeCampo { get; private set; }
        public string Valor { get; private set; }
        public bool Ativo { get; private set; }
        public bool ValorPadrao { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public EntidadeCampoValor()
        {
            ValidationResult = new ValidationResult();
        }

        public EntidadeCampoValor(long entidadeId, string nomeCampo, string valor, bool ativo, bool valorPadrao)
        {
            EntidadeId = entidadeId;
            NomeCampo = nomeCampo;
            Valor = valor;
            Ativo = ativo;
            ValorPadrao = valorPadrao;
            ValidationResult = new ValidationResult();
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public void Ativar()
        {
            Ativo = true;
        }
    }
}
