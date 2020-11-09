using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Dapper;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class ChatUraRepositorio : Repositorio<ChatUra>, IChatUraRepositorio
    {
        public ChatUraRepositorio(IDapperContexto context)
            : base(context)
        {

        }
      
        public IEnumerable<ChatUra> ObterUnificado(long? atividadeId, long? chatUraId, int? ordem)
        {
            var where = new DynamicParameters();

            if (atividadeId != null)
                where.Add("@atividadeId", atividadeId);

            if (chatUraId != null)
                where.Add("@chatUraId", chatUraId);

            if (ordem != null)
                where.Add("@ordem", ordem);

            return ObterPorProcedimento("usp_front_sel_ChatUra_Unificado", where);
        }
    }
}
