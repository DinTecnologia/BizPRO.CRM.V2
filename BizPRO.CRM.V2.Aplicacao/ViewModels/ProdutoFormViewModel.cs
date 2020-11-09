using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ProdutoFormViewModel
    {      

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]        
        public string nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo código")]        
        public string codigo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? criadoEm { get; set; }

        [ScaffoldColumn(false)]
        public string criadoPor { get; set; }

        public bool Ativo { get; set; }

        public DateTime? alteradoEm { get; set; }

        public string alteradoPorUserID { get; set; }

        [Required(ErrorMessage = "Preencha o campo Tipo Produto")]
        public int tipoProdutoID { get; set; }        

        public ProdutoTipo ProdutoTipo { get; set; }

        [DisplayName("Tipo do produto")]        
        public IEnumerable<ProdutoTipo> ProdutoTipos { get; set; }

        public string descritivo { get; set; }
        public ProdutoFormViewModel()
        {

        }
    }
}
