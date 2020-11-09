using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using DomainValidation.Validation;
using HtmlAgilityPack;


namespace BizPRO.CRM.V2.Core.Email
{
    public class EnvioEmail : IEnvioEmail
    {
        public ValidationResult Enviar(string emailRemetente, string aliasEmail, string usuarioEmail, string senhaEmail,
            bool necessarioSsl, int porta, string host, string assunto, string mensagem, List<string> destinatarios,
            List<string> destinatariosCopia, List<string> destinatariosCopiaOculta, List<Anexo> anexos,
            string diretorioAnexo)
        {
            var retorno = new ValidationResult();



            if (destinatarios == null)
            {
                retorno.Add(new ValidationError("Nenhum destinatário informado!"));
                return retorno;
            }

            using (var client = new SmtpClient())
            {
                try
                {

                    client.Port = porta;
                    client.Host = host;
                    client.EnableSsl = necessarioSsl;
                    client.Timeout = 100000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(usuarioEmail, senhaEmail);

                    var mm = new MailMessage
                    {
                        From = new MailAddress(emailRemetente, aliasEmail),
                        Subject = assunto,
                        IsBodyHtml = true,
                        Body = CorrigirHtmlImagens(mensagem, anexos)
                    };

                    var htmlView = AlternateView.CreateAlternateViewFromString(mm.Body, Encoding.GetEncoding("utf-8"),
                        "text/html");

                    foreach (var destinatario in destinatarios)
                    {
                        mm.To.Add(destinatario);
                    }

                    if (destinatariosCopia != null)
                        foreach (var destinatarioCopia in destinatariosCopia)
                        {
                            mm.CC.Add(destinatarioCopia);
                        }

                    if (destinatariosCopiaOculta != null)
                        foreach (var destinatarioCopiaOculta in destinatariosCopiaOculta)
                        {
                            mm.Bcc.Add(destinatarioCopiaOculta);
                        }

                    #region Anexos

                    if (anexos != null)
                        foreach (var anexo in anexos)
                        {
                            if (string.IsNullOrEmpty(anexo.ContentId))
                            {
                                try
                                {
                                    var attachment =
                                        new Attachment(string.Format("\\{0}\\{1}", diretorioAnexo, anexo.Path)
                                            .Replace("\\\\", "\\")) {Name = anexo.Nome};
                                    mm.Attachments.Add(attachment);
                                }
                                catch
                                {
                                    var attachment =
                                        new Attachment(string.Format("{0}\\{1}", "\\\\" + diretorioAnexo,
                                            anexo.Path.Replace("||*", "\\")).Replace("\\\\", "\\"))
                                        {
                                            Name = anexo.Nome
                                        };
                                    mm.Attachments.Add(attachment);

                                }
                            }
                            else
                            {
                                try
                                {
                                    var theEmailImage = new LinkedResource(string.Format("{0}\\{1}",
                                        diretorioAnexo, anexo.Path).Replace("\\\\", "\\"));

                                    if (anexo.ContentId.Contains(anexo.Nome))
                                        theEmailImage.ContentId = anexo.ContentId.Replace("<", "").Replace(">", "");
                                    else
                                        theEmailImage.ContentId = anexo.Nome +
                                                                  anexo.ContentId.Replace("<", "").Replace(">", "");

                                    htmlView.LinkedResources.Add(theEmailImage);
                                    mm.AlternateViews.Add(htmlView);
                                }
                                catch
                                {
                                    var theEmailImage =
                                        new LinkedResource(
                                            string.Format("{0}\\{1}", "\\\\" + diretorioAnexo, anexo.Path)
                                                .Replace("\\\\", "\\"));

                                    if (anexo.ContentId.Contains(anexo.Nome))
                                        theEmailImage.ContentId = anexo.ContentId.Replace("<", "").Replace(">", "");
                                    else
                                        theEmailImage.ContentId = anexo.Nome +
                                                                  anexo.ContentId.Replace("<", "").Replace(">", "");

                                    htmlView.LinkedResources.Add(theEmailImage);
                                    mm.AlternateViews.Add(htmlView);
                                }
                            }
                        }

                    #endregion

                    client.Send(mm);
                }
                catch (Exception ex)
                {
                    retorno.Add(new ValidationError(ex.Message));
                }

                return retorno;
            }
        }

        protected string CorrigirHtmlImagens(string html, List<Anexo> anexos)
        {
            if (anexos == null) return html;

            if (anexos.Any())
            {
                var doc1 = new HtmlDocument();
                doc1.LoadHtml(html);

                try
                {
                    foreach (var item in doc1.DocumentNode.SelectNodes("//img"))
                    {
                        HtmlAttribute att = item.Attributes["src"];

                        if (att != null)
                        {
                            if (att.Value.Trim().Contains("Imagem/CorpoEmail"))
                            {
                                long idEmailAnexo;
                                long.TryParse(
                                    att.Value.Substring((att.Value.IndexOf("/CorpoEmail/") + 12),
                                        ((att.Value.Length - att.Value.IndexOf("/CorpoEmail/")) - 12)),
                                    out idEmailAnexo);

                                if (idEmailAnexo > 0)
                                {
                                    var anexo = anexos.Where(c => c.Id == idEmailAnexo).ToList();
                                    if (anexo.Count > 0)
                                    {
                                        if (anexo[0].ContentId.Contains(anexo[0].Nome))
                                            item.SetAttributeValue("src",
                                                "cid:" + anexo[0].ContentId.Replace("<", "").Replace(">", ""));
                                        else
                                            item.SetAttributeValue("src",
                                                "cid:" + anexo[0].Nome +
                                                anexo[0].ContentId.Replace("<", "").Replace(">", ""));

                                        var sw = new StringWriter();
                                        doc1.Save(sw);
                                        var htmlView =
                                            AlternateView.CreateAlternateViewFromString(sw.ToString(),
                                                Encoding.GetEncoding("utf-8"), "text/html");
                                        html = sw.ToString();
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }

            return html;
        }
    }

    public class Anexo
    {
        public long Id { get; set; }
        public long EmailId { get; set; }
        public string Nome { get; set; }
        public string Extensao { get; set; }
        public long Tamanho { get; set; }
        public string Path { get; set; }
        public DateTime? CriadoEm { get; set; }
        public bool Ativo { get; set; }
        public bool ImagemCorpo { get; set; }
        public string ContentId { get; set; }
    }
}