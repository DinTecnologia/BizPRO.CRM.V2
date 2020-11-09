using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IOcorrenciaAcompanhamentoRepositorio : IRepositorio<OcorrenciaAcompanhamento>
    {
        IEnumerable<OcorrenciaAcompanhamento> ObterAcompanhamentoPadrao(DateTime? dataInicio, DateTime? dataFinal,
            string criadoPorId, string responsavelId, bool? slaExcedido, string cliente, string status,
            long? ocorrenciaTipoId, long? departamentoId);
    }
}
