using DomainValidation.Validation;
using System;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Texto
    {
        public long Id { get; set; }

        public int FormatoId { get; set; }

        public int CategoriaId { get; set; }

        public int TipoId { get; set; }        

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime CriadoEm { get; set; }

        public string CriadoPor { get; set; }

        public DateTime? AtualizadoEm { get; set; }

        public string AtualizadoPor { get; set; }

        public bool Ativo { get; set; }
        public ValidationResult ValidationResult { get; private set; }
        
        //public string Fila { get; set; }

        public string Categoria { get; set; }

        //public long CategoriaId { get; set; }

        public long? CategoriaPaiId { get; set; }

        public TextoCategoria CategoriaObj { get; set; }

        public Usuario CriadoPorObj { get; set; }


        public Texto()
        {
            CriadoEm = DateTime.Now;
            ValidationResult = new ValidationResult();
        }
    }
}
