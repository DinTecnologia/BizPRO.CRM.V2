using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IPessoaJuridicaContatosAppServico
    {
        PessoaJuridicaContatoViewModel InserirContato(long pessoaFisicaId, long pessoaJuridicaId, string userId);

        IEnumerable<PessoaJuridicaContatoViewModel> ListarPessoaJuridicaContato(long? pessoaJuridicaId,
            long? pessoaFisicaId);

        IEnumerable<PessoaJuridicaContatoViewModel> InserirListarPessoaJuridicaContato(long pessoaFisicaId,
            long pessoaJuridicaId, string userId);

        IEnumerable<PessoaJuridicaContatoViewModel> InserirListarPessoaFisicaContato(long pessoaFisicaId,
            long pessoaJuridicaId, string userId);

        PessoaJuridicaContatoViewModel AtualizarContato(long pessoaJuridicaTipoContatoId, long pessoaJuridicaContatoId,
            string userId);

        PessoaJuridicaContatoViewModel DeletarContato(long pessoaJuridicaContatoId, string userId);

        IEnumerable<PessoaJuridicaContatoViewModel> DeletarListarContatoPessoaJuridica(long pessoaJuridicaContatoId,
            long pessoaJuridicaId, string userId);

        IEnumerable<PessoaJuridicaContatoViewModel> DeletarListarContatoPessoaFisica(long pessoaJuridicaContatoId,
            long pessoaFisicaId, string userId);
    }
}
