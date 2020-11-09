using System.Collections.Generic;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface ITelefoneAppServico
    {
        IEnumerable<TelefoneListaViewModel> CarregarTelefones(long? pessoaFisicaId, long? pessoaFuridicaId,
            long? potenciaisClinteId);

        TelefoneListaViewModel AtualizarTelefone(long id, bool ativo);
        TelefoneViewModel SalvarTelefone(TelefoneViewModel view, string userId);
    }
}
