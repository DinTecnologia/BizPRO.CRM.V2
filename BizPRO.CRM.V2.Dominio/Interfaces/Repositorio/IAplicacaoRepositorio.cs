using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IAplicacaoRepositorio : IRepositorio<Dominio.Entidades.Aplicacao>
    {
        IEnumerable<Dominio.Entidades.Aplicacao> BuscarAplicacao(string host);
        IEnumerable<Dominio.Entidades.Aplicacao> ObterAplicacao(string nome);
    }
}
