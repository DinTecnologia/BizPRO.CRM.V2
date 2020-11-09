using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DapperExtensions;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class MidiaServico : IMidiaServico
    {
        private readonly IMidiaRepositorio _repositorio;

        public MidiaServico(IMidiaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Midia> ObterTodos()
        {
            return _repositorio.ObterTodos().OrderBy(c => c.Nome).Where(x => x.Ativo);
        }

        public Midia ObterPorId(int midiaId)
        {
            return _repositorio.ObterPorId(midiaId);
        }

        public IEnumerable<Midia> ObterPor(string nome, int? canalId)
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};

            if (!string.IsNullOrEmpty(nome))
                where.Predicates.Add(Predicates.Field<Midia>(f => f.Nome, Operator.Like, nome));

            if (canalId.HasValue)
                where.Predicates.Add(Predicates.Field<Midia>(f => f.CanaisId, Operator.Like, canalId));

            where.Predicates.Add(Predicates.Field<Midia>(f => f.Ativo, Operator.Eq, true));

            return _repositorio.ObterPor(where).OrderBy(x => x.Nome);
        }
    }
}
