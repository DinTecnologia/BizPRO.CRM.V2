using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class OcorrenciaTiposXOcorrenciaServico : Servico<OcorrenciaTiposXOcorrencia>,
        IOcorrenciaTiposXOcorrenciaServico
    {
        private DynamicParameters _parametros = null;
        private readonly IOcorrenciaTiposXOcorrenciaRepositorio _repositorio;

        public OcorrenciaTiposXOcorrenciaServico(IOcorrenciaTiposXOcorrenciaRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public OcorrenciaTiposXOcorrencia ObterDadosOcorrenciaTiposXOcorrencia(long ocorrenciaId)
        {
            _parametros = new DynamicParameters();
            _parametros.Add("@ocorrenciaID", ocorrenciaId);
            var listaRetorno = _repositorio.ObterPorProcedimento("usp_front_sel_OcorrenciaTiposXOcorrencia", _parametros);
            return listaRetorno.FirstOrDefault();
        }
    }
}
