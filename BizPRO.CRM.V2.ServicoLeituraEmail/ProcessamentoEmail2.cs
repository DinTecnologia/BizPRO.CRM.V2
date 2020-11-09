using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.IoC;
using MimeKit;
using System.Web;
using DomainValidation.Validation;


namespace BizPRO.CRM.V2.ServicoLeituraEmail
{
    public class ProcessamentoEmail2
    {
        readonly MimeKit.MimeMessage _mensagem;
        readonly Guid _identificadorAnexo;
        readonly ConfiguracaoContasEmails _configuracaoContaEmail;
        readonly IEmailServico _emailServico;
        readonly List<EmailAnexo> _anexos;
        readonly string _diretorioArquivos;
        readonly List<AtividadeParteEnvolvida> _envolvidos;
        readonly IEmailServico _servicoEmail;
        string _html;
        string _texto;
        string _nomeAnexoPadrao;
        Guid _identificadorAnexoItem;
        List<EmailRemetenteRegra> _emailsSpamFila;


        public ProcessamentoEmail2(ConfiguracaoContasEmails configuracaoContaEmail, MimeMessage mailMessage,
            string userId, IEmailServico emailServico, string diretorioArquivos, IAtividadeServico servicoAtividade,
            IEmailServico servicoEmail, List<EmailRemetenteRegra> emailsSpamFila)
        {
            _configuracaoContaEmail = configuracaoContaEmail;
            _mensagem = mailMessage;
            _identificadorAnexo = Guid.NewGuid();
            BootStrapper.ContainerServicoLeituraEmail();
            _emailServico = emailServico;
            _anexos = new List<EmailAnexo>();
            _diretorioArquivos = diretorioArquivos;
            _diretorioArquivos = @"C:\Users\ptd000068\Desktop\AnexosFTP";
            _servicoEmail = servicoEmail;
            _envolvidos = new List<AtividadeParteEnvolvida>();
            _emailsSpamFila = emailsSpamFila;
        }

        public ValidationResult ProcessarEmail()
        {
            var retorno = new ValidationResult();

            try
            {
                if (_mensagem == null)
                {
                    retorno.Add(new ValidationError("Mensagem Nula"));
                    return retorno;
                }

                if (_mensagem.From == null)
                {
                    retorno.Add(new ValidationError("Email o remetente nulo"));
                    return retorno;
                }

                if (_mensagem.Date < Convert.ToDateTime("01/01/2017"))
                {
                    retorno.Add(new ValidationError("Email inferior a 01/01/2017 "));
                    return retorno;
                }

                ProcessarAnexos();
                ProcessarHtml();
                RetirarEmailClienteHtmlFormulario();
                ProcessarContatos();

                var emailPai = ObterEmailReferenciaCorpoEmail();
                var nomeCliente = RetirarNomeClienteHtmlFormulario();
                long? atividadeId;

                if (emailPai == null)
                    emailPai = new Email();

                var email = _emailServico.AdicionarEmailEntradaServico(_configuracaoContaEmail, emailPai,
                    _envolvidos,
                    _anexos, _mensagem.From.Select(x => (MailboxAddress) x).FirstOrDefault().Address,
                    _mensagem.Subject, _html, _texto, _mensagem.MessageId,
                    _mensagem.MessageId, _mensagem.Date.DateTime, nomeCliente, _identificadorAnexo.ToString());

                try
                {
                    if (email.ValidationResult.IsValid && _configuracaoContaEmail.FilasId.HasValue)
                    {
                        var emailRemetenteSpam =
                            _emailsSpamFila.Find(p =>
                                p.Remetente == _mensagem.From.Select(x => (MailboxAddress) x).FirstOrDefault()
                                    .Address);

                        if (emailRemetenteSpam != null)
                            _emailServico.ClassificarEmailAutomatico(email.AtividadeId,
                                emailRemetenteSpam.StatusAtividadeId, _configuracaoContaEmail.FilasId.Value);
                    }
                }
                catch
                {
                }

                return email.ValidationResult;
            }
            catch (Exception ex)
            {
                retorno.Add(new ValidationError(ex.Message));
                return retorno;
            }
        }

        protected void ProcessarHtml()
        {
            var html = "";
            try
            {
                html = _mensagem.HtmlBody;
                _texto = _mensagem.TextBody;
            }
            catch (Exception ex)
            {
                try
                {
                    html = Regex.Replace(_mensagem.HtmlBody, @"\r\n?|\n", "<br>");
                    _texto = Regex.Replace(_mensagem.TextBody, @"\r\n?|\n", "<br>");
                }
                catch (Exception ex2)
                {
                    html = _mensagem.HtmlBody;
                    _texto = _mensagem.TextBody;
                }
            }

            if (!string.IsNullOrEmpty(html))
                _html = html;
        }

