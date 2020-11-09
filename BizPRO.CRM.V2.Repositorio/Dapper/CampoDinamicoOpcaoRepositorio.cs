using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Collections.Generic;
using System.Linq;
using DapperExtensions;
using Dapper;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class CampoDinamicoOpcaoRepositorio : Repositorio<CampoDinamicoOpcao>, ICampoDinamicoOpcaoRepositorio
    {
        public CampoDinamicoOpcaoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<CampoDinamicoOpcao> ObterPor(long camposDinamicosId)
        {
            var where = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };
            where.Predicates.Add(Predicates.Field<CampoDinamicoOpcao>(f => f.CamposDinamicosId, Operator.Eq,
                camposDinamicosId));
            where.Predicates.Add(Predicates.Field<CampoDinamicoOpcao>(f => f.Ativo, Operator.Eq, true));
            return ObterPor(where);
        }

        public IEnumerable<CampoDinamicoOpcao> ObterPor(string entidadeSigla, string abaSecao, string campoDinamicoTipo,
            string campoDinamicoNome)
        {
            var where = new DynamicParameters();
            where.Add("@sigla", entidadeSigla);
            where.Add("@secao", abaSecao);
            where.Add("@campoDinamicoTipo", campoDinamicoTipo);
            where.Add("@campoDinamicoNome", campoDinamicoNome);
            return ObterPorProcedimento("usp_front_sel_CamposDinamicosOpcoes", where);
        }

        public IEnumerable<CampoDinamicoOpcao> BuscarPor(int campoDinamicoId, string termo,
            int? quantidade = 100)
        {
            var where = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate>() };

            where.Predicates.Add(Predicates.Field<CampoDinamicoOpcao>(f => f.CamposDinamicosId, Operator.Eq,
                campoDinamicoId));

            if (!string.IsNullOrEmpty(termo))
                where.Predicates.Add(Predicates.Field<CampoDinamicoOpcao>(f => f.Nome, Operator.Like,
                string.Format("%{0}%", termo)));

            return quantidade.HasValue ? ObterPor(where).Take((int)quantidade) : ObterPor(where);
        }
    }
}
