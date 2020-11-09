using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Collections.Generic;
using Dapper;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class CidadeRepositorio : Repositorio<Cidade>, ICidadeRepositorio
    {
        public CidadeRepositorio(IDapperContexto context)
            : base(context)
        {
        }

        public IEnumerable<Cidade> ObterCidadesSemAcento(string cidade)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@Cidade", cidade);
            return ObterPorProcedimento("usp_sel_ObterCidades", parametros);
        }
    }
}
