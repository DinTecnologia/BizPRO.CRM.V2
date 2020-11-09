using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class OcorrenciaXstatusEntidadeApoioServico : Servico<OcorrenciaXstatusEntidadeApoio>,
        IOcorrenciaXstatusEntidadeApoioServico
    {
        private DynamicParameters _parametros;

        private readonly IOcorrenciaXstatusEntidadeApoioRepositorio _repositorio;

        public OcorrenciaXstatusEntidadeApoioServico(IOcorrenciaXstatusEntidadeApoioRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<OcorrenciaXstatusEntidadeApoio> ListarOcorrenciaXstatusEntidadeApoio(string userId,
            DateTime? inicio, DateTime? fim, string status, string cliente, long? ocorrenciaTipoId)
        {
            var retorno = new List<OcorrenciaXstatusEntidadeApoio>();

            _parametros = new DynamicParameters();

            if (!userId.Equals(""))
                _parametros.Add("@UserID", userId);

            if (status != null && !status.Equals(""))
                _parametros.Add("@status", status);

            if (string.IsNullOrEmpty(cliente))
                _parametros.Add("@cliente", cliente);

            if (ocorrenciaTipoId != null)
                _parametros.Add("@ocorrenciaTipoID", ocorrenciaTipoId);

            _parametros.Add("@inicio", inicio);

            _parametros.Add("@fim", fim);

            var listaRetorno = _repositorio.ObterPorProcedimento("usp_front_sel_OcorrenciaXstatusEntidade", _parametros);
            return listaRetorno.AsList();
        }
    }
}
