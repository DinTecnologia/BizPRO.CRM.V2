using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DapperExtensions;
using System.Collections.Generic;
using System.Linq;


namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AnotacaoTipoServico : Servico<AnotacaoTipo>, IAnotacaoTipoServico
    {
        private readonly IAnotacaoTipoRepositorio _repositorio;

        public AnotacaoTipoServico(IAnotacaoTipoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<AnotacaoTipo> ObterTodosAtivos()
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<AnotacaoTipo>(f => f.Ativo, Operator.Eq, true));
            return _repositorio.ObterPor(where);
        }

        public IEnumerable<AnotacaoTipo> ObterOcorrenciaTipoId(long ocorrenciaTipoId)
        {
            var listaAnotacoes = _repositorio.ObterPorOcorrenciaTipoId(ocorrenciaTipoId);
            return listaAnotacoes.Any() ? listaAnotacoes : ObterPadrao();
        }

        public IEnumerable<AnotacaoTipo> ObterPadrao()
        {
            var where = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};
            where.Predicates.Add(Predicates.Field<AnotacaoTipo>(f => f.Ativo, Operator.Eq, true));
            where.Predicates.Add(Predicates.Field<AnotacaoTipo>(f => f.Padrao, Operator.Eq, true));
            return _repositorio.ObterPor(where);
        }
    }
}
