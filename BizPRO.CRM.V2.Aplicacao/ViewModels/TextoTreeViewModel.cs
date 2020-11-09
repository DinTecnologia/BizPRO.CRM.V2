using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class TextoCategoriaViewModel
    {
        public long CategoriaId { get; set; }

        public string CategoriaNome { get; set; }

        public long? CategoriaPaiId { get; set; }
    }

    public class TreeNode
    {
        public long TextoId { get; set; }
        public long CategoriaId { get; set; }
        public string CategoriaNome { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public TreeNode ParentCategory { get; set; }
        public List<TreeNode> Itens { get; set; }

        public int Ordem { get; set; }

        public bool EhPasta { get; set; }

        public int TipoId { get; set; }
    }    
}
