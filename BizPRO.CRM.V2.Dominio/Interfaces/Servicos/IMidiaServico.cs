using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IMidiaServico
    {
        IEnumerable<Midia> ObterTodos();
        Midia ObterPorId(int midiaId);
        IEnumerable<Midia> ObterPor(string nome, int? canalId);
    }
}
