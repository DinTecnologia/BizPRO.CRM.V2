using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IEmailModeloServico : IServico<EmailModelo>
    {
        IEnumerable<EmailModelo> ObterPor(EmailModelo entidade);
        EmailModelo ObterUltimoModeloPor(EmailModelo entidade);
        EmailModelo ObterModeloNovaOcorrenciaLinkExterno();
    }
}
