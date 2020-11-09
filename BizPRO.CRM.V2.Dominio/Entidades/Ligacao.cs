using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Ligacao
    {
        public long Id { get; private set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public long? PotencialClientesId { get; set; }
        public string UserId { get; set; }
        public string NumeroOriginal { get; set; }
        public long? TelefoneId { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public string Sentido { get; set; }
        public long AtividadeId { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public Atividade Atividade { get; set; }
        public Fila Fila { get; set; }
        public Telefone Telefone { get; set; }

        public string Documento { get; set; }

        public Ligacao()
        {
            ValidationResult = new ValidationResult();
        }

        public Ligacao(long? pessoaFisicaId, long? pessoaJuridicaId, long? potencialClientesId, string userId,
            string sentido, long atividadeId, long? telefoneId, string numeroOriginal, Atividade atividade, string documento)
        {
            PessoaFisicaId = pessoaFisicaId;
            PessoaJuridicaId = pessoaJuridicaId;
            PotencialClientesId = potencialClientesId;
            UserId = userId;
            Sentido = sentido;
            AtividadeId = atividadeId;
            CriadoEm = DateTime.Now;
            NumeroOriginal = numeroOriginal;
            TelefoneId = telefoneId;
            Atividade = atividade;
            ValidationResult = new ValidationResult();
            Documento = documento;
        }

        public bool? Receptiva
        {
            get
            {
                return string.IsNullOrEmpty(Sentido) ? (bool?) null : (Sentido.ToLower().TrimEnd().TrimStart() == "e");
            }
        }
    }
}
