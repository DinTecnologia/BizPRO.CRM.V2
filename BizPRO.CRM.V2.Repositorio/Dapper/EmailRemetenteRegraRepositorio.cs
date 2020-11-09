using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Contexto.Interfaces;
using System.Collections.Generic;
using Dapper;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class EmailRemetenteRegraRepositorio : Repositorio<EmailRemetenteRegra>, IEmailRemetenteRegraRepositorio
    {
        public EmailRemetenteRegraRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<EmailRemetenteRegra> ObterRemetentesRegras(int? filaId)
        {
            var parametros = new DynamicParameters();
            if (filaId.HasValue)
                parametros.Add("@FilaId", filaId);

            return ObterPorProcedimento("usp_front_sel_RemetentesRegras", parametros);
        }
    }
}
