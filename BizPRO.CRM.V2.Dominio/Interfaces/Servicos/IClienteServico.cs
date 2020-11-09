using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IClienteServico : IServico<Cliente>
    {
        IEnumerable<Cliente> Buscar(string nome, string data, string telefone, string numeroProtocolo, string susep);
        IEnumerable<Cliente> ObterSugestoes(string nome, string documento, string telefone, string email, bool registroComTodosCamposFornecidos = true);
    }
}
