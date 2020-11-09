using System.Collections.Generic;
using DapperExtensions;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class CidadeServico : Servico<Cidade>, ICidadeServico
    {
        private readonly ICidadeRepositorio _repositorio;

        public CidadeServico(ICidadeRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Cidade> ObterTodosEstados()
        {
            return _repositorio.ObterTodos().GroupBy(x => new {uf = x.Uf}).Select(g => g.First()).OrderBy(c => c.Uf);
        }

        public IEnumerable<Cidade> ObterCidadesPorEstado(string uf)
        {
            var pg = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            pg.Predicates.Add(Predicates.Field<Cidade>(f => f.Uf, Operator.Eq, uf));
            return _repositorio.ObterPor(pg).OrderBy(c => c.Nome);
        }

        public IEnumerable<Cidade> ObterCidadesSemAcento(string cidade)
        {
            return _repositorio.ObterCidadesSemAcento(cidade);
        }
    }
}
