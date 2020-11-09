using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IEmailAnexoRepositorio : IRepositorio<EmailAnexo>
    {
        IEnumerable<EmailAnexo> ObterAnexos(long atividadeId);
        IEnumerable<EmailAnexo> ObterDiretoriosEmailAnexo(DateTime? data);
    }
}
