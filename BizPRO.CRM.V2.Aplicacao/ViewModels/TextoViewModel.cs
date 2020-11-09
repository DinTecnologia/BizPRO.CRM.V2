using System.Collections.Generic;
using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class TextoViewModel
    {
        public long? Id { get; set; }

        public int CategoriaId { get; set; }

        public int FormatoId { get; set; }

        public int TipoId { get; set; }

        public string Nome { get; set; }

        [Display(Name = "Texto")]
        public string Descricao { get; set; }

        public DateTime CriadoEm { get; set; }

        public string CriadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public string AtualizadoPor { get; set; }

        public bool Ativo { get; set; }

        public IEnumerable<SelectListItem> Filas { get; set; }

        public IEnumerable<SelectListItem> Formatos { get; set; }

        public IEnumerable<SelectListItem> Canais { get; set; }

        [Display(Name = "Categoria")]
        public SelectList Categorias { get; set; }

        public IEnumerable<SelectListItem> Tipos { get; set; }

        public List<TextoFilaViewModel> TextoFilas { get; set; }

        public string[] FilasSelecionadas { get; set; }

        public IEnumerable<CategoriaDdlViewModel> DdlsCategoria { get; set; }

        public int? FilaId { get; set; }
        
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        public TextoViewModel()
        {
            ValidationResult = new DomainValidation.Validation.ValidationResult();
        }
    }

    public class TextoItemViewModel
    {
        public long CategoriaId { get; set; }

        public long TextoId { get; set; }

        public long? CategoriaPaiId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int Ordem { get; set; }

        public TextoItemViewModel()
        {

        }
    }

    public class TextoFilaViewModel
    {
        public long Id { get; set; }

        public int FilaId { get; set; }
    }


    public class TextoFiltroViewModel
    {
        public IEnumerable<SelectListItem> Canais { get; set; }

        public IEnumerable<SelectListItem> Tipos { get; set; }

        public IEnumerable<SelectListItem> Filas { get; set; }

        public IEnumerable<SelectListItem> Formatos { get; set; }

        public int? FilaId { get; set; }
        public int? CanalId { get; set; }

        public int? TipoId { get; set; }

        public int? FormatoId { get; set; }
    }

    public class TextoListaViewModel
    {
        public long Id { get; set; }

        public string Categoria { get; set; }

        public string Nome { get; set; }

        public string Resumo { get; set; }

        public string CriadoEm { get; set; }

        public string CriadoPor { get; set; }

        public string Status { get; set; }
    }
}
