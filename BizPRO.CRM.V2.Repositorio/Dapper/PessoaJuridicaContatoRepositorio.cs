using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class PessoaJuridicaContatoRepositorio : Repositorio<PessoaJuridicaContato>,
        IPessoaJuridicaContatoRepositorio
    {

        public PessoaJuridicaContatoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<PessoaJuridicaContato> ObterEntidadeCompletaPorProcedimento(string procedimento,
            DynamicParameters parametros)
        {
            var retorno =
                Conn
                    .Query
                    <PessoaJuridicaContato, PessoaFisica, PessoaJuridicaTiposContato, PessoaJuridica,
                        PessoaJuridicaContato>(procedimento,
                        (ret, fisica, tipo, juridica) =>
                        {
                            ret.PessoaFisica = fisica;
                            ret.PessoaJuridicaTiposContato = tipo;
                            ret.PessoaJuridica = juridica;
                            return ret;
                        },
                        parametros,
                        //splitOn: "Id",
                        commandType: CommandType.StoredProcedure);

            return retorno;
        }
    }
}
