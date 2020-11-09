using DomainValidation.Validation;
using System.Collections.Generic;


namespace BizPRO.CRM.V2.Core.Email
{
    public interface IEnvioEmail
    {
        ValidationResult Enviar(string emailRemetente, string aliasEmail, string usuarioEmail, string senhaEmail,
            bool necessarioSsl, int porta, string host, string assunto, string mensagem, List<string> destinatarios,
            List<string> destinatariosCopia, List<string> destinatariosCopiaOculta, List<Anexo> anexos,
            string diretorioAnexo);
    }
}