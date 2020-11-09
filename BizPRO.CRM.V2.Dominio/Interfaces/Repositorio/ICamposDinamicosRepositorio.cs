using System;
using System.Data;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface ICamposDinamicosRepositorio
    {
        DataSet ProcessoTabelaDinamica(string campos, string userId, DateTime? inicio, DateTime? fim, string status,
            string cliente, long? ocorrenciaTipoId);

        DataSet ObterOcorrenciasExportar(string campos, string usuarioid, DateTime? dataInicio, DateTime? dataFim,
            string stautsIds, string cliente, long? ocorrenciaTipoId, string camposDinamicosOcorrenciaId,
            string camposDinamicosContratoId);
    }
}
