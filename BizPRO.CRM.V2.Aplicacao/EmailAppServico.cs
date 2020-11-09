using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Mvc;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;
using HtmlAgilityPack;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class EmailAppServico : IEmailAppServico
    {
        private readonly IEmailServico _emailServico;
        private readonly IEmailModeloServico _emailModeloServico;
        private readonly IAtividadeServico _atividadeServico;
        private readonly IAtividadeTipoServico _atividadeTipoServico;
        private readonly IStatusAtividadeServico _statusAtividadeServico;
        private readonly IAtividadeParteEnvolvidaServico _atividadeParteEnvolvidaServico;
        private readonly IUsuarioServico _usuarioServico;
        private readonly IConfiguracaoServico _configuracaoServico;
        private readonly IFilaServico _filaServico;
        private readonly IAtividadeFilaServico _atividadeFilaServico;
        private readonly IEmailAnexoServico _emailAnexoServico;
        private readonly IConfiguracaoContasEmailsServico _configuracaoContaEmailServico;
        private readonly IAtendimentoServico _servicoAtendimento;
        private readonly ICanalServico _servicoCanal;
        private readonly IAtividadeServico _servicoAtividade;
        private readonly List<EmailAnexo> _anexos;
        private string _indentificadorEmail;
        private string _indentificadorEmailAnexo;

        public EmailAppServico(IEmailServico emailServico, IEmailModeloServico emailModeloServico,
            IAtividadeServico atividadeServico,
            IAtividadeTipoServico atividadeTipoServico, IStatusAtividadeServico statusAtividadeServico,
            IAtividadeParteEnvolvidaServico atividadeParteEnvolvidaServico,
            IUsuarioServico usuarioServico, IConfiguracaoServico configuracaoServico, IFilaServico filaServico,
            IAtividadeFilaServico atividadeFilaServico, IEmailAnexoServico emailAnexoServico,
            IConfiguracaoContasEmailsServico configuracaoContaEmailServico, IAtendimentoServico servicoAtendimento,
            ICanalServico servicoCanal, IAtividadeServico servicoAtividade)
        {
            _emailServico = emailServico;
            _emailModeloServico = emailModeloServico;
            _atividadeServico = atividadeServico;
            _atividadeTipoServico = atividadeTipoServico;
            _statusAtividadeServico = statusAtividadeServico;
            _atividadeParteEnvolvidaServico = atividadeParteEnvolvidaServico;
            _usuarioServico = usuarioServico;
            _configuracaoServico = configuracaoServico;
            _filaServico = filaServico;
            _atividadeFilaServico = atividadeFilaServico;
            _emailAnexoServico = emailAnexoServico;
            _configuracaoContaEmailServico = configuracaoContaEmailServico;
            _servicoAtendimento = servicoAtendimento;
            _servicoCanal = servicoCanal;
            _servicoAtividade = servicoAtividade;
            _anexos = new List<EmailAnexo>();
        }

        public bool EmailSenha(string url, string email, string userId)
        {
            int statusAtividadeId;
            Usuario usuarioSistema;
            var retorno =
                _emailModeloServico.ObterPor(new EmailModelo { NomeDoModelo = "ESQUECI_MINHA_SENHA" }).FirstOrDefault();

            //colocar o usuario na tabela de configuração
            var usuarioSigla = _configuracaoServico.ObterPorSigla("USSYS");

            if (usuarioSigla != null)
                usuarioSistema = _usuarioServico.BuscarPorNome(usuarioSigla.Valor).FirstOrDefault();
            else
                return false;

            if (retorno != null)
                retorno.Html = retorno.Html.Replace("[URL]", url);
            else
                return false;

            var atividadeTipo = _atividadeTipoServico.BuscarPorNome("Email");

            if (atividadeTipo == null)
                return false;

            var listaStatusEmail = _statusAtividadeServico.ObterStatusAtividadeEmail();

            if (listaStatusEmail.Any())
                statusAtividadeId =
                    listaStatusEmail.FirstOrDefault(c => c.StatusPadrao && c.FinalizaAtividade == false).Id;
            else
                return false;

            int? canalId = null;
            {
                var canal = _servicoCanal.ObterCanalEmail();
                if (canal.ValidationResult.IsValid)
                    canalId = canal.Id;
            }

            var atividade = new Atividade(usuarioSistema.Id, statusAtividadeId, atividadeTipo.Id, "Esqueci Minha Senha",
                null, null, null, null, null, null, null, null, null, null, null, canalId, null);
            _atividadeServico.Adicionar(atividade);

            _atividadeParteEnvolvidaServico.Adicionar(new AtividadeParteEnvolvida(atividade.Id, null, null, null,
                usuarioSistema.Id, "R", usuarioSistema.EnderecoEmail, usuarioSistema.Nome));
            _atividadeParteEnvolvidaServico.Adicionar(new AtividadeParteEnvolvida(atividade.Id, null, null, null, userId,
                "D", email, null));

            var _email = new Email(email, userId, atividade.Id, retorno.Html, "S");

            _emailServico.Adicionar(_email);

            var fila = _filaServico.ObterFilasPorNome("EMAIL_TROCA_SENHA").FirstOrDefault();

            if (fila != null)
                _atividadeFilaServico.Adicionar(new AtividadeFila(atividade.Id, fila.Id));
            else
                return false;

            return true;
        }

        public EmailViewModel CarregarEmailVisualizacao(long atividadeId)
        {
            var email = _emailServico.ObterEmailCompletoPor(null, atividadeId);
            var envolvidos = _atividadeParteEnvolvidaServico.ObterPorAtividadeId(atividadeId);
            return new EmailViewModel(email.AtividadeId, email.Id, email.CorpoDoEmail, email.Texto, email.Assunto,
                email.CriadoEm, email.Atividade.CriadoEm, envolvidos, email.Sentido);
        }

        public IEnumerable<EmailAnexosViewModel> CarregarAnexos(long atividadeId)
        {
            var retorno = new List<EmailAnexosViewModel>();
            var configuracao = new Configuracao();
            configuracao.SetarUrlEmailAnexos();
            var anexos = _emailAnexoServico.ObterAnexos(atividadeId).Where(c => c.ImagemCorpo == false);

            retorno.AddRange(
                anexos.Select(
                    anexo => new EmailAnexosViewModel(anexo.Id, anexo.Nome, anexo.Path, anexo.Tamanho, anexo.Extensao)));

            return retorno;
        }

        //public EmailViewModel CarregarNovoEmail(long? atividadeId, string tipo, long? filaId, long? pessoaFisicaId,
        //    long? pessoaJuridicaId, string usuarioId, long? ocorrenciaId)
        //{
        //    Email email;
        //    int? configuracaoContaEmailId = null;
        //    long? emailPaidId = null, atividadePaiId = null, atendimentoId = null;

        //    if (atividadeId != null)
        //    {
        //        email = _emailServico.ObterEmailCompletoPor(null, atividadeId);
        //        var configuracaoContaEmail =
        //            _configuracaoContaEmailServico.ObterContaEmailPorAtividadeId((long)atividadeId);

        //        if (configuracaoContaEmail != null)
        //            configuracaoContaEmailId = configuracaoContaEmail.Id;


        //        if (email != null)
        //        {
        //            pessoaFisicaId = email.ClientePessoaFisicaId;
        //            pessoaJuridicaId = email.ClientePessoaJuridicaId;
        //            emailPaidId = email.Id;
        //            atividadePaiId = email.AtividadeId;

        //            if (email.Atividade != null)
        //                if (email.Atividade.OcorrenciaId.HasValue)
        //                    ocorrenciaId = email.Atividade.OcorrenciaId;
        //        }
        //    }
        //    else
        //    {
        //        email = null;

        //        if (filaId != null)
        //        {
        //            var configuracaoContaEmail = _configuracaoContaEmailServico.ObterPorFilaId((int)filaId);
        //            if (configuracaoContaEmail != null)
        //                configuracaoContaEmailId = configuracaoContaEmail.Id;
        //        }
        //        else
        //        {
        //            var configuracaoContaEmail = _configuracaoContaEmailServico.ObterContaPadrao();
        //            if (configuracaoContaEmail != null)
        //            {
        //                configuracaoContaEmailId = configuracaoContaEmail.Id;
        //            }
        //        }
        //    }

        //    if (!configuracaoContaEmailId.HasValue)
        //    {
        //        var retorno = new EmailViewModel();
        //        retorno.ValidationResult.Add(
        //            new ValidationError("Não é possível enviar emails dessa Fila, CONTA ENVIO NÂO CADASTRADA!"));
        //        return retorno;
        //    }

        //    var configuracaoContasEmail = _configuracaoContaEmailServico.ObterPorUsuarioId(usuarioId);

        //    if (configuracaoContasEmail.Any())
        //    {
        //        configuracaoContasEmail.ToList().Add(new ConfiguracaoContasEmails { Id = 0, Email = "Selecione..." });
        //    }

        //    return new EmailViewModel(configuracaoContaEmailId, tipo, pessoaFisicaId, pessoaJuridicaId,
        //        new SelectList(configuracaoContasEmail, "id", "email"), emailPaidId, atividadePaiId, null, ocorrenciaId,
        //        atendimentoId, email);
        //}


        public EmailViewModel CarregarNovoEmail(long? atividadeId, string tipo, long? filaId, long? pessoaFisicaId,
            long? pessoaJuridicaId, string usuarioId, long? ocorrenciaId)
        {
            Email email;
            int? configuracaoContaEmailId = null;
            long? emailPaidId = null, atividadePaiId = null, atendimentoId = null;
            var assinatura = "";

            if (atividadeId != null)
            {
                email = _emailServico.ObterEmailCompletoPor(null, atividadeId);
                var configuracaoContaEmail =
                    _configuracaoContaEmailServico.ObterContaEmailPorAtividadeId((long)atividadeId);

                if (configuracaoContaEmail != null)
                {
                    configuracaoContaEmailId = configuracaoContaEmail.Id;
                    assinatura = configuracaoContaEmail.Assinatura;
                }


                if (email != null)
                {
                    pessoaFisicaId = email.ClientePessoaFisicaId;
                    pessoaJuridicaId = email.ClientePessoaJuridicaId;
                    emailPaidId = email.Id;
                    atividadePaiId = email.AtividadeId;

                    if (email.Atividade != null)
                        if (email.Atividade.OcorrenciaId.HasValue)
                            ocorrenciaId = email.Atividade.OcorrenciaId;
                }
            }
            else
            {
                email = null;

                if (filaId != null)
                {
                    var configuracaoContaEmail = _configuracaoContaEmailServico.ObterPorFilaId((int)filaId);
                    if (configuracaoContaEmail != null)
                    {
                        configuracaoContaEmailId = configuracaoContaEmail.Id;
                        assinatura = configuracaoContaEmail.Assinatura;
                    }
                }
                else
                {
                    var configuracaoContaEmail = _configuracaoContaEmailServico.ObterContaPadrao();
                    if (configuracaoContaEmail != null)
                    {
                        configuracaoContaEmailId = configuracaoContaEmail.Id;
                        assinatura = configuracaoContaEmail.Assinatura;
                    }
                }
            }

            if (!configuracaoContaEmailId.HasValue)
            {
                var retorno = new EmailViewModel();
                retorno.ValidationResult.Add(
                    new ValidationError("Não é possível enviar emails dessa Fila, CONTA ENVIO NÂO CADASTRADA!"));
                return retorno;
            }

            var configuracaoContasEmail = _configuracaoContaEmailServico.ObterPorUsuarioId(usuarioId);

            if (configuracaoContasEmail.Any())
            {
                configuracaoContasEmail.ToList().Add(new ConfiguracaoContasEmails { Id = 0, Email = "Selecione..." });
            }

            return new EmailViewModel(configuracaoContaEmailId, tipo, pessoaFisicaId, pessoaJuridicaId,
                new SelectList(configuracaoContasEmail, "id", "email"), emailPaidId, atividadePaiId, null, ocorrenciaId,
                atendimentoId, email, assinatura);
        }

        public ValidationResult Adicionar(EmailViewModel viewModel, string userId)
        {
            ValidarNovoEmail(viewModel);

            if (!viewModel.ValidationResult.IsValid)
                return viewModel.ValidationResult;

            var envolvidos = CarregarEnvolvidos(viewModel);

            if (viewModel.EmailPaiId.HasValue)
            {
                var emailPai = _emailServico.ObterEmailCompletoPor((long)viewModel.EmailPaiId, null);
                if (emailPai != null)
                {
                    viewModel.PessoaJuridicaId = emailPai.Atividade.PessoasJuridicasId;
                    viewModel.PessoaFisicaId = emailPai.Atividade.PessoasFisicasId;
                    viewModel.PotencialClienteId = emailPai.Atividade.PotenciaisClientesId;
                    viewModel.AtividadePaiId = emailPai.AtividadeId;
                    viewModel.OcorrenciaId = emailPai.Atividade.OcorrenciaId;
                }
            }

            _indentificadorEmail = viewModel.IdentificadorEmail == ""
                ? Guid.NewGuid().ToString()
                : viewModel.IdentificadorEmail;
            var configuracao = new Configuracao();
            configuracao.SetarUrlEmailAnexos();
            var diretorioArquivos = _configuracaoServico.ObterPorSigla(configuracao.Sigla).Valor;
            var configuracaoContaEmail =
                _configuracaoContaEmailServico.ObterPorId((int)viewModel.ConfiguracaoContaEmaild);

            envolvidos.Add(new AtividadeParteEnvolvida(configuracaoContaEmail.Email, null,
                TipoParteEnvolvida.Remetente.Value));

            var htmlCompleto = @"<span style='color:white;mso-themecolor:background1'>IdEmailInicio[EmailId]|" +
                               DateTime.Now + "IdEmailFim <o:p></o:p></span>";
            viewModel.Html = viewModel.Html.Replace("style='pointer-events:none;'", "") + htmlCompleto;
            SalvarImagensTexto(viewModel, diretorioArquivos);
            ProcessarAnexos(viewModel.Anexos, diretorioArquivos);
            viewModel.ValidationResult = _emailServico.AdicionarEmail(userId, null, null, viewModel.OcorrenciaId,
                viewModel.ContratoId, viewModel.AtendimentoId, viewModel.PessoaFisicaId, viewModel.PessoaJuridicaId,
                viewModel.PotencialClienteId, viewModel.AtividadePaiId, viewModel.Assunto, null,
                configuracaoContaEmail.Email, viewModel.Html, viewModel.Texto, null, null, "S", viewModel.Assunto,
                viewModel.EmailPaiId, configuracaoContaEmail.Id, (int)configuracaoContaEmail.FilasId, envolvidos,
                _anexos, null, _indentificadorEmail).ValidationResult;
            return viewModel.ValidationResult;
        }

        protected void SalvarImagensTexto(EmailViewModel model, string diretorioArquivos)
        {
            try
            {
                var doc1 = new HtmlDocument();
                doc1.LoadHtml(model.Html);

                foreach (var item in doc1.DocumentNode.SelectNodes("//img"))
                {
                    HtmlAttribute att = item.Attributes["src"];

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
                                string contentId = "@" + GetRandomString(10);
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
                                ((att.Value.Length - att.Value.IndexOf("/CorpoEmail/", StringComparison.Ordinal)) - 12)),
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
                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(sw.ToString(),
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

        private string SalvarArrayByteParaImagem(string base64String, string diretorioArquivos, string identificador)
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

        protected void ValidarNovoEmail(EmailViewModel model)
        {
            var bValidaPara = true;
            var bValidaCopia = true;
            var bValidaCopiaOculta = true;
            var bContemEmail = false;

            var sPara = string.IsNullOrEmpty(model.Para) ? "" : model.Para.Replace(",", ";");
            var sCopia = string.IsNullOrEmpty(model.Copia) ? "" : model.Copia.Replace(",", ";");
            var sCopiaOculta = string.IsNullOrEmpty(model.CopiaOculta) ? "" : model.CopiaOculta.Replace(",", ";");

            if (sPara.Trim() != "")
                foreach (var item in sPara.Split(';'))
                {
                    if (item.Trim() == "") continue;

                    if (!EmailValido(item.Replace(" ", "")))
                        bValidaPara = false;
                    else
                        bContemEmail = true;
                }

            if (string.IsNullOrEmpty(model.Assunto))
                model.ValidationResult.Add(new ValidationError("Favor informar o assunto."));

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
        }

        public static bool EmailValido(string inputEmail)
        {
            inputEmail = inputEmail.Replace("_@", "@");

            const string strRegex =
                "(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[A-Za-z0-9-]*[A-Za-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])";
            var re = new Regex(strRegex);
            return re.IsMatch(inputEmail);
        }

        public EmailViewModel CarregarTratar(long emailId, string userId)
        {
            var email = _emailServico.ObterEmailCompletoPor(emailId, null);
            var model = new EmailViewModel
            {
                Assunto = email.Assunto,
                DataEmail = email.CriadoEm,
                DataEntrada = email.Atividade.CriadoEm,
                EmailRemetente = email.Remetente,
                Html = email.CorpoDoEmail,
                Para = email.Para,
                Copia = email.Copia,
                CopiaOculta = email.CopiaOculta
            };

            if (email.Atividade.AtendimentoId == null)
            {
                var canal = _servicoCanal.ObterPorNome("email");
                var atendimento = new Atendimento(userId, _servicoAtendimento.GerarNumeroProtocolo(DateTime.Now),
                    canal != null ? canal.FirstOrDefault().Id : (int?)null, null);
                _servicoAtendimento.Adicionar(atendimento);
                _servicoAtividade.AtualizarAtendimentoId(email.Atividade.Id, atendimento.Id);
                model.NumeroProtocolo = atendimento.Protocolo;
                model.AtendimentoId = atendimento.Id;
            }


            //if (email.Atividade != null)
            //{
            //    var AtividadeCompleto = _servicoAtividade.ObterAtividadeCompletaPor(email.Atividade.id);
            //}

            return model;
        }

        public void Excluir(long id, string userId)
        {
            _emailServico.RegistrarSpam(id, userId, null);
        }

        public static string GetRandomString(int length)
        {
            var result = string.Empty;
            var random = new Random((int)DateTime.Now.Ticks);
            var characters = new List<string>();
            for (var i = 48; i < 58; i++)
            {
                characters.Add(((char)i).ToString());
            }
            for (var i = 65; i < 91; i++)
            {
                characters.Add(((char)i).ToString());
            }
            for (var i = 97; i < 123; i++)
            {
                characters.Add(((char)i).ToString());
            }
            for (var i = 0; i < length; i++)
            {
                result += characters[random.Next(0, characters.Count)];
                Thread.Sleep(1);
            }
            return result;
        }

        public int PossuiNovosEmails(string userId)
        {
            return _emailServico.PossuiNovosEmails(userId);
        }

        public Email BuscarProximoEmail(string userId)
        {
            return _emailServico.BuscarProximoEmail(userId);
        }

        public void ProcessarAnexos(IEnumerable<EmailAnexosViewModel> anexos, string diretorioArquivos)
        {
            if (anexos == null) return;

            foreach (var anexo in anexos)
            {
                try
                {
                    var fi = new FileInfo(string.Format("{0}\\{1}", diretorioArquivos, anexo.Path.Replace("||*", "\\")));
                    var novoAnexo = new EmailAnexo(fi.Extension, anexo.Nome, anexo.Path.Replace("||*", "\\"), fi.Length,
                        false, null, anexo.IdentificadorAnexoItem);
                    _anexos.Add(novoAnexo);
                }
                catch
                {
                    // ignored
                }
            }
        }

        protected List<AtividadeParteEnvolvida> CarregarEnvolvidos(EmailViewModel viewModel)
        {
            var envolvidos = new List<AtividadeParteEnvolvida>();

            if (!string.IsNullOrEmpty(viewModel.Para))
                if (viewModel.Para.Contains(';'))
                {
                    envolvidos.AddRange(from para in viewModel.Para.Split(';')
                                        select para.Replace(" ", "")
                                            into email
                                            where !string.IsNullOrEmpty(email)
                                            select new AtividadeParteEnvolvida(email, null, TipoParteEnvolvida.Destinatario.Value));
                }
                else
                    envolvidos.Add(new AtividadeParteEnvolvida(viewModel.Para.Replace(" ", ""), null,
                        TipoParteEnvolvida.Destinatario.Value));

            if (!string.IsNullOrEmpty(viewModel.Copia))
                if (viewModel.Copia.Contains(';'))
                {
                    envolvidos.AddRange(from cc in viewModel.Copia.Split(';')
                                        select cc.Replace(" ", "")
                                            into email
                                            where !string.IsNullOrEmpty(email)
                                            select new AtividadeParteEnvolvida(email, null, TipoParteEnvolvida.DestinatarioCopia.Value));
                }
                else
                    envolvidos.Add(new AtividadeParteEnvolvida(viewModel.Copia, null,
                        TipoParteEnvolvida.DestinatarioCopia.Value));

            if (string.IsNullOrEmpty(viewModel.CopiaOculta)) return envolvidos;

            if (viewModel.CopiaOculta.Contains(';'))
            {
                envolvidos.AddRange(from cco in viewModel.CopiaOculta.Split(';')
                                    select cco.Replace(" ", "")
                                        into email
                                        where !string.IsNullOrEmpty(email)
                                        select new AtividadeParteEnvolvida(email, null, TipoParteEnvolvida.DestinatarioOculto.Value));
            }
            else
                envolvidos.Add(new AtividadeParteEnvolvida(viewModel.CopiaOculta, null,
                    TipoParteEnvolvida.DestinatarioOculto.Value));

            return envolvidos;
        }

        public EmailFormViewModel Novo(EmailFormViewModel model)
        {
            if (string.IsNullOrEmpty(model.Sentido))
                model.Sentido = "s";

            if (model.Sentido == "s")
            {
                model.ConfiguracaoContasEmail =
                    new SelectList(_configuracaoContaEmailServico.ObterPorUsuarioId(model.UsuarioId),
                        "id", "email");
            }
            else
            {
                model.ConfiguracaoContasEmail =
                    new SelectList(_configuracaoContaEmailServico.ObterRegistroEmailEntrada(model.UsuarioId),
                        "id", "email");
            }

            if (model.FilaId.HasValue)
            {
                var configuracaoContaEmail = _configuracaoContaEmailServico.ObterPorFilaId((int)model.FilaId);
                if (configuracaoContaEmail != null)
                    model.ConfiguracaoContaEmailId = configuracaoContaEmail.Id;
            }
            else
            {
                var configuracaoContaEmail = _configuracaoContaEmailServico.ObterContaPadrao();
                if (configuracaoContaEmail != null)
                    model.ConfiguracaoContaEmailId = configuracaoContaEmail.Id;
            }

            return model;
        }

        public EmailFormViewModel AdicionarNew(EmailFormViewModel model)
        {
            return TratarEmailNew(model);
        }

        public EmailFormViewModel TratarEmailNew(EmailFormViewModel model)
        {
            ValidarRegrasEmailNew(model);

            if (!model.ValidationResult.IsValid)
                return model;

            var envolvidos = CarregarEnvolvidosNew(model);

            if (model.EmailPaiId.HasValue)
            {
                var emailPai = _emailServico.ObterEmailCompletoPor((long)model.EmailPaiId, null);
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
                    _configuracaoContaEmailServico.ObterPorId((int)model.ConfiguracaoContaEmailId);

                model.Remetente = configuracaoContaEmail.Email;
                model.FilaId = configuracaoContaEmail.FilasId;
            }

            var htmlCompleto = @"<span style='color:white;mso-themecolor:background1'>IdEmailInicio[EmailId]|" +
                               DateTime.Now + "IdEmailFim <o:p></o:p></span>";
            model.Html = model.Html.Replace("style='pointer-events:none;'", "") + htmlCompleto;
            SalvarImagensTextoNew(model, diretorioArquivos);
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

        protected void SalvarImagensTextoNew(EmailFormViewModel model, string diretorioArquivos)
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
                                string contentId = "@" + GetRandomString(10);
                                var novoAnexo = new EmailAnexo(fi.Extension, fi.Name, dirArquivo, fi.Length, true,
                                    contentId);
                                _anexos.Add(novoAnexo);

                                item.SetAttributeValue("src", @"/Imagem/CorpoEmail/" + novoAnexo.IdProvisorio);
                                var sw = new StringWriter();
                                doc1.Save(sw);
                                var htmlView = AlternateView.CreateAlternateViewFromString(sw.ToString(),
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
                                ((att.Value.Length - att.Value.IndexOf("/CorpoEmail/", StringComparison.Ordinal)) - 12)),
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

        protected void ValidarRegrasEmailNew(EmailFormViewModel model)
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

        protected List<AtividadeParteEnvolvida> CarregarEnvolvidosNew(EmailFormViewModel model)
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
    }
}
