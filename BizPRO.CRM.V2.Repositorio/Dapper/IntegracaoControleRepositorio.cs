using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using DapperExtensions;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class IntegracaoControleRepositorio : Repositorio<IntegracaoControle>, IIntegracaoControleRepositorio
    {
        public IntegracaoControleRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<IntegracaoControle> ObterPorIdentificadorIntegracao(long id)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@IdentificadorIntegracao", id);
            return ObterPorProcedimento("usp_front_sel_IdentificadoresIntegracao", parametros);
        }

        public IEnumerable<IntegracaoControle> ObterClientesJaIntegrados(long? identificadorIntegracao)
        {
            var parametros = new DynamicParameters();

            if (identificadorIntegracao.HasValue)
                parametros.Add("@IdentificadorIntegracao", identificadorIntegracao);

            return ObterPorProcedimento("usp_front_sel_ClientesIntegracao", parametros);
        }

        public IEnumerable<IntegracaoControle> ObterContratosJaIntegrados(long? contratoId)
        {
            var parametros = new DynamicParameters();

            if (contratoId.HasValue)
                parametros.Add("@ContratoId", contratoId);

            return ObterPorProcedimento("usp_front_sel_ContratosIntegracao", parametros);
        }


        public IntegracaoControle ObterDataUltimaAtualizacaoContrato(long pessoaFisicaId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@PessoaFisicaId", pessoaFisicaId);
            return ObterPorProcedimento("usp_front_sel_DataUltimaAtualizacaoContrato", parametros).FirstOrDefault();
        }

        public IntegracaoControle ObterPor(long? pessoaFisiciaId, long? pessoaJuridicaId, long? contratoId,
            long? telefoneId, long? identificadorIntegracao)
        {
            var pg = new PredicateGroup {Operator = GroupOperator.And, Predicates = new List<IPredicate>()};

            if (pessoaFisiciaId.HasValue)
                pg.Predicates.Add(Predicates.Field<IntegracaoControle>(f => f.PessoaFisicaId, Operator.Eq,
                    pessoaFisiciaId));

            if (pessoaJuridicaId.HasValue)
                pg.Predicates.Add(Predicates.Field<IntegracaoControle>(f => f.PessoaJuridicaId, Operator.Eq,
                    pessoaJuridicaId));

            if (contratoId.HasValue)
                pg.Predicates.Add(Predicates.Field<IntegracaoControle>(f => f.ContratoId, Operator.Eq, contratoId));

            if (telefoneId.HasValue)
                pg.Predicates.Add(Predicates.Field<IntegracaoControle>(f => f.TelefoneId, Operator.Eq, telefoneId));

            if (identificadorIntegracao.HasValue)
                pg.Predicates.Add(Predicates.Field<IntegracaoControle>(f => f.IdentificadorIntegracao, Operator.Eq,
                    identificadorIntegracao));

            return ObterPor(pg).OrderByDescending(x => x.Id).FirstOrDefault();
        }
    }
}
