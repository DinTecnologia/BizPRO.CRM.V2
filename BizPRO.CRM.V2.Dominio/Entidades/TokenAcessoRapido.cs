using DomainValidation.Validation;
using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class TokenAcessoRapido
    {
        public string Id { get; private set; }
        public string AspNetUsersId { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime? ExpiraEm { get; private set; }
        public bool ativo { get; private set; }
        public ValidationResult ValidationResult { get; private set; }

        public TokenAcessoRapido()
        {
            ValidationResult = new ValidationResult();
        }
        public TokenAcessoRapido(string aspNetUsersId)
        {
            this.AspNetUsersId = aspNetUsersId.ToString();
            this.Id = Guid.NewGuid().ToString();
            this.CriadoEm = DateTime.Now;
            this.ExpiraEm = DateTime.Now.AddDays(15);
            this.ativo = true;
        }
        public bool Ativo()
        {
            if (ativo && ExpiraEm > DateTime.Now)
                return true;
            else
                return false;
        }
    }
}