        protected void ProcessarContatos()
        {
            if (!_envolvidos.Where(m => m.TipoParteEnvolvida == TipoParteEnvolvida.Remetente.Value).ToList().Any())
                _envolvidos.AddRange(_mensagem.From.Select(x => (MailboxAddress) x)
                    .Select(x =>
                        new AtividadeParteEnvolvida(x.Address, x.Name, TipoParteEnvolvida.Remetente.Value)));

            if (_mensagem.To.Count > 0)
            {
                _envolvidos.AddRange(_mensagem.To.Select(x => (MailboxAddress) x)
                    .Select(x =>
                        new AtividadeParteEnvolvida(x.Address, x.Name, TipoParteEnvolvida.Destinatario.Value)));
            }

            if (_mensagem.Cc.Count > 0)
            {
                _envolvidos.AddRange(_mensagem.Cc.Select(x => (MailboxAddress) x)
                    .Select(x =>
                        new AtividadeParteEnvolvida(x.Address, x.Name,
                            TipoParteEnvolvida.DestinatarioCopia.Value)));
            }

            if (_mensagem.Bcc.Count > 0)
            {
                _envolvidos.AddRange(_mensagem.Bcc.Select(x => (MailboxAddress) x)
                    .Select(x =>
                        new AtividadeParteEnvolvida(x.Address, x.Name,
                            TipoParteEnvolvida.DestinatarioOculto.Value)));
            }
        }

        protected void ProcessarAnexos()
        {
            var contadorAnexo = 0;
            foreach (var anexo in _mensagem.Attachments)
            {
                contadorAnexo++;
                if (string.Compare(anexo.ContentType.Charset, "message/rfc822", StringComparison.Ordinal) != 0)
                {
                    var fileName = anexo.ContentDisposition?.FileName ?? anexo.ContentType.Name;

                    var extensao = ObtemExtensao(fileName.Replace("\"", "").Replace("\t", ""));
                    _nomeAnexoPadrao = "Anexo-";

                    if (!string.IsNullOrEmpty(fileName))
                        _nomeAnexoPadrao =
                            fileName.Replace("\"", "").Replace("\t", "").Replace(" ", "_").Replace("\\\\", "\\")
                                .Replace(":", "").Replace("*", "").Replace("|", "").Replace("?", "")
                                .Replace("<", "").Replace(">", "").Replace("/", "").Replace("&", "");
                    else
                    {
                        var header =
                            HttpUtility.UrlDecode(anexo.Headers["Content-Disposition"].ToString())
                                .Replace(@"attachment; filename*=UTF-8''", "").Replace("attachment", "");

                        if (!string.IsNullOrEmpty(header))
                        {
                            var contador = 1;
                            foreach (var item in header.Split(','))
                            {
                                if (contador == 1)
                                    _nomeAnexoPadrao = item.Replace("\"", "").Replace("\t", "").Replace(" ", "_")
                                        .Replace("\\\\", "\\").Replace(":", "").Replace("*", "").Replace("|", "")
                                        .Replace("?", "").Replace("<", "").Replace(">", "").Replace("/", "")
                                        .Replace("&", "");

                                contador++;
                            }
                        }
                    }

                    if (_nomeAnexoPadrao == "Anexo-")
                    {
                        _nomeAnexoPadrao = _nomeAnexoPadrao + contadorAnexo + ".jpg";
                    }


                    var diretorio = DownloadAnexo(anexo);
                    var imagemCorpo = false;
                    var contentId = fileName.Replace("\"", "")
                        .Replace("\t", "")
                        .Replace(" ", "_")
                        .Replace("\\\\", "\\");

                    try
                    {
                        var header = HttpUtility.UrlDecode(anexo.Headers["Content-Disposition"].ToString());
                        if (header.Split(';').Any(item => item.Contains("inline")))
                        {
                            imagemCorpo = true;
                        }
                    }
                    catch
                    {
                    }

                    var sType = anexo.ContentType.MediaType.ToLower();
                    if (sType.Contains("image"))
                        if (anexo.Headers["Content-ID"] != "")
                            contentId = anexo.Headers["Content-ID"];

                    var emailAnexo = new EmailAnexo(extensao, _nomeAnexoPadrao, diretorio,
                        anexo.ContentDisposition.Size ?? 0,
                        imagemCorpo, contentId, _identificadorAnexoItem.ToString());
                    _anexos.Add(emailAnexo);
                }
                else
                {
                    //try
                    //{
                    //    if (attachedMessage.Subject != null)
                    //        _nomeAnexoPadrao = attachedMessage.Subject.Replace(" ", "_") + ".eml";
                    //}
                    //catch (Exception ex)
                    //{
                    _nomeAnexoPadrao = "EmailAnexo_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day +
                                       ".eml";
                    //}

                    _anexos.Add(new EmailAnexo(".eml", _nomeAnexoPadrao, DownloadAnexo(anexo),
                        anexo.ContentDisposition.Size ?? 0, false,
                        null));
                }
            }

            TratarImagensEmAlternateViews();
        }

