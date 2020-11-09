using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class AspNetClaimRepositorio : Repositorio<AspNetClaim>, IAspNetClaimRepositorio
    {
        public AspNetClaimRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<AspNetClaim> ObterTodosProc()
        {
            return ObterPorProcedimento("usp_front_sel_Claim", null);            
        }
    }
}
