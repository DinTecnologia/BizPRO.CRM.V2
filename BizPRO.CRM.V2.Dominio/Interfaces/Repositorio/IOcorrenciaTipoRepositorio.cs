using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IOcorrenciaTipoRepositorio : IRepositorio<OcorrenciaTipo>
    {
        IEnumerable<OcorrenciaTipo> ObterOcorrenciasPai();
        IEnumerable<OcorrenciaTipo> ObterPor(long ocorrenciasTiposPaiId);
        IEnumerable<OcorrenciaTipo> ObterPrevisaoInicial(long ocorrenciaTipoId, DateTime? dataInicio);
    }
}