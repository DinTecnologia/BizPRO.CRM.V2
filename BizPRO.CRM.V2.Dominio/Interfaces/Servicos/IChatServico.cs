using System;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IChatServico : IServico<Chat>
    {
        ChatSolicitacao RegistrarSolicitacao(string campanhaId, int? filaId, string conexaoClienteId, string nome,
            string documento);

        Chat Novo(string usuarioId, long solicitacaoId, string conexaoClienteId, string nomeCliente,
            string conexaoAgenteId);

        int ObterQuantidadeConversaPorOperador(string usuarioId);

        bool Online(int? filaId);

        Chat ObterPorAtividadeId(long atividadeId);
    }
}