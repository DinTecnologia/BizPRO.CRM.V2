using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Collections.Generic;
using Dapper;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class EntidadeCampoValorRepositorio : Repositorio<EntidadeCampoValor>, IEntidadeCampoValorRepositorio
    {
        public EntidadeCampoValorRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<EntidadeCampoValor> ObterPor(string nomeLogicoEntidade, string nomeCampo, bool? ativo,
            bool? valorPadrao)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@nomeLogicoEntidade", nomeLogicoEntidade);
            if (!string.IsNullOrEmpty(nomeCampo))
                parametros.Add("@nomeCampo", nomeCampo);
            parametros.Add("@ativo", ativo);
            parametros.Add("@valorPadrao", valorPadrao);

            return ObterPorProcedimento("usp_front_sel_entidadecampovalor", parametros);
        }
    }
}
