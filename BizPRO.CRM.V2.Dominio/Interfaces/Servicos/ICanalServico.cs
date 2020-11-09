using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface ICanalServico : IServico<Canal>
    {
        IEnumerable<Canal> ObterPorNome(string nome);
        Canal ObterCanalTelefone();
        Canal ObterCanalEmail();
        Canal ObterCanalChat();
        Canal ObterCanalMessenger();
    }
}

