using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using System;
using System.Linq;
using System.Web.Mvc;
using DomainValidation.Validation;
using System.Text.RegularExpressions;
using System.IO;
using HtmlAgilityPack;
using System.Threading;
using System.Text;
using System.Net.Mail;
using BizPRO.CRM.V2.Core.ValueObjects;
using System.Drawing.Imaging;
using System.Drawing;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class AtendimentoAppServico : AppServicoDapper, IAtendimentoAppServico
    {
        private readonly IAtendimentoServico _atendimento;
        private readonly IAtividadeServico _atividadeServico;
        private readonly IMidiaServico _midiaServico;
        private readonly IStatusAtividadeServico _statusAtividadeServico;
        private readonly IEmailServico _emailServico;
        private readonly IConfiguracaoServico _configuracaoServico;
        private readonly IConfiguracaoContasEmailsServico _configuracaoContaEmailServico;
        private readonly IEmailAnexoServico _emailAnexoServico;
        private readonly List<EmailAnexo> _anexos;

        public AtendimentoAppServico(IAtendimentoServico atendimentoServico, IAtividadeServico atividadeServico,
            IMidiaServico midiaServico, IStatusAtividadeServico statusAtividadeServico, IEmailServico emailServico,
            IConfiguracaoServico configuracaoServico, IConfiguracaoContasEmailsServico configuracaoContaEmailServico,
            IEmailAnexoServico emailAnexoServico)
        {
            _atendimento = atendimentoServico;
            _atividadeServico = atividadeServico;
            _midiaServico = midiaServico;
            _statusAtividadeServico = statusAtividadeServico;
            _emailServico = emailServico;
            _configuracaoServico = configuracaoServico;
            _configuracaoContaEmailServico = configuracaoContaEmailServico;
            _anexos = new List<EmailAnexo>();
            _emailAnexoServico = emailAnexoServico;
        }

        public IEnumerable<AtendimentoViewModel> ObterAtendimentosPorCliente(long? pessoaFisicaId,
            long? pessoaJuridicaId, int? quantidade)
        {
            var retorno = new List<AtendimentoViewModel>();
            var atendimentos = _atendimento.ObterAtendimentosPorCliente(pessoaFisicaId, pessoaJuridicaId,
                quantidade);

            if (atendimentos == null) return retorno;

            retorno.AddRange(atendimentos.Select(atendimento => new AtendimentoViewModel(atendimento)));
            return retorno;
        }

        public AtendimentoViewModel SalvarAtendimento(AtendimentoViewModel model, long atividadeId)
        {
            var retorno = new Atendimento(model.criadoPorUserId, _atendimento.GerarNumeroProtocolo(DateTime.Now),
                null, null);
            var modelView = _atendimento.InserirAtendimento(retorno);
            _atividadeServico.AtualizarAtendimentoId(atividadeId, modelView.Id);
            return new AtendimentoViewModel(modelView.Id, modelView.Protocolo, modelView.CriadoEm);
        }

        public Atendimento GerarAtendimento(string criadoPor)
        {
            var atendimento = new Atendimento(criadoPor, _atendimento.GerarNumeroProtocolo(DateTime.Now), null,
                null);
            _atendimento.Adicionar(atendimento);
            return atendimento;
        }

        public void FinalizarAtendimento(AtendimentoViewModel model)
        {
            var atendimentoEntity = _atendimento.ObterPorId(model.atendimentoID);
            var atend = new AtendimentoViewModel(model.atendimentoID, atendimentoEntity.Protocolo,
                atendimentoEntity.CriadoEm);
            atendimentoEntity = _atendimento.ObterPorId(atend.id);
            if (atendimentoEntity == null) return;
            atendimentoEntity.FinalizadoEm = DateTime.Now;
            atendimentoEntity.FinalizadoPorUserId = model.finalizadoPorUserID;
            atendimentoEntity.CanalOrigemId = model.canalOrigemID;
            _atendimento.Atualizar(atendimentoEntity);
        }

        public AtendimentoViewModel ObterPorId(long id)
        {
            return new AtendimentoViewModel(_atendimento.ObterPorId(id));
        }

        public void AtualizarMidia(long atendimentoId, int midiaId)
        {
            _atendimento.AtualizarMidia(atendimentoId, midiaId);
        }

        public AtendimentoFormViewModel Novo(AtendimentoFormViewModel model)
        {
            switch (model.CanalId)
            {
                case (int) CanalValueObjects.Telefone:
                    model.NomeCanal = "Telefone";
                    model.AtendimentoTelefone = true;
                    break;
                case (int) CanalValueObjects.Email:
                    model.NomeCanal = "E-mail";
                    model.AtendimentoEmail = true;
                    break;
                case (int) CanalValueObjects.Chat:
                    model.NomeCanal = "Chat";
                    model.AtendimentoChat = true;
                    break;
                default:
                    model.ValidationResult.Add(new ValidationError("Canal informado inválido!"));
                    return model;
            }

            var atendimento = _atendimento.AdicionarNovoAtendimento(model.CanalId, model.UsuarioId, model.MidiaId);
            if (!atendimento.ValidationResult.IsValid)
            {
                model.ValidationResult = atendimento.ValidationResult;
                return model;
            }

            model.ListaStatus = _statusAtividadeServico.ObterPor(model.CanalId, model.Sentido ?? "E", null).ToList();
            model.Midias = new SelectList(_midiaServico.ObterPor(null, model.CanalId), "id", "nome");
            model.Procotolo = atendimento.Protocolo;
            model.AtendimentoId = atendimento.Id;
            if (atendimento.CanalOrigemId.HasValue)
                model.CanalId = (int) (atendimento.CanalOrigemId);
            model.MidiaId = atendimento.MidiasId;

            return model;
        }

        //protected ICollection<StatusAtividade> ObterStatusAtividades(int canal, string sentido)
        //{
        //    var listaStatus = new List<StatusAtividade>();

        //    if (string.IsNullOrEmpty(sentido))
        //        sentido = "s"; //return listaStatus;

        //    sentido = sentido.ToLower();

        //    switch (canal)
        //    {
        //        case (int) CanalValueObjects.Telefone:

        //            listaStatus = sentido == "s"
        //                ? _statusAtividadeServico.ObterStatusAtividadeLigacaoAtiva().ToList()
        //                : _statusAtividadeServico.ObterStatusAtividadeLigacaoReceptiva().ToList();

        //            break;
        //        case (int) CanalValueObjects.Email:

        //            listaStatus = sentido == "s"
        //                ? _statusAtividadeServico.ObterStatusAtividadeEmail().ToList()
        //                : _statusAtividadeServico.ObterStatusAtividadeEmailRecebido().ToList();
        //            break;
        //        case (int) CanalValueObjects.Chat:
        //            // Vai ser preciso implementar o Chat
        //            break;
        //    }

        //    return listaStatus;
        //}

        public AtendimentoFormViewModel Atualizar(AtendimentoFormViewModel model)
        {
            switch (model.CanalId)
            {
                case (int) CanalValueObjects.Telefone:

                    break;
                case (int) CanalValueObjects.Email:

                    model.Email.Sentido = model.Sentido;
                    model.Email.UsuarioId = model.UsuarioId;
                    model.Email.StatusId = model.StatusId;
                    model.Email = TratarEmail(model.Email);

                    if (!model.Email.ValidationResult.IsValid)
                        model.ValidationResult = model.Email.ValidationResult;

                    model.AtividadeId = model.Email.AtividadeId;

                    break;
                case (int) CanalValueObjects.Chat:

                    break;
                default:
                    model.ValidationResult.Add(new ValidationError("Canal informado inválido!"));
                    return model;
            }

            if (!model.ValidationResult.IsValid)
                return model;

            var statusAtendimentos = _statusAtividadeServico.ObterPorId((int) model.StatusId);

            //Somente atualiza os dados de Atendimento
            if (!model.AtendimentoId.HasValue) return model;

            var atendimento = _atendimento.ObterPorId((long) model.AtendimentoId);
            atendimento.MidiasId = model.MidiaId;
            atendimento.CanalOrigemId = model.CanalId = model.CanalId;

            if (statusAtendimentos.FinalizaAtendimento)
            {
                atendimento.FinalizadoEm = DateTime.Now;
                atendimento.FinalizadoPorUserId = model.UsuarioId;
            }

            if (atendimento.IsValid())
                _atendimento.Atualizar(atendimento);

            return model;
        }

        public EmailFormViewModel TratarEmail(EmailFormViewModel model)
        {
            ValidarRegrasEmail(model);

            if (!model.ValidationResult.IsValid)
                return model;

            var envolvidos = CarregarEnvolvidos(model);

            if (model.EmailPaiId.HasValue)
            {
                var emailPai = _emailServico.ObterEmailCompletoPor((long) model.EmailPaiId, null);
                if (emailPai != null)
                {
                    model.PessoaJuridicaId = emailPai.Atividade.PessoasJuridicasId;
                    model.PessoaFisicaId = emailPai.Atividade.PessoasFisicasId;
                    model.AtividadePaiId = emailPai.AtividadeId;
                }
            }

            var configuracao = new Configuracao();
            configuracao.SetarUrlEmailAnexos();
            var diretorioArquivos = _configuracaoServico.ObterPorSigla(configuracao.Sigla).Valor;

            if (model.ConfiguracaoContaEmailId.HasValue)
            {
                var configuracaoContaEmail =
                    _configuracaoContaEmailServico.ObterPorId((int) model.ConfiguracaoContaEmailId);

                model.Remetente = configuracaoContaEmail.Email;
                model.FilaId = configuracaoContaEmail.FilasId;
            }

            var htmlCompleto = @"<span style='color:white;mso-themecolor:background1'>IdEmailInicio[EmailId]|" +
                               DateTime.Now + "IdEmailFim <o:p></o:p></span>";
            model.Html = model.Html.Replace("style='pointer-events:none;'", "") + htmlCompleto;
            SalvarImagensTexto(model, diretorioArquivos);
            ProcessarAnexos(model.Anexos, diretorioArquivos);
            var email = _emailServico.Novo(model.UsuarioId, model.UsuarioId, null,
                model.OcorrenciaId,
                null, model.AtendimentoId, model.PessoaFisicaId, model.PessoaJuridicaId,
                null, model.AtividadePaiId, model.Assunto, null,
                model.Remetente, model.Html, model.Html, null, null, model.Sentido, model.Assunto,
                model.EmailPaiId, model.ConfiguracaoContaEmailId, model.FilaId, envolvidos,
                _anexos, model.StatusId, Guid.NewGuid().ToString());

            if (email.ValidationResult.IsValid)
            {
                model.AtividadeId = email.AtividadeId;
                model.EmailId = email.Id;
            }
            else
            {
                model.ValidationResult = email.ValidationResult;
            }

            return model;
        }

        protected void SalvarImagensTexto(EmailFormViewModel model, string diretorioArquivos)
        {
            try
            {
                var doc1 = new HtmlDocument();
                doc1.LoadHtml(model.Html);

                foreach (var item in doc1.DocumentNode.SelectNodes("//img"))
                {
                    var att = item.Attributes["src"];

                    if (att.Value.Trim().Contains("data:"))
                    {
                        try
                        {
                            var binarioImagem =
                                att.Value.Substring((att.Value.IndexOf(",", StringComparison.Ordinal) + 1),
                                    ((att.Value.Length - att.Value.IndexOf(",", StringComparison.Ordinal)) - 1));
                            var dirArquivo = SalvarArrayByteParaImagem(binarioImagem, diretorioArquivos,
                                model.EmailIdProvisorio);

                            if (!string.IsNullOrEmpty(dirArquivo))
                            {
                                var fi = new FileInfo(string.Format("{0}\\{1}", diretorioArquivos, dirArquivo));
                                var contentId = "@" + GetRandomString(10);
                                var novoAnexo = new EmailAnexo(fi.Extension, fi.Name, dirArquivo, fi.Length, true,
                                    contentId);
                                _anexos.Add(novoAnexo);

                                item.SetAttributeValue("src", @"/Imagem/CorpoEmail/" + novoAnexo.IdProvisorio);
                                StringWriter sw = new StringWriter();
                                doc1.Save(sw);
                                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(sw.ToString(),
                                    Encoding.GetEncoding("utf-8"), "text/html");
                                model.Html = sw.ToString();
                            }
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                    else if (att.Value.Trim().Contains("Imagem/CorpoEmail"))
                    {

                        long idEmailAnexo;
                        long.TryParse(
                            att.Value.Substring((att.Value.IndexOf("/CorpoEmail/", StringComparison.Ordinal) + 12),
                                ((att.Value.Length - att.Value.IndexOf("/CorpoEmail/", StringComparison.Ordinal)) -
                                 12)),
                            out idEmailAnexo);

                        if (idEmailAnexo <= 0) continue;

                        var emailAnexo = _emailAnexoServico.ObterPorId(idEmailAnexo);

                        if (emailAnexo == null) continue;

                        var novoAnexo = new EmailAnexo(emailAnexo.Extensao, emailAnexo.Nome, emailAnexo.Path,
                            emailAnexo.Tamanho, emailAnexo.ImagemCorpo, emailAnexo.ContentId);
                        _anexos.Add(novoAnexo);

                        item.SetAttributeValue("src", @"/Imagem/CorpoEmail/" + novoAnexo.IdProvisorio);
                        var sw = new StringWriter();
                        doc1.Save(sw);
                        var htmlView = AlternateView.CreateAlternateViewFromString(sw.ToString(),
                            Encoding.GetEncoding("utf-8"), "text/html");
                        model.Html = sw.ToString();
                    }
                }
            }
            catch (Exception)
            {
                //   utils.log.gravaLog(Server.MapPath("~/"), ex, "Falha capturada no script (Convert numeroTelefone) " + HttpContext.Current.Request.Url.AbsolutePath);
            }
        }

        public void ProcessarAnexos(IEnumerable<EmailAnexosViewModel> anexos, string diretorioArquivos)
        {
            if (anexos == null) return;

            foreach (var anexo in anexos)
            {
                try
                {
                    var fi = new FileInfo(string.Format("{0}\\{1}", diretorioArquivos,
                        anexo.Path.Replace("||*", "\\")));
                    var novoAnexo = new EmailAnexo(fi.Extension, fi.Name, anexo.Path.Replace("||*", "\\"), fi.Length,
                        false, null);
                    _anexos.Add(novoAnexo);
                }
                catch
                {
                    // ignored
                }
            }
        }

        protected void ValidarRegrasEmail(EmailFormViewModel model)
        {
            var bValidaPara = true;
            var bValidaCopia = true;
            var bValidaCopiaOculta = true;
            var bContemEmail = false;
            var bValidaDe = true;

            var sPara = string.IsNullOrEmpty(model.Para) ? "" : model.Para.Replace(",", ";");
            var sCopia = string.IsNullOrEmpty(model.Copia) ? "" : model.Copia.Replace(",", ";");
            var sCopiaOculta = string.IsNullOrEmpty(model.CopiaOculta) ? "" : model.CopiaOculta.Replace(",", ";");
            var sCopiaDe = string.IsNullOrEmpty(model.Remetente) ? "" : model.Remetente.Replace(",", ";");

            if (sPara.Trim() != "")
                foreach (var item in sPara.Split(';'))
                {
                    if (item.Trim() == "") continue;

                    if (!EmailValido(item.Replace(" ", "")))
                        bValidaPara = false;
                    else
                        bContemEmail = true;
                }

            if (!bValidaPara)
                model.ValidationResult.Add(new ValidationError("E-mail no campo (para) inválido!"));


            if (sCopia.Trim() != "")
                foreach (var item in sCopia.Split(';'))
                {
                    if (item.Trim() == "") continue;

                    if (!EmailValido(item.Replace(" ", "")))
                        bValidaCopia = false;
                    else
                        bContemEmail = true;
                }

            if (!bValidaCopia)
                model.ValidationResult.Add(new ValidationError("E-mail no campo (cópia) inválido!"));

            if (sCopiaOculta.Trim() != "")
                foreach (var item in sCopiaOculta.Split(';'))
                {
                    if (item.Trim() == "") continue;

                    if (!EmailValido(item.Replace(" ", "")))
                        bValidaCopiaOculta = false;
                    else
                        bContemEmail = true;
                }

            if (!bValidaCopiaOculta)
                model.ValidationResult.Add(new ValidationError("E-mail no campo (cópia oculta) inválido."));

            if (!bContemEmail)
                model.ValidationResult.Add(
                    new ValidationError("É necessário informar ao menos um endereço de e-mail para envio."));

            if (sCopiaDe.Trim() != "")
                foreach (var item in sCopiaDe.Split(';'))
                {
                    if (item.Trim() == "") continue;

                    if (!EmailValido(item.Replace(" ", "")))
                        bValidaDe = false;
                    else
                        bContemEmail = true;
                }

            if (!bValidaDe)
                model.ValidationResult.Add(new ValidationError("E-mail no campo (De) inválido."));


            if (string.IsNullOrEmpty(model.Assunto))
                model.ValidationResult.Add(new ValidationError("Favor informar o assunto."));
        }

        public static bool EmailValido(string inputEmail)
        {
            inputEmail = inputEmail.Replace("_@", "@");

            const string strRegex =
                "(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[A-Za-z0-9-]*[A-Za-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])";
            var re = new Regex(strRegex);
            return re.IsMatch(inputEmail);
        }

        protected List<AtividadeParteEnvolvida> CarregarEnvolvidos(EmailFormViewModel model)
        {
            var envolvidos = new List<AtividadeParteEnvolvida>();

            if (!string.IsNullOrEmpty(model.Remetente))
                if (model.Remetente.Contains(';'))
                {
                    envolvidos.AddRange(from para in model.Remetente.Split(';')
                        select para.Replace(" ", "")
                        into email
                        where !string.IsNullOrEmpty(email)
                        select new AtividadeParteEnvolvida(email, null, TipoParteEnvolvida.Remetente.Value));
                }
                else
                    envolvidos.Add(new AtividadeParteEnvolvida(model.Remetente.Replace(" ", ""), null,
                        TipoParteEnvolvida.Remetente.Value));

            if (!string.IsNullOrEmpty(model.Para))
                if (model.Para.Contains(';'))
                {
                    envolvidos.AddRange(from para in model.Para.Split(';')
                        select para.Replace(" ", "")
                        into email
                        where !string.IsNullOrEmpty(email)
                        select new AtividadeParteEnvolvida(email, null, TipoParteEnvolvida.Destinatario.Value));
                }
                else
                    envolvidos.Add(new AtividadeParteEnvolvida(model.Para.Replace(" ", ""), null,
                        TipoParteEnvolvida.Destinatario.Value));

            if (!string.IsNullOrEmpty(model.Copia))
                if (model.Copia.Contains(';'))
                {
                    envolvidos.AddRange(from cc in model.Copia.Split(';')
                        select cc.Replace(" ", "")
                        into email
                        where !string.IsNullOrEmpty(email)
                        select new AtividadeParteEnvolvida(email, null, TipoParteEnvolvida.DestinatarioCopia.Value));
                }
                else
                    envolvidos.Add(new AtividadeParteEnvolvida(model.Copia, null,
                        TipoParteEnvolvida.DestinatarioCopia.Value));

            if (string.IsNullOrEmpty(model.CopiaOculta)) return envolvidos;

            if (model.CopiaOculta.Contains(';'))
            {
                envolvidos.AddRange(from cco in model.CopiaOculta.Split(';')
                    select cco.Replace(" ", "")
                    into email
                    where !string.IsNullOrEmpty(email)
                    select new AtividadeParteEnvolvida(email, null, TipoParteEnvolvida.DestinatarioOculto.Value));
            }
            else
                envolvidos.Add(new AtividadeParteEnvolvida(model.CopiaOculta, null,
                    TipoParteEnvolvida.DestinatarioOculto.Value));

            return envolvidos;
        }

        private static string SalvarArrayByteParaImagem(string base64String, string diretorioArquivos,
            string identificador)
        {
            try
            {
                var image = Convert.FromBase64String(base64String);
                var ms = new MemoryStream(image);
                var i = Image.FromStream(ms);
                var extensao = ".jpeg";

                if (ImageFormat.Png.Equals(i.RawFormat))
                {
                    extensao = ".png";
                }
                else if (ImageFormat.Gif.Equals(i.RawFormat))
                {
                    extensao = ".gif";
                }
                else if (ImageFormat.Bmp.Equals(i.RawFormat))
                {
                    extensao = ".bmp";
                }

                var nomeArquivo = Guid.NewGuid() + extensao;

                var dirAnexo = string.Format("{0}\\{1}\\{2}\\{3}\\{4}",
                    "Rascunho", DateTime.Now.Year, DateTime.Now.Month,
                    DateTime.Now.Day, identificador);

                var dirAnexoDownloadArquivo =
                    new DirectoryInfo(string.Format("{0}\\{1}",
                        diretorioArquivos, dirAnexo));

                if (!dirAnexoDownloadArquivo.Exists)
                    dirAnexoDownloadArquivo.Create();

                var dirCompleto = string.Format("{0}\\{1}", dirAnexoDownloadArquivo.FullName, nomeArquivo);

                try
                {
                    i.Save(dirCompleto, i.RawFormat);
                }
                catch (Exception)
                {
                    i.Save("\\\\" + dirCompleto, i.RawFormat);
                }

                return string.Format("{0}\\{1}", dirAnexo, nomeArquivo);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string GetRandomString(int length)
        {
            var result = string.Empty;
            var random = new Random((int) DateTime.Now.Ticks);
            var characters = new List<string>();
            for (var i = 48; i < 58; i++)
            {
                characters.Add(((char) i).ToString());
            }

            for (var i = 65; i < 91; i++)
            {
                characters.Add(((char) i).ToString());
            }

            for (var i = 97; i < 123; i++)
            {
                characters.Add(((char) i).ToString());
            }

            for (var i = 0; i < length; i++)
            {
                result += characters[random.Next(0, characters.Count)];
                Thread.Sleep(1);
            }

            return result;
        }
    }
}
