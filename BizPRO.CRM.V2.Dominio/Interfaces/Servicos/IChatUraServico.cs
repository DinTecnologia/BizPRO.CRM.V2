using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IChatUraServico
    { 
        ChatUra ObterUra(long atividadeId, long? chatUraId, int? ordem);
    }
}
