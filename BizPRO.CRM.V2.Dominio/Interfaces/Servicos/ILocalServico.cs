using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface ILocalServico
    {
        IEnumerable<Local> Pesquisar(string segmento);
        IEnumerable<Local> Pesquisar(string segmento, double latitude, double longitude);
        Local ObterPorId(long localId);
        Local ObterLocalPorOcorrenciaId(long ocorrenciaId);
    }
}
