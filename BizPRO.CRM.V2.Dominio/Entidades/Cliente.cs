using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Cliente
    {
        public long Id { get; set; }
        public string TipoCliente { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public DateTime DataNascimento { get; set; }
        public ValidationResult ValidationResult { get; private set; }
        public bool EntidadeIntegracao { get; set; }
        public long? IdentificadorIntegracao { get; set; }
        public bool RegistroJaIntegradao { get; set; }

        public Cliente()
        {
            ValidationResult = new ValidationResult();
        }

        public Cliente(long id, string nome, DateTime? dataNascimento, string tpCliente, string documento,
            long? identificadorIntegracao, bool registroJaIntegrado,
            bool entidadeIntegracao = false)
        {
            Id = id;
            Nome = nome;
            if (dataNascimento != null)
                DataNascimento = (DateTime) dataNascimento;
            TipoCliente = tpCliente;
            EntidadeIntegracao = entidadeIntegracao;
            IdentificadorIntegracao = identificadorIntegracao;
            Documento = documento;
            RegistroJaIntegradao = registroJaIntegrado;
        }
    }
}
