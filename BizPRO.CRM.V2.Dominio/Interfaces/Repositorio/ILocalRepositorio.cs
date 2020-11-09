using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface ILocalRepositorio : IRepositorio<Local>
    {
        IEnumerable<Local> Pesquisar(string segmento);
        IEnumerable<Local> Pesquisar(string segmento, double latitude, double longitude);
        Local ObterLocalPorOcorrenciaId(long ocorrenciaId);
    }
}
