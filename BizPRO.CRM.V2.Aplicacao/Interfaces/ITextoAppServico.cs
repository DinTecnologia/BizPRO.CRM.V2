using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface ITextoAppServico
    {
        TextoViewModel Novo(string usuarioId);

        TextoViewModel Adicionar(TextoViewModel model);

        List<TreeNode> ObterPorFila(int? filaId);

        List<TextoCategoriaItemViewModel> ObterCategorias(int? filaId);

        SelectList ObterStatusTexto(int? statusTextoId);

        TextoFiltroViewModel Carregar();

        IEnumerable<TextoListaViewModel> BuscarTexto(TextoFiltroViewModel model);

        TextoViewModel Editar(long id);

        TextoViewModel Atualizar(TextoViewModel model);
    }
}
