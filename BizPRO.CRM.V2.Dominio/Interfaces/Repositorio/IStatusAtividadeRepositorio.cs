using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IStatusAtividadeRepositorio : IRepositorio<StatusAtividade>
    {
        IEnumerable<StatusAtividade> BuscarStatusAtividadesTratativaEmail();

        IEnumerable<StatusAtividade> ObterStatusAtividades(string descricao, string atividadesValidas,
            bool? statusPadrao, bool? finalizaAtividade, bool? finalizaAtendimento, bool? ativo,
            string sentidosValidos = null, bool? statusDeSistema = false);

        bool VerificarEntidadeRequeridaAtendimento(long atendimentoId, long statusAtividadeId);
        bool VerificarEntidadeNaoRequeridaAtendimento(long atendimentoId, long statusAtividadeId);

        bool VerificarTempoAtividade(long atividadeId, long statusAtividadeId);
        bool VerificarStatusAtividadeRequerida(long atividadeId, long statusAtividadeId);
    }
}
