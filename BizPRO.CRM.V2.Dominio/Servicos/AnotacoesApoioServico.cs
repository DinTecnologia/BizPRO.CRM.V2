using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Dapper;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AnotacoesApoioServico : Servico<AnotacoesApoio>, IAnotacoesApoioServico
    {
        private readonly IAnotacoesApoioRepositorio _repositorio;

        public AnotacoesApoioServico(IAnotacoesApoioRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<AnotacoesApoio> ObterAnotacoesApoio(long? ocorrenciaId, long? atividadeId,
            long? pessoaFisicaId, long? pessoaJuridicaId, long? potenciaisClienteId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ocorrenciaID", ocorrenciaId);
            parametros.Add("@atividadeID", atividadeId);
            parametros.Add("@pessoaFisicaID", pessoaFisicaId);
            parametros.Add("@pessoaJuridicaID", pessoaJuridicaId);
            parametros.Add("@PotenciaisClienteID", potenciaisClienteId);
            return _repositorio.ObterPorProcedimento("usp_front_sel_Anotacoes", parametros);
        }
    }
}
