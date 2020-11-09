using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IStatusAtividadeServico : IServico<StatusAtividade>
    {
        StatusAtividade ObterStatusAtividadePadraoParaLigacao();
        StatusAtividade ObterStatusAtividadePadraoParaChatPadrao();
        StatusAtividade ObterStatusAtividadePadraoFinalizaParaEmail();
        StatusAtividade ObterStatusAtividadePadraoTarefa();

        IEnumerable<StatusAtividade> ObterStatusAtividadeLigacaoReceptiva();
        IEnumerable<StatusAtividade> ObterStatusAtividadeLigacaoAtiva();

        IEnumerable<StatusAtividade> ObterStatusAtividadeChat();
        IEnumerable<StatusAtividade> ObterStatusAtividadeMessenger();
        IEnumerable<StatusAtividade> ObterStatusAtividadeTarefa();
        IEnumerable<StatusAtividade> ObterStatusAtividadeEmail();
        IEnumerable<StatusAtividade> ObterStatusAtividadeEmailRecebido();
        IEnumerable<StatusAtividade> ObterStatusAtividadeEmailEnviado();
        IEnumerable<StatusAtividade> ObterTodos();
        IEnumerable<StatusAtividade> ObterPor(int canal, string sentido, bool? padrao);
        IEnumerable<StatusAtividade> ObterStatusAtividade(string descricao, string atividadeValida);
        //IEnumerable<StatusAtividade> BuscarStatusAtividadeTratativaEmail();
        bool VerificarEntidadeRequeridaAtendimento(long atendimentoId, long statusAtividadeId);
        bool VerificarEntidadeNaoRequeridaAtendimento(long atendimentoId, long statusAtividadeId);
        bool VerificarTempoAtividade(long atividadeId, long statusAtividadeId);
        bool VerificarStatusAtividadeRequerida(long atividadeId, long statusAtividadeId);
    }
}
