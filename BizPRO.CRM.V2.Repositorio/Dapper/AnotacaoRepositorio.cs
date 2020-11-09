using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Contexto.Interfaces;
using System.Collections.Generic;
using Dapper;
using System.Data;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class AnotacaoRepositorio : Repositorio<Anotacao>, IAnotacaoRepositorio
    {
        public AnotacaoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Anotacao> ObterPorTarefaId(long id)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@tarefaID", id);

            var retorno = Conn.Query<Anotacao, Usuario, Anotacao>("usp_front_sel_AnotacoesPorTarefaID",
                (ret, user) =>
                {
                    ret.CriadoPorUser = user;
                    return ret;
                },
                parametros,
                splitOn: "Id,id",
                commandType: CommandType.StoredProcedure);

            return retorno;
        }

        public IEnumerable<Anotacao> ObterPorOcorrenciaId(long id)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@OcorrenciaID", id);

            var retorno = Conn.Query<Anotacao, Usuario, Anotacao>("usp_front_sel_AnotacoesPorOcorrenciaID",
                (ret, user) =>
                {
                    ret.CriadoPorUser = user;
                    return ret;
                },
                parametros,
                splitOn: "Id,id",
                commandType: CommandType.StoredProcedure);

            return retorno;
        }

        public IEnumerable<Anotacao> ObterPor(long? ocorrenciaId, long? atividadeId, long? pessoaFisicaId,
            long? pessoaJuridicaId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ocorrenciaID", ocorrenciaId);
            parametros.Add("@atividadeID", atividadeId);
            parametros.Add("@pessoaFisicaID", pessoaFisicaId);
            parametros.Add("@pessoaJuridicaID", pessoaJuridicaId);
            return ObterPorProcedimento("usp_front_sel_Anotacoes", parametros);
        }
    }
}
