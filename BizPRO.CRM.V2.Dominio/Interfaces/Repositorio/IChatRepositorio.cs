using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IChatRepositorio : IRepositorio<Chat>
    {
        bool Online(int? filaId);
        Chat ObterPorAtividadeId(long atividadeId);
    }
}