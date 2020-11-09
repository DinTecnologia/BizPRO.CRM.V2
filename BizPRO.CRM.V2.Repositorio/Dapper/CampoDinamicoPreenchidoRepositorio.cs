using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Collections.Generic;
using DapperExtensions;
using System.Data;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class CampoDinamicoPreenchidoRepositorio : Repositorio<CampoDinamicoPreenchido>,
        ICampoDinamicoPreenchidoRepositorio
    {
        public CampoDinamicoPreenchidoRepositorio(IDapperContexto context)
            : base(context)
        {
        }

        public IEnumerable<CampoDinamicoPreenchido> ObterPor(long campoDinamicoId, long entidadesSecoesCamposDinamicosId,
            long chaveEntidadeId)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<CampoDinamicoPreenchido>(f => f.CamposDinamicosId, Operator.Eq,
                campoDinamicoId));
            where.Predicates.Add(Predicates.Field<CampoDinamicoPreenchido>(f => f.EntidadesSecoesCamposDinamicosId,
                Operator.Eq, entidadesSecoesCamposDinamicosId));
            where.Predicates.Add(Predicates.Field<CampoDinamicoPreenchido>(f => f.ChaveEntidade, Operator.Eq,
                chaveEntidadeId));
            return ObterPor(where);
        }

        public IEnumerable<CampoDinamicoPreenchido> ObterPor(long campoDinamicoId, string siglaEntidade, string nomeAba)
        {
            var where = new DynamicParameters();
            where.Add("@campoDinamicoID", campoDinamicoId);
            where.Add("@siglaEntidade", siglaEntidade);
            where.Add("@nomeAba", nomeAba);
            return ObterPorProcedimento("usp_front_sel_CamposDinamicosPreenchidos", where);
        }

        public void Deletar(long chaveEntidade, long entidadesSecoesCamposDinamicosId, long camposDinamicosId,
            string usuarioId)
        {
            var where = new DynamicParameters();
            where.Add("@chaveEntidade", chaveEntidade);
            where.Add("@EntidadesSecoesCamposDinamicosID", entidadesSecoesCamposDinamicosId);
            where.Add("@camposDinamicosID", camposDinamicosId);
            where.Add("@UsuarioId", usuarioId);
            ExecutarProcedimento("usp_front_del_CamposDinamicosPreenchidos", where);
        }

        public IEnumerable<CampoDinamicoPreenchido> ObterRespostasCamposDinamicosPorEntidade(string procedimento,
            DynamicParameters parametros)
        {
            var retorno = Conn.Query<CampoDinamicoPreenchido, CampoDinamicoOpcao, CampoDinamicoPreenchido>(procedimento,
                (ret, cdp) =>
                {
                    ret.CampoDinamicoOpcao = cdp;
                    return ret;
                },
                parametros,
                splitOn: "Id",
                commandType: CommandType.StoredProcedure);

            return retorno;
        }

        public IEnumerable<CampoDinamicoPreenchido> ObterPor(string entidadeSigla, string abaSecao,
            string campoDinamicoNome, long chaveEntidade)
        {
            var where = new DynamicParameters();
            where.Add("@sigla", entidadeSigla);
            where.Add("@secao", abaSecao);
            where.Add("@campoDinamicoNome", campoDinamicoNome);
            where.Add("@chaveEntidade", chaveEntidade);
            return ObterPorProcedimento("usp_front_sel_CampoDinamicoPreenchido", where);
        }
    }
}
