using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IOcorrenciaXstatusEntidadeApoioServico : IServico<OcorrenciaXstatusEntidadeApoio>
    {
        IEnumerable<OcorrenciaXstatusEntidadeApoio> ListarOcorrenciaXstatusEntidadeApoio(string userId, DateTime? inicio,
            DateTime? fim, string status, string cliente, long? ocorrenciaTipoId);
    }
}
