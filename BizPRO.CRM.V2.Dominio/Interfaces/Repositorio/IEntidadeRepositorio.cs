using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IEntidadeRepositorio : IRepositorio<Entidade>
    {
        IEnumerable<Entidade> ObterPorSigla(string sigla);
        Entidade ObterEntidadePorNomeLogico(string nomeLogico);
        Entidade ObterPorNomeLogico(string nomeLogico);
    }
}
