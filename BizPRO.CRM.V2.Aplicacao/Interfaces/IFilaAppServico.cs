using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IFilaAppServico
    {
        IEnumerable<FilaViewModel> ObterTodos();
        FilaViewModel SalvarFila(FilaViewModel viewModel, string userId);
        ComboFilaViewModel ComboFilas(bool? ativo, long? filaId);
        FilaViewModel ObterPorId(long? filaId);
        bool UsuarioPossuiFilaEmail(string userId);
        long ObterFilasPorNome(string nome);
        bool UsuarioPossuiFilaChat(string userId);
        bool UsuarioPossuiFilaMessenger(string userid);
        FilaViewModel UsuarioPossuiFilaMessenger(string userId, long idfila);
        AlterarFilaFormViewModel CarregarAlterarFila(long atividadeId);
        AlterarFilaFormViewModel RedirecionarFila(AlterarFilaFormViewModel viewModel);
        SelectList ObterPor(FilaFilterViewModel model);
        SelectList ObterFilaPorCanalId(int? canalId);
    }
}
