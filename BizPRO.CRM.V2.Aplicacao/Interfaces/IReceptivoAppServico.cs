using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IReceptivoAppServico
    {
        DomainValidation.Validation.ValidationResult AtualizarStatusAtividade(long ligacaoId, int statusAtividadeId, long atendimentoId, long atividadeId,
            string userId, int midiasId);

        ReceptivoViewModel NovaLigacaoReceptiva(string userId, string informacaoUra, string numeroTelefone,
            string codLigacao, string terminal);

        ReceptivoViewModel Carregar(long atividadeId, bool novoClienteTratativa);
        SelectList ObterTiposClienteContato();
        ReceptivoViewModel GerarProtocolo(string numeroTelefone, string numero);
    }
}
