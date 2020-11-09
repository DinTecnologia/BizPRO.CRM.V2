using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class ClienteProduto
    {
        public long Id { get; set; }
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public ClienteProduto()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
