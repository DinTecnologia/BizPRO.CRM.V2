using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IEmailRemetenteRegraRepositorio : IRepositorio<EmailRemetenteRegra>
    {
        IEnumerable<EmailRemetenteRegra> ObterRemetentesRegras(int? filaId);
    }
}
