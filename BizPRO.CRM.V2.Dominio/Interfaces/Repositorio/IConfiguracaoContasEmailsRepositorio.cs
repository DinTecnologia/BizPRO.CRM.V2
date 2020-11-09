using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IConfiguracaoContasEmailsRepositorio : IRepositorio<ConfiguracaoContasEmails>
    {
        ConfiguracaoContasEmails ObterContaEmailPorAtividadeId(long atividadeId);
        ConfiguracaoContasEmails ObterPorFilaId(int filaId);
        ConfiguracaoContasEmails ObterContaPadrao();
        IEnumerable<ConfiguracaoContasEmails> ObterPorUsuarioId(string usuarioId);
        IEnumerable<ConfiguracaoContasEmails> ObterRegistroEmailEntrada(string usuarioId);
    }
}
