using System.Collections.Generic;
using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IContatoAppServico
    {
        IEnumerable<ContatoViewModel> ObterContatosPorCliente(long? pessoaFisicaId, long? pessoaJuridicaId, int? quantidade);
    }
}
