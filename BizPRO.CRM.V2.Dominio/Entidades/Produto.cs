using System;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    /// <summary>
    /// Produto
    /// </summary>
    public class Produto
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }
        public int tipoProdutoID { get; set; } 
        public DateTime? criadoEm { get; set; }
        public string criadoPorUserID { get; set; }
        public DateTime? alteradoEm { get; set; }
        public string alteradoPorUserID { get; set; }
        public string descritivo { get; set; }
        public ProdutoTipo sProdutoTipo { get; set; }
        public ValidationResult ValidationResult { get; private set; }
        public Produto()
        {
            ValidationResult = new ValidationResult();
        }
        public string NomeLista
        {
            get { return string.Format("{0} - {1}", nome, codigo); }
        }
    }
}

