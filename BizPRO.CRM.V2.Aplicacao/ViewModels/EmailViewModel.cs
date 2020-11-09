using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class EmailViewModel
    {
        public long? EmailId { get; set; }
        public long? AtividadePaiId { get; set; }
        public long? EmailPaiId { get; set; }
        public long AtividadeId { get; set; }
        public int? ConfiguracaoContaEmaild { get; set; }
        public string Assunto { get; set; }
        public string EmailIdProvisorio { get; set; }
        public string Sentido { get; set; }
        public string IdentificadorEmail { get; set; }
        public SelectList ConfiguracaoContasEmail { get; set; }

        [AllowHtml]
        public string Texto { get; set; }

        [AllowHtml]
        public string Html { get; set; }

        public DateTime DataEmail { get; set; }
        public DateTime DataEntrada { get; set; }
        public string Remetente { get; set; }
        public string EmailRemetente { get; set; }
        public string Para { get; set; }
        public string Copia { get; set; }
        public string CopiaOculta { get; set; }

        public long? OcorrenciaId { get; set; }
        public long? ContratoId { get; set; }
        public long? AtendimentoId { get; set; }
        public long? PessoaFisicaId { get; set; }
        public long? PessoaJuridicaId { get; set; }
        public long? PotencialClienteId { get; set; }
        public string NumeroProtocolo { get; set; }
        public ClientePerfilViewModel Cliente { get; set; }
        public IEnumerable<StatusAtividade> ListaStatusAtividade { get; set; }
        public List<EmailAnexosViewModel> Anexos { get; set; }
        public bool Modal { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public EmailViewModel()
        {
            ValidationResult = new ValidationResult();
            Anexos = new List<EmailAnexosViewModel>();
            EmailIdProvisorio = Guid.NewGuid().ToString();
            Sentido = "Não Informado";
        }

        public EmailViewModel(long atividadeId, long emailId, string corpoDoEmail, string texto, string assunto,
            DateTime dataEmail, DateTime dataEntrada, IEnumerable<AtividadeParteEnvolvida> envolvidos, string sentido)
        {
            EmailIdProvisorio = Guid.NewGuid().ToString();
            ValidationResult = new ValidationResult();
            Anexos = new List<EmailAnexosViewModel>();
            AtividadeId = atividadeId;
            EmailId = emailId;
            Assunto = assunto;
            Texto = texto;
            Html = corpoDoEmail;
            DataEmail = dataEmail;
            DataEntrada = dataEntrada;
            Sentido = "Não Informado";

            if (!string.IsNullOrEmpty(sentido))
            {
                Sentido = sentido.ToUpper().Trim() == "E" ? "Recebido" : "Enviado";
            }

            var sbPara = new StringBuilder();
            var sbCopia = new StringBuilder();
            var sbCopiaOculta = new StringBuilder();
            if (envolvidos == null) return;


            foreach (var envolvido in envolvidos)
            {
                switch (envolvido.TipoParteEnvolvida.Trim().ToUpper())
                {
                    case "R":
                        Remetente = string.IsNullOrEmpty(envolvido.Nome) ? "" : envolvido.Nome;
                        EmailRemetente = string.IsNullOrEmpty(envolvido.Email) ? "Não identificado" : envolvido.Email;
                        break;
                    case "D":
                        if (sbPara.Length == 0)
                            sbPara.Append(envolvido.Email);
                        else
                            sbPara.Append("; " + envolvido.Email);
                        break;
                    case "DC":
                        if (sbCopia.Length == 0)
                            sbCopia.Append(envolvido.Email);
                        else
                            sbCopia.Append("; " + envolvido.Email);
                        break;
                    case "DO":
                        if (sbCopiaOculta.Length == 0)
                            sbCopiaOculta.Append(envolvido.Email);
                        else
                            sbCopiaOculta.Append("; " + envolvido.Email);
                        break;
                }
            }

            Para = sbPara.ToString();
            Copia = sbCopia.ToString();
            CopiaOculta = sbCopiaOculta.ToString();
        }

        public EmailViewModel(int? configuracaoContaEmaild, string tipo, long? pessoaFisicaId, long? pessoaJuridicaId,
            SelectList configuracaoContasEmail, long? emailPaiId, long? atividadePaiId, long? atividadeId,
            long? ocorrenciaId, long? atendimentoId, Email emailPai, string assinatura)
        {
            EmailIdProvisorio = Guid.NewGuid().ToString();
            Anexos = new List<EmailAnexosViewModel>();
            ValidationResult = new ValidationResult();
            ConfiguracaoContaEmaild = configuracaoContaEmaild;
            ConfiguracaoContasEmail = configuracaoContasEmail;
            EmailPaiId = emailPaiId;
            AtividadePaiId = atividadePaiId;
            OcorrenciaId = ocorrenciaId;
            AtendimentoId = atendimentoId;
            PessoaJuridicaId = pessoaJuridicaId;
            PessoaFisicaId = pessoaFisicaId;
            PotencialClienteId = null;
            Sentido = "Enviado";
            DataEmail = DateTime.Now;

            var sb = new StringBuilder();
            sb.Append("</br></br>");

            if (!string.IsNullOrEmpty(assinatura))
                sb.Append("<div id='dvAssinaturaConta_" + EmailIdProvisorio + "'></div>");
            else
                sb.Append("<div id='dvAssinaturaConta_" + EmailIdProvisorio + "'>" + assinatura + "</div>");

            if (emailPai == null)
            {
                Texto = sb.ToString();
                return;
            }

            sb.Append("</br><hr />");
            sb.Append(ObterCabecalho(emailPai));
            sb.Append(emailPai.CorpoDoEmail);

            //if (emailPai == null) return;

            //var sb = new StringBuilder();
            //sb.Append("</br></br>");
            ////ObterAssinatura -> quando definir as régras e colocar em produção
            //sb.Append("</br><hr />");
            //sb.Append(ObterCabecalho(emailPai));
            //sb.Append(emailPai.CorpoDoEmail);

            // R: Responder, T: Todos, E: Encaminhar
            Assunto = "RES: " + emailPai.Assunto;
            switch (tipo)
            {
                case "T":
                    Para = emailPai.Remetente;

                    if (!string.IsNullOrEmpty(emailPai.Para))
                        Para = Para + "; " + emailPai.Para;

                    if (!string.IsNullOrEmpty(emailPai.Copia))
                        Copia = emailPai.Copia;
                    break;
                case "R":
                    Para = string.IsNullOrEmpty(emailPai.Remetente) ? emailPai.Endereco : emailPai.Remetente;
                    break;
                default:
                    Assunto = "ENC: " + emailPai.Assunto;

                    if (emailPai.Anexos != null)
                    {
                        foreach (var anexo in emailPai.Anexos.Where(w => w.ImagemCorpo == false))
                        {
                            Anexos.Add(new EmailAnexosViewModel(anexo.Id, anexo.Nome, anexo.Path, anexo.Tamanho,
                                anexo.Extensao));
                        }
                    }
                    break;
            }
            Texto = sb.ToString();
        }

        protected string ObterCabecalho(Email oEntrada)
        {
            if (oEntrada == null)
                return "";

            var sCabecalho = "";
            sCabecalho += "<b>De: </b>" + oEntrada.Endereco + "<br/>";
            sCabecalho += "<b>Enviada em: </b>" + Convert.ToDateTime(oEntrada.CriadoEm).ToLongDateString() + " - " +
                          Convert.ToDateTime(oEntrada.CriadoEm).ToLongTimeString() + "</br>";

            if (!string.IsNullOrEmpty(oEntrada.Para))
            {
                sCabecalho += "<b>Para: </b>" + oEntrada.Para;
            }

            if (!string.IsNullOrEmpty(oEntrada.Copia))
            {
                if (sCabecalho != string.Empty)
                    sCabecalho += "<br/>";

                sCabecalho += "<b>Cópia: </b>" + oEntrada.Copia;
            }

            sCabecalho += "<br/>";
            sCabecalho += "<b>Assunto: </b>" + oEntrada.Assunto + "</br></br>";
            return sCabecalho;
        }
    }
}
