using BizPRO.CRM.V2.Aplicacao.ViewModels;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IAtividadeFilaAppServico
    {
        AtividadeFilaViewModel AdicionarAtividadeFila(AtividadeFilaViewModel atividadeFila);
        AtividadeFilaViewModel AddFinalizarAtividadeFila(AtividadeFilaViewModel atividadeFila);
        AtividadesFilaViewModel Carregar(string usuarioId, int filaId);
        AtividadesFilaViewModel CarregarViaDal(string usuarioId, int filaId);
    }
}
