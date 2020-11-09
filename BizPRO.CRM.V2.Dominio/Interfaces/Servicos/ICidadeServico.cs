using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface ICidadeServico : IServico<Cidade>
    {
        IEnumerable<Cidade> ObterTodosEstados();
        IEnumerable<Cidade> ObterCidadesPorEstado(string uf);
        IEnumerable<Cidade> ObterCidadesSemAcento(string cidade);
    }
}
