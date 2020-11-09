using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class AspNetMatrizRepositorio : Repositorio<AspNetMatriz>, IAspNetMatrizRepositorio
    {
        public AspNetMatrizRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<AspNetMatriz> ObterPor(string claimId, string sentido)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@claimID", claimId);
            parametros.Add("@sentido", sentido);
            return ObterPorProcedimento("usp_front_sel_AspNetMatriz", parametros);
        }
    }
}
