using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IEmailRepositorio : IRepositorio<Email>
    {
        IEnumerable<Email> ObterEmailsPendentesDeEnvio(long filaId);
        IEnumerable<Email> ObterUids(int configuracaContasEmailsId);
        Email ObterEmailPorAtividadeId(long atividadeId);
        Email ObterEmailCompletoPor(long? emailId, long? atividadeId);
        int PossuiNovosEmails(string userId);
        Email BuscarProximoEmail(string userId);

        void ClassificarEmailAutomatico(long atividadeId, long statusAtividadeId, int filaId);
    }
}
