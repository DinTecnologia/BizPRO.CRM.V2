using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IClienteRepositorio : IRepositorio<Cliente>
    {
        IEnumerable<Cliente> ObterClientesPorNumeroProtocolo(string numeroProtocolo);

        IEnumerable<Cliente> ObterClientesBusca(string nome, string documento, string telefone, string email,
            string protocolo, string susep, bool registroComTodosCamposFornecidos);
    }
}
