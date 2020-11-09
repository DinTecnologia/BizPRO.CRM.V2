using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BizPRO.CRM.V2.Identity.Model
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nome do Perfil")]
        public string Name { get; set; }
        public IEnumerable<MatrizClaim> Matriz { get; set; }
        public string[] selectedClaims { get; set; }
        public RoleViewModel()
        {
            Matriz = new List<MatrizClaim>();
            
        }        
    }

    public class MatrizClaim
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public List<SubClaim> SubClaims { get; set; }
        public MatrizClaim()
        {
            SubClaims = new List<SubClaim>();
        }
    }

    public class SubClaim
    {
        public string Nome { get; set; }
        public List<SubClaimColuna> Colunas { get; set; }
        public SubClaim()
        {
            Colunas = new List<SubClaimColuna>();
        }
    }

    public class SubClaimColuna
    {
        public string valor { get; set; }
        public string valorLimpo { get; set; }
        public string texto { get; set; }
        public bool selecionado { get; set; }

        public SubClaimColuna()
        {
            selecionado = false;
        }
    }
}