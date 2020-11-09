using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface ILigacaoServico : IServico<Ligacao>
    {
        Ligacao InserirAtividadeELigacao(Atividade entidade, string numeroOriginal, string sentido);
        Ligacao InserirLigacao(Ligacao ligacao);
        Ligacao BuscarPorAtividadeId(long atividadeId);
        Ligacao AdicionarLigacaoReceptiva(string criadoPorUserId, string numeroOriginal, long? telefoneId);
        Ligacao ObterLigacaoReceptivaUra(string numeroTelefone);
        Ligacao BuscarLigacaoCompleta(long? ligacaoId, long? atividadeId);
        void AtualizarLigacaoGeradorProtocoloUra(string userId, long ligacaoId, long atividadeId, long atendimentoId);
        Ligacao AdicionarLigacaoProtocoloUra(string numeroOriginal, string documento);
        Ligacao ObterPor(long? id, long? atividadeId);
    }
}
