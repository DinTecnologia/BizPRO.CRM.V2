using System.Collections.Generic;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface ICategoriaAppServico
    {
        CategoriaFormViewModel Adicionar();

        CategoriaFormViewModel Adicionar(CategoriaFormViewModel model);

        IEnumerable<CategoriaListaViewModel> Listar();

        CategoriaFormViewModel Editar(long id);

        CategoriaFormViewModel Atualizar(CategoriaFormViewModel model);

    }
}
