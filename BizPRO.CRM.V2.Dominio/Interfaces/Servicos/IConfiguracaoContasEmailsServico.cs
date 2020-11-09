using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades ;
namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IConfiguracaoContasEmailsServico
    {       
        IEnumerable<ConfiguracaoContasEmails> ObterTodos();
        ConfiguracaoContasEmails ObterPorId(int id);
        ConfiguracaoContasEmails ObterContaEmailPorAtividadeId(long atividadeId);
        ConfiguracaoContasEmails ObterPorFilaId(int filaId);        
        ConfiguracaoContasEmails ObterContaPadrao();
        /// <summary>
        /// Retorna todas a lista de contas que o usúario tem permissão, conforme o vínculo de filas
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        IEnumerable<ConfiguracaoContasEmails> ObterPorUsuarioId(string usuarioId);
        IEnumerable<ConfiguracaoContasEmails> ObterRegistroEmailEntrada(string usuarioId);
    }
}
