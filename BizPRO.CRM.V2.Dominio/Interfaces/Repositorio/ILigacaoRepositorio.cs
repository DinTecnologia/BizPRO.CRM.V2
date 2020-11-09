using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface ILigacaoRepositorio : IRepositorio<Ligacao>
    {
        Ligacao BuscarCompletoPorId(long? ligacaoId, long? atividadeId);
        Ligacao ObterLigacaoReceptivaUra(string numeroTelefone);
        void AtualizarLigacaoGeradorProtocoloUra(string userId, long ligacaoId, long atividadeId, long atendimentoId);
    }
}
