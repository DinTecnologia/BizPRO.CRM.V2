using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface ILigacaoAppServico
    {
        _LigacaoViewModel NovaLigacao(string tipo, string usuarioId, string informacaoUra, string numeroTelefone,
            string codLigacao, string terminal);

        _LigacaoViewModel Carregar(long? id, long? atividadiId);
    }
}
