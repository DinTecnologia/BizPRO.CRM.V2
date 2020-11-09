using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{

    public class EnderecoRepositorio : Repositorio<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Endereco> ObterEnderecosProduto(long? ocorrenciaId, long? pessoaFisicaId,
            long? pessoaJuridicaId)
        {
            var where = new DynamicParameters();
            where.Add("@ocorrenciaID", ocorrenciaId);
            where.Add("@pessoaFisicaID", pessoaFisicaId);
            where.Add("@pessoaJuridicaID", pessoaJuridicaId);
            return ObterPorProcedimento("usp_front_sel_EnderecoPesquisaLocal", where);
        }
    }
}
