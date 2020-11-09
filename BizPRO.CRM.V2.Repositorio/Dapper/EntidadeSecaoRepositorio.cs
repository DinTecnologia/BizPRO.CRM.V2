using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Linq;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class EntidadeSecaoRepositorio : Repositorio<EntidadeSecao>, IEntidadeSecaoRepositorio
    {
        public EntidadeSecaoRepositorio(IDapperContexto context)
            : base(context)
        {
        }

        public EntidadeSecao ObterPor(string siglaEntidade, string nomeAba, string nomeSecao)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@siglaEntidade", siglaEntidade);
            parametros.Add("@nomeAba", nomeAba);

            if (!string.IsNullOrEmpty(nomeSecao))
                parametros.Add("@nomeSecao", nomeSecao);

            return ObterPorProcedimento("usp_front_sel_EntidadesSecoes", parametros).FirstOrDefault();
        }
    }
}
