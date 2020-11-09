using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "required")]
        public string nome { get; set; }

        public string codigo { get; set; }

        public int tipoProdutoID { get; set; }        

        public virtual ProdutoTipo ProdutoTipo { get; set; }

        [DisplayName("Tipo do produto")]
        public IEnumerable<ProdutoTipo> ProdutoTipos { get; set; }
        

        public ProdutoViewModel()
        {

        }

        public ProdutoViewModel(int Id,string nome, string codigo)
        {
            this.nome = nome;
            this.codigo = codigo;
            this.Id = Id;
        }
    }
}
