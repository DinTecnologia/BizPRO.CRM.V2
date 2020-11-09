using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class CategoriaFormViewModel
    {
        public long? Id { get; set; }

        public string Nome { get; set; }

        public long? TextoCategoriaPaiId { get; set; }

        public string NomeExibicao { get; set; }

        public DateTime CriadoEm { get; set; }

        public string CriadoPor { get; set; }

        public string AtualizadoPor { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Categoria")]
        public SelectList Categorias { get; set; }

        public IEnumerable<CategoriaDdlViewModel> DdlsCategoria { get; set; }


        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }


        public CategoriaFormViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }

    }

    public class CategoriaListaViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }

        public string Status { get; set; }

        public string CriadoEm { get; set; }

        public string CriadoPor { get; set; }
    }
}