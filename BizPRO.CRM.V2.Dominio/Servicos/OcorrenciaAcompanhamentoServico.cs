using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class OcorrenciaAcompanhamentoServico : IOcorrenciaAcompanhamentoServico
    {
        private readonly IOcorrenciaAcompanhamentoRepositorio _repositorio;

        public OcorrenciaAcompanhamentoServico(IOcorrenciaAcompanhamentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<OcorrenciaAcompanhamento> ObterAcompanhamentoPadrao(DateTime? dataInicio, DateTime? dataFinal,
            string criadoPorId, string responsavelId, bool? slaExcedido, string cliente, string status,
            long? ocorrenciaTipoId, int? departamentoId)
        {
            return _repositorio.ObterAcompanhamentoPadrao(dataInicio, dataFinal, criadoPorId, responsavelId, slaExcedido,
                cliente, status, ocorrenciaTipoId, departamentoId);
        }
    }
}