        public static string ObtemExtensao(string sArquivo)
        {
            if (string.IsNullOrEmpty(sArquivo))
                return "jpg";

            var fileExtension = sArquivo.Split('.');
            var newfileExtension = fileExtension[fileExtension.Length - 1];
            var fullName = newfileExtension;
            return fullName;
        }

        protected string DownloadAnexo(MimeEntity anexo)
        {
            try
            {
                var fileName = anexo.ContentDisposition?.FileName ?? anexo.ContentType.Name;

                var dirAnexo = string.Format("{0}\\{1}\\{2}\\{3}\\{4}",
                    "Entrada", DateTime.Now.Year, DateTime.Now.Month,
                    DateTime.Now.Day, _identificadorAnexo);

                var dirAnexoDownloadArquivo =
                    new DirectoryInfo(string.Format("{0}\\{1}",
                        _diretorioArquivos, dirAnexo));

                if (!dirAnexoDownloadArquivo.Exists)
                    dirAnexoDownloadArquivo.Create();

                _identificadorAnexoItem = Guid.NewGuid();

                var dirCompleto = string.Format("{0}\\{1}", dirAnexoDownloadArquivo.FullName,
                    _identificadorAnexoItem.ToString());

                var i = 0;
                while (i < 20)
                {
                    i++;
                    if (File.Exists(dirCompleto))
                    {
                        _nomeAnexoPadrao = i + "_" + _nomeAnexoPadrao;
                        dirCompleto = string.Format("{0}\\{1}", dirAnexoDownloadArquivo.FullName, _nomeAnexoPadrao);
                    }
                    else break;
                }


                if (anexo is MessagePart)
                {
                    var rfc822 = (MessagePart) anexo;
                    using (var stream = File.Create(dirCompleto))
                    {
                        rfc822.Message.WriteTo(stream);
                    }

                    dirCompleto = dirCompleto.Replace(_diretorioArquivos.Replace("\\\\", "\\"), "");
                    return dirCompleto.StartsWith("\\")
                        ? dirCompleto.Substring(1, dirCompleto.Length - 1)
                        : dirCompleto;
                }
                else
                {
                    var part = (MimePart) anexo;

                    try
                    {
                        using (var stream = File.Create(dirCompleto))
                        {
                            part.Content.DecodeTo(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        using (var stream = File.Create("\\\\" + dirCompleto))
                        {
                            part.Content.DecodeTo(stream);
                        }
                    }

                    dirCompleto = dirCompleto.Replace(_diretorioArquivos.Replace("\\\\", "\\"), "");
                    return dirCompleto.StartsWith("\\")
                        ? dirCompleto.Substring(1, dirCompleto.Length - 1)
                        : dirCompleto;
                }
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return null;
            }
        }

        protected void TratarImagensEmAlternateViews()
        {
            //foreach (var anexo in _mensagem.AlternateViews)
            //{
            //    var contentType = "";
            //    try
            //    {
            //        contentType = anexo.ContentType;
            //    }
            //    catch (Exception ex)
            //    {
            //        contentType = "";
            //    }

            //    var contentDisposition = "";
            //    try
            //    {
            //        contentDisposition = anexo.Headers["Content-Disposition"].Value;
            //    }
            //    catch (Exception ex)
            //    {
            //        contentDisposition = "";
            //    }

            //    if (!(contentType != "" & contentDisposition != "")) continue;

            //    var contentId = "";
            //    try
            //    {
            //        contentId = anexo.Headers["Content-ID"].Value;
            //    }
            //    catch (Exception ex)
            //    {
            //        contentId = "";
            //    }

            //    if (contentId == "") continue;

            //    try
            //    {
            //        contentId = contentId.Replace("<", "").Replace(">", "");
            //        if (contentId.Contains("@"))
            //        {
            //            var posicao = contentId.IndexOf('@');
            //            var nome = contentId.Substring(0, posicao);
            //            var ContentLimpo = contentId.Substring(posicao, contentId.Length - posicao);
            //        }
            //        try
            //        {
            //            _nomeAnexoPadrao = "ImgBody_" + Guid.NewGuid() + ".png";
            //            var diretorio = DownloadAnexo(anexo);
            //            _anexos.Add(new EmailAnexo(".png", _nomeAnexoPadrao, DownloadAnexo(anexo), anexo.Body.Length,
            //                true, contentId));
            //        }
            //        catch
            //        {
            //        }
            //    }
            //    catch
            //    {

            //    }
            //}
        }

        public Dictionary<long, DateTime> ObterListaAtividadesCorpoEmail(string html)
        {
            var lista = new Dictionary<long, DateTime>();
            var lOperador = new List<string>();

            while (html.IndexOf("IdEmailInicio", StringComparison.OrdinalIgnoreCase) > -1)
            {
                try
                {
                    var posicaoInicial = html.IndexOf("IdEmailInicio", StringComparison.OrdinalIgnoreCase);
                    var posicaoFinal = html.IndexOf("IdEmailFim", StringComparison.OrdinalIgnoreCase);
                    var textoRetirado = html.Substring(posicaoInicial, posicaoFinal - posicaoInicial);
                    lOperador.Add(textoRetirado.Replace("IdEmailInicio", "").Replace("IdEmailFim", ""));
                    html = html.Replace(textoRetirado + "IdEmailFim", "");
                }
                catch (Exception)
                {
                    break;
                }
            }

            foreach (var operador in lOperador)
            {
                long id = 0;
                var dt = DateTime.MinValue;
                var contador = 0;

                foreach (var item in operador.Split('|'))
                {
                    switch (contador)
                    {
                        case 0:
                        {
                            Int64.TryParse(item, out id);
                            break;
                        }

                        case 1:
                        {
                            DateTime.TryParse(item.Replace("<wbr>", ""), out dt);
                            break;
                        }

                        default:
                            throw new Exception("Unexpected Case");
                    }

                    contador++;
                }

                if (id != 0 && dt != DateTime.MinValue)
                    lista.Add(id, dt);
                else if (id != 0)
                    lista.Add(id, DateTime.Now);
            }

            return lista;
        }

        protected Email ObterEmailReferenciaCorpoEmail()
        {
            var emailHtml = ObterListaAtividadesCorpoEmail(_html);

            if (emailHtml.Count <= 0)
                return new Email();

            var lEmailHtml2 = emailHtml.OrderByDescending(c => c.Value).ToList();
            return _servicoEmail.ObterEmailCompletoPor(lEmailHtml2[0].Key, null);
        }

        protected void RetirarEmailClienteHtmlFormulario()
        {
            var remetente = string.Empty;

            if (_html.ToLower().Contains("e-mail :"))
            {
                var inicio = _html.ToLower().IndexOf("e-mail :", StringComparison.OrdinalIgnoreCase);

                if (inicio > -1)
                {
                    var parteHtml = _html.Substring(inicio, (_html.Length - inicio));
                    var fim = parteHtml.IndexOf("<br/>", StringComparison.OrdinalIgnoreCase);
                    if (fim > -1)
                    {
                        remetente = parteHtml.Substring(0, fim).TrimEnd().TrimStart().ToLower()
                            .Replace("e-mail : ", "");
                    }
                }
            }
            else if (_html.ToLower().Contains("email :"))
            {
                var inicio = _html.ToLower().IndexOf("email :", StringComparison.OrdinalIgnoreCase);

                if (inicio > -1)
                {
                    var parteHtml = _html.Substring(inicio, (_html.Length - inicio));
                    var fim = parteHtml.IndexOf("<br/>", StringComparison.OrdinalIgnoreCase);
                    if (fim > -1)
                    {
                        remetente = parteHtml.Substring(0, fim).TrimEnd().TrimStart().ToLower()
                            .Replace("email : ", "");
                    }
                }
            }

            if (!string.IsNullOrEmpty(remetente))
            {
                _envolvidos.Add(new AtividadeParteEnvolvida(remetente, null, TipoParteEnvolvida.Remetente.Value));
            }
        }

        protected string RetirarNomeClienteHtmlFormulario()
        {
            var nome = string.Empty;

            if (!_html.ToLower().Contains("nome completo :")) return nome.ToUpper();

            var inicio = _html.ToLower().IndexOf("nome completo :", StringComparison.OrdinalIgnoreCase);

            if (inicio <= -1) return nome.ToUpper();

            var parteHtml = _html.Substring(inicio, (_html.Length - inicio));
            var fim = parteHtml.IndexOf("<br/>", StringComparison.OrdinalIgnoreCase);
            if (fim > -1)
            {
                nome = parteHtml.Substring(0, fim).TrimEnd().TrimStart().ToLower().Replace("nome completo : ", "");
            }

            return nome.ToUpper();
        }
    }
}