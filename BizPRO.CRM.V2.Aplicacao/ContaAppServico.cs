using BizPRO.CRM.V2.Aplicacao.Interfaces;
using System.Collections.Generic;
using System.Text;
using BizPRO.CRM.V2.Core.Email;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class ContaAppServico : IContaAppServico
    {
        private readonly IConfiguracaoContasEmailsServico _configuracaoContasEmailsServico;

        public ContaAppServico(IConfiguracaoContasEmailsServico configuracaoContasEmailsServico)
        {
            _configuracaoContasEmailsServico = configuracaoContasEmailsServico;
        }

        public ValidationResult EnviarEmail(string url, string emailUsuario)
        {
            var contaPadrao = _configuracaoContasEmailsServico.ObterContaPadrao();
            ValidationResult retorno;

            if (contaPadrao == null)
            {
                retorno = new ValidationResult();
                retorno.Add(new ValidationError("Conta Padrão não cadastrada na Ferramenta"));
                return retorno;
            }

            var destinatario = new List<string> {emailUsuario};

            var emailServico = new EnvioEmail();
            var html = new StringBuilder();
            html.Append("<p><strong>Ol&aacute;,</strong></p>");
            html.Append(
                "<p>Obrigado por entrar em contato sobre a atualiza&ccedil;&atilde;o da sua senha.Para prosseguir basta <span style='color: #ff0000;'><a href='" +
                url + "' style='color: #ff0000;'>clicar aqui</a>.</span></p>");
            html.Append("<p>Caso n&atilde;o tenha solicitado a troca de senha por favor ignore este email.</p>");
            html.Append("<p>Att.</p>");

            retorno = emailServico.Enviar(contaPadrao.Email, contaPadrao.Descricao, contaPadrao.UsuarioEmail,
                contaPadrao.SenhaEmail, contaPadrao.NecessarioSsl, contaPadrao.PortaServidorSaida,
                contaPadrao.ServidorSmtp, "Atualização de Senha", html.ToString(), destinatario, null,
                null, null, null);

            return retorno;
        }
    }
}