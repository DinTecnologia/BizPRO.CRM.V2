using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using BizPRO.CRM.V2.Core.Comum;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.IoC;
using SimpleInjector;

namespace BizPRO.CRM.V2.ServicoLeituraEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            var dirLog = ConfigurationManager.AppSettings["DiretorioLog"];
            Log.ErrorLog("ServicoLeituraEmail", dirLog, "**************** Serviço iniciado ****************");
            LerEmails();
            Log.ErrorLog("ServicoLeituraEmail", dirLog, "**************** Serviço finalizado ****************");
        }

        public static void LerEmails()
        {
            var container = BootStrapper.ContainerServicoLeituraEmail();
            var servicoEmailConta = container.GetInstance<IConfiguracaoContasEmailsServico>();
            var configuracaoEmailContas = servicoEmailConta.ObterTodos();
            var dirLog = ConfigurationManager.AppSettings["DiretorioLog"];

            var emailServico = container.GetInstance<IEmailServico>();
            var configuracaoServico = container.GetInstance<IConfiguracaoServico>();
            var atividadeServico = container.GetInstance<IAtividadeServico>();
            var filaServico = container.GetInstance<IFilaServico>();

            if (configuracaoEmailContas != null)
            {
                Log.ErrorLog("ServicoLeituraEmail", dirLog,
                    "Foram carregadas " + configuracaoEmailContas.Count() + " contas");
                foreach (var configuracaoEmailConta in configuracaoEmailContas.Where(c => c.FilasId != null).ToList())
                {

                    //if (configuracaoEmailConta.Id != 8)
                    //    continue;

                    Log.ErrorLog("ServicoLeituraEmail", dirLog,
                        "Inicio Processamento ConfiguracaoContaEmailId: " + configuracaoEmailConta.Id);

                    var emailsSpamFila = new List<EmailRemetenteRegra>();

                    Run(configuracaoEmailConta, container, emailServico, configuracaoServico, atividadeServico,
                        filaServico, emailsSpamFila);
                    Log.ErrorLog("ServicoLeituraEmail", dirLog,
                        "Fim Processamento ConfiguracaoContaEmailId: " + configuracaoEmailConta.Id);
                }
            }
            else
            {
                Log.ErrorLog("ServicoLeituraEmail", dirLog, "Nenhuma configuracoesEmailConta retornada.");
            }
        }

        private static void Run(ConfiguracaoContasEmails configuracaoContaEmail, Container container,
            IEmailServico emailServico, IConfiguracaoServico configuracaoServico, IAtividadeServico atividadeServico,
            IFilaServico filaServico, List<EmailRemetenteRegra> emailsSpamFila)
        {
            var dirLog = ConfigurationManager.AppSettings["DiretorioLog"];
            try
            {

                var uIdsExistentes = (List<Email>)emailServico.ObterUids(configuracaoContaEmail.Id);
                var configuracao = new Configuracao();
                configuracao.SetarUrlEmailAnexos();
                var pathPadrao = configuracaoServico.ObterPorSigla(configuracao.Sigla);

                //using (
                //    var ic = new ImapClient(configuracaoContaEmail.ServidorPop, configuracaoContaEmail.UsuarioEmail,
                //        configuracaoContaEmail.SenhaEmail, AuthMethods.Login,
                //        configuracaoContaEmail.PortaServidorEntrada, true, true))
                //{
                //    ic.SelectMailbox("inbox");
                //    var iDiasAMenos = -3;

                //    var messages =
                //        ic.SearchMessages(
                //            new SearchCondition()
                //            {
                //                Field = SearchCondition.Fields.SentSince,
                //                Value =
                //                    DateTime.Now.AddDays(iDiasAMenos)
                //                        .ToString("dd-MMM-yyyy", new System.Globalization.CultureInfo("en-US"))
                //            }, true,
                //            false);

                //    if (!messages.Any()) return;

                //    var uIdsExistentes = (List<Email>)emailServico.ObterUids(configuracaoContaEmail.Id);
                //    var configuracao = new Configuracao();
                //    configuracao.SetarUrlEmailAnexos();
                //    var pathPadrao = configuracaoServico.ObterPorSigla(configuracao.Sigla);

                //    if (configuracaoContaEmail.FilasId != null)
                //    {
                //        var fila = filaServico.ObterPorId((int)configuracaoContaEmail.FilasId);
                //        configuracaoContaEmail.Fila = fila;
                //    }

                //    //foreach (var message in messages)
                //    //{
                //    //    try
                //    //    {
                //    //        var emailExistente =
                //    //            uIdsExistentes.Find(
                //    //                p =>
                //    //                    p.MessageId == message.Value.MessageID.Replace("<", "").Replace(">", "") &&
                //    //                    p.CriadoEm == message.Value.Date);
                //    //        if (emailExistente != null) continue;

                //    //        var messageCompleta = new MailMessage();

                //    //        try
                //    //        {
                //    //            messageCompleta = ic.GetMessage(message.Value.Uid);
                //    //        }
                //    //        catch (Exception ex)
                //    //        {
                //    //            continue;
                //    //        }

                //    //        var processar = new ProcessamentoEmail(configuracaoContaEmail, messageCompleta, null,
                //    //            emailServico, pathPadrao.Valor, atividadeServico, emailServico, emailsSpamFila);
                //    //        var retorno = processar.ProcessarEmail();

                //    //        if (retorno.IsValid)
                //    //        {
                //    //            Log.ErrorLog("ServicoLeituraEmail", dirLog,
                //    //                "E-mail (" + messageCompleta.Subject + ") processado com sucesso");
                //    //        }
                //    //        else
                //    //        {
                //    //            Log.ErrorLog("ServicoLeituraEmail", dirLog,
                //    //                "E-mail (" + messageCompleta.Subject + ") não processado, erro: " +
                //    //                retorno.Erros.ToString());
                //    //        }
                //    //    }
                //    //    catch (Exception ex)
                //    //    {
                //    //        Log.ErrorLog("ServicoLeituraEmail", dirLog,
                //    //            "E-mail (" + message.Value + ") não processado, erro: " + ex.Message);
                //    //    }
                //    //}

                //}

                new LerViaMailKit(configuracaoContaEmail.ServidorPop, configuracaoContaEmail.PortaServidorEntrada, false, configuracaoContaEmail.UsuarioEmail,
                        configuracaoContaEmail.SenhaEmail).LerEmail(configuracaoContaEmail, container, emailServico, configuracaoServico, atividadeServico, filaServico, emailsSpamFila, uIdsExistentes, pathPadrao.Valor);
            }
            catch (Exception ex)
            {
                Log.ErrorLog("ServicoLeituraEmail", dirLog, "Erro : " + ex.Message);
            }
        }
    }
}
