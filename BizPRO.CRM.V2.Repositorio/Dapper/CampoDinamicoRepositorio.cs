using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Collections.Generic;
using Dapper;
using System.Data;


namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class CampoDinamicoRepositorio : Repositorio<CampoDinamico>, ICampoDinamicoRepositorio
    {
        public CampoDinamicoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<CampoDinamico> ObterPor(string siglaEntidade, string aba, string secao)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@siglaEntidade", siglaEntidade);
            parametros.Add("@nomeAba", aba);
            if (!string.IsNullOrEmpty(secao))
                parametros.Add("@secao", secao);

            var retorno =
                Conn.Query<CampoDinamico, EntidadeSecaoCampoDinamico, EntidadeSecao, CampoDinamico>(
                    "usp_front_sel_CamposDinamicos",
                    (ret, entidadeSecaoCampoDinamico, entidadeSecao) =>
                    {
                        ret.EntidadeSecaoCampoDinamico = entidadeSecaoCampoDinamico;
                        ret.EntidadeSecao = entidadeSecao;
                        return ret;
                    },
                    parametros,
                    splitOn: "id,id",
                    commandType: CommandType.StoredProcedure);

            return retorno;
        }

        public IEnumerable<CampoDinamico> ObterCamposDinamicosPorEntidade(string procedimento,
            DynamicParameters parametros)
        {
            var retorno =
                Conn.Query<CampoDinamico, Entidade, EntidadeSecao, EntidadeSecaoCampoDinamico, CampoDinamico>(
                    procedimento,
                    (ret, ent, entSec, entSecCamDin) =>
                    {
                        ret.Entidade = ent;
                        ret.EntidadeSecao = entSec;
                        ret.EntidadeSecaoCampoDinamico = entSecCamDin;
                        return ret;
                    },
                    parametros,
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure);

            return retorno;
        }
    }
}
