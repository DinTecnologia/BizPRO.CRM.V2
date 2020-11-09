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
    public class ListaDePrecosProdutoViewModel
    {
        public int id { get; set; }

        public int ListasDePrecosID { get; set; }

        public int ProdutosID { get; set; }

        public string ProdutoNome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Valor Sugerido")]
        public float valorSugerido { get; set; }

        [Required(ErrorMessage = "Preencha o campo Valor Mínimo")]
        public float valorMinimo { get; set; }

        public bool valorLivre { get; set; }        

        public string criadoPorAspNetUsers { get; set; }

        public DateTime criadoEm { get; set; }

        public string alteradoPorAspNetUsers { get; set; }

        public DateTime? alteradoEm { get; set; }

        public ValidationResult ValidationResult { get; private set; }

       
    }
}
