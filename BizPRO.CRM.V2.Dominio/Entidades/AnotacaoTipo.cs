using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class AnotacaoTipo
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public bool Padrao { get; set; }
        public DateTime CriadoEm { get; set; }
        public string CriadoPorUserId { get; set; }
        public bool Ativo { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public AnotacaoTipo()
        {

        }
    }
}
