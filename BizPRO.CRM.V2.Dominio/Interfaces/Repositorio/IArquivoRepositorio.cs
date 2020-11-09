using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IArquivoRepositorio : IRepositorio<Arquivo>
    {
        IEnumerable<Arquivo> ObterPor(long chaveEntidadeId, long entidadeId);
    }
}