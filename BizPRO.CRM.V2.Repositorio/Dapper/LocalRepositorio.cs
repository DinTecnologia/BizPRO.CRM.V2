using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class LocalRepositorio : Repositorio<Local>, ILocalRepositorio
    {
        public LocalRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Local> Pesquisar(string segmento)
        {
            var where = new DynamicParameters();
            where.Add("@segmento", segmento);
            return ObterPorProcedimento("usp_front_sel_LocalPesquisa", where);
        }

        public IEnumerable<Local> Pesquisar(string segmento, double latitude, double longitude)
        {
            var where = new DynamicParameters();
            where.Add("@segmento", segmento);
            where.Add("@latitude", latitude);
            where.Add("@longitude", longitude);
            return ObterPorProcedimento("usp_front_sel_LocaisPorSegmentoEDistancia", where);
        }

        public Local ObterLocalPorOcorrenciaId(long ocorrenciaId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ocorrenciaID", ocorrenciaId);

            var retorno =
                Conn.Query<Local, OcorrenciaLocalTipoAtendimento, LocalTipo, LocalTipoAtendimento, Local>(
                    "usp_front_sel_LocalPorOcorrenciaID",
                    (ret, localOcorrencia, localTipo, localTipoAtendimento) =>
                    {
                        ret.LocalOcorrencia = localOcorrencia;
                        ret.LocalTipo = localTipo;
                        ret.LocalOcorrencia.LocalTipoAtendimento = localTipoAtendimento;
                        return ret;
                    },
                    parametros,
                    splitOn: "Id,id,nome,nome",
                    commandType: CommandType.StoredProcedure);

            return retorno.FirstOrDefault();
        }
    }
}
