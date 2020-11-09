using System.Collections.Generic;
using System.Data;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class ChatMensagensRepositorio:Repositorio<ChatMensagem>,IChatMensagemRepositorio
    {
        public ChatMensagensRepositorio(IDapperContexto context) : base(context)
        {
        }

        public IEnumerable<ChatMensagem> ObterMensagensPorConector(string conectorCli)
        {
            var parametros = new DynamicParameters();            
            parametros.Add("@conectorCli", conectorCli);
            return ObterPorProcedimento("usp_front_sel_chatmensagem", parametros);
        }

        public ICollection<ChatMensagem> ObterMensagensChat(long chatId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ChatId", chatId);

            var retorno = Conn.Query<ChatMensagem, AtividadeParteEnvolvida, ChatMensagem>("sp_front_sel_ChatMensagens",
                (ret, parteEnvolvida) =>
                {
                    ret.AtividadeParteEnvolvida = parteEnvolvida;
                    return ret;
                },
                parametros,
                splitOn: "Id,id",
                commandType: CommandType.StoredProcedure);

            return retorno.ToList();
        }

        public ChatMensagem UltimaMensagemChat(long chatId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ChatId", chatId);

            var retorno = Conn.Query<ChatMensagem, AtividadeParteEnvolvida, ChatMensagem>("usp_chat_sel_UltimaMensagemChat",
                (ret, parteEnvolvida) =>
                {
                    ret.AtividadeParteEnvolvida = parteEnvolvida;
                    return ret;
                },
                parametros,
                splitOn: "Id,id",
                commandType: CommandType.StoredProcedure);

            return retorno.FirstOrDefault();
        }
    }
}
