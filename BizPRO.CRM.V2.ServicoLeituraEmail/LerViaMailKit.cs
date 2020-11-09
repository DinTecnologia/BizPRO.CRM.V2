using System;
using System.Collections.Generic;
using SimpleInjector;
using System.Configuration;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using MailKit.Net.Pop3;

namespace BizPRO.CRM.V2.ServicoLeituraEmail
{

    public class LerViaMailKit
    {
        private string _hostname = "webzimbra.bizpro.com.br";
        int _port = 110;
        private bool _useSsl = false;
        private string _username = "";
        string _password = "";

        public LerViaMailKit(string hostName, int porta, bool useSsl, string login, string senha)
        {
            //_hostname = hostName;
            //_port = porta;
            //_useSsl = useSsl;
            _username = login;
            _password = senha;
        }


        public List<EmailMessage> LerEmail(ConfiguracaoContasEmails configuracaoContaEmail, Container container,
            IEmailServico emailServico, IConfiguracaoServico configuracaoServico, IAtividadeServico atividadeServico,
            IFilaServico filaServico, List<EmailRemetenteRegra> emailsSpamFila, List<Email> uIdsExistentes,
            string diretorioArquivos)
        {
            var dirLog = ConfigurationManager.AppSettings["DiretorioLog"];

            using (var emailClient = new Pop3Client())
            {
                emailClient.Connect(_hostname, _port, _useSsl);
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                emailClient.Authenticate(_username, _password);
                var emails = new List<EmailMessage>();
                var messageCount = emailClient.GetMessageCount();
                var contador = 0;

                for (int i = messageCount; i > 0; i--)
                {
                    if (contador > 150)
                        break;

                    contador++;
                    var message = emailClient.GetMessage(i - 1);

                    if (message.Date.DateTime < DateTime.Now.AddDays(-10))
                        continue;

                    if (message.Date.DateTime > DateTime.Now.AddHours(-3))
                        continue;

                    //var emailExistente =
                    //            uIdsExistentes.Find(
                    //                p =>
                    //                    p.MessageId == message.MessageId.Replace("<", "").Replace(">", ""));
                    //                    // &&  p.CriadoEm == message.Date.DateTime);

                    //if (emailExistente != null) continue;


                    if (message.MessageId.Replace("<", "").Replace(">", "") ==
                        "01ad01d6ad21$4e675850$eb3608f0$@assecor.com.br")
                    {
                        var emailRetornado = uIdsExistentes.FirstOrDefault(x =>
                            x.MessageId.Replace("<", "").Replace(">", "") ==
                            message.MessageId.Replace("<", "").Replace(">", ""));

                        try
                        {
                            var processar = new ProcessamentoEmail2(configuracaoContaEmail, message, null,
                                emailServico, diretorioArquivos, atividadeServico, emailServico, emailsSpamFila);
                            var retorno = processar.ProcessarEmail();
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }








                    //var emailMessage = new EmailMessage
                    //{
                    //    Content = !string.IsNullOrEmpty(message.HtmlBody) ? message.HtmlBody : message.TextBody,
                    //    Subject = message.Subject
                    //};
                    //emailMessage.ToAddresses.AddRange(message.To.Select(x => (MailboxAddress)x)
                    //    .Select(x => new EmailAddress { Address = x.Address, Name = x.Name }));
                    //emailMessage.FromAddresses.AddRange(message.From.Select(x => (MailboxAddress)x)
                    //    .Select(x => new EmailAddress { Address = x.Address, Name = x.Name }));
                    //emails.Add(emailMessage);
                }

                return emails;
            }
        }
    }


    public class EmailMessage
    {
        public EmailMessage()
        {
            ToAddresses = new List<EmailAddress>();
            FromAddresses = new List<EmailAddress>();
        }

        public List<EmailAddress> ToAddresses { get; set; }
        public List<EmailAddress> FromAddresses { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }

    public class EmailAddress
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

}
