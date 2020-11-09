using DomainValidation.Validation;
using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{    
    public class LocalTipoAtendimento
    {
        public long id { get; private set; }
        public string nome { get; set; }
        public bool ativo { get; set; }
        public string criadoPorUserID { get; set; }
        public DateTime criadoEm { get; set; }
        public string alteradoPorUserID { get; set; }
        public DateTime alteradoEm { get; set; }
        public ValidationResult ValidationResult { get; private set; }

        public LocalTipoAtendimento()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
