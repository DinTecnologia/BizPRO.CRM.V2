using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IViewDinamicaAppServico
    {
        List<ContratoProdutoViewModel> ListaProdutoCamposDinamicos(long contratoId);

        CampoDinamicoViewModel Carregar(string siglaEntidade, string nomeAba, string nomeSecao, long? id,
            bool podeEditar);

        CampoDinamicoViewModel Editar(long id, string siglaEntidade, string nomeAba, string nomeSecao);
        CampoDinamicoViewModel Atualizar(CampoDinamicoViewModel viewModel, string usuarioId);
        CampoDinamicoViewModel Adicionar(CampoDinamicoViewModel viewModel, string usuarioId);
    }
}

