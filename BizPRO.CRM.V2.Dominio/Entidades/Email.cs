using System;
using DomainValidation.Validation;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Email
    {
        public long Id { get; private set; }
        public string Endereco { get; private set; }
        public bool Ativo { get; private set; }
        public bool Principal { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public string CriadoPorUserId { get; private set; }
        public long? ClientePessoaJuridicaId { get; private set; }
        public long? ClientePessoaFisicaId { get; private set; }
        public long AtividadeId { get; private set; }
        public string CorpoDoEmail { get; private set; }
        public int QuantidadeDeEnvios { get; set; }
        public string Uid { get; private set; }
        public string MessageId { get; private set; }
        public string Sentido { get; private set; }
        public string Assunto { get; private set; }
        public long? EmailPaiId { get; private set; }
        public int? ConfiguracaoContasEmailId { get; private set; }
        public string Texto { get; private set; }
        public string IdentificadorEmail { get; private set; }

        public string Remetente
        {
            get
            {
                try
                {
                    var sb = new StringBuilder();

                    foreach (
                        var item in
                        Atividade.Envolvidos.Where(
                            c => c.TipoParteEnvolvida.Trim() == TipoParteEnvolvida.Remetente.Value).ToList())
                    {
                        if (string.IsNullOrEmpty(sb.ToString()))
                            sb.Append(item.Email.ToLower());
                        else
                            sb.Append("; " + item.Email.ToLower());
                    }
                    return sb.ToString();
                }
                catch
                {
                    return "";
                }
            }
        }

        public string Para
        {
            get
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (
                        var item in
                        Atividade.Envolvidos.Where(
                            c => c.TipoParteEnvolvida.Trim() == TipoParteEnvolvida.Destinatario.Value).ToList())
                    {
                        if (string.IsNullOrEmpty(sb.ToString()))
                            sb.Append(item.Email.ToLower());
                        else
                            sb.Append("; " + item.Email.ToLower());
                    }
                    return sb.ToString();
                }
                catch
                {
                    return "";
                }
            }
        }

        public string Copia
        {
            get
            {
                try
                {
                    var sb = new StringBuilder();

                    foreach (
                        var item in
                        Atividade.Envolvidos.Where(
                            c => c.TipoParteEnvolvida.Trim() == TipoParteEnvolvida.DestinatarioCopia.Value).ToList())
                    {
                        if (string.IsNullOrEmpty(sb.ToString()))
                            sb.Append(item.Email.ToLower());
                        else
                            sb.Append("; " + item.Email.ToLower());
                    }
                    return sb.ToString();
                }
                catch
                {
                    return "";
                }
            }
        }

        public string CopiaOculta
        {
            get
            {
                try
                {
                    var sb = new StringBuilder();

                    foreach (
                        var item in
                        Atividade.Envolvidos.Where(
                            c => c.TipoParteEnvolvida.Trim() == TipoParteEnvolvida.DestinatarioOculto.Value).ToList())
                    {
                        if (string.IsNullOrEmpty(sb.ToString()))
                            sb.Append(item.Email.ToLower());
                        else
                            sb.Append("; " + item.Email.ToLower());
                    }
                    return sb.ToString();
                }
                catch
                {
                    return "";
                }
            }
        }

        public ValidationResult ValidationResult { get; set; }
        public Atividade Atividade { get; set; }
        public IEnumerable<EmailAnexo> Anexos { get; set; }

        public Email()
        {
            Anexos = new List<EmailAnexo>();
            ValidationResult = new ValidationResult();
            Ativo = true;
        }

        public Email(string endereco, string criadoPorUserId, long atividadeId, string corpoDoEmail, string sentido)
        {
            ValidationResult = new ValidationResult();
            Anexos = new List<EmailAnexo>();
            CriadoEm = DateTime.Now;
            Ativo = true;
            Principal = true;
            Endereco = endereco;
            CriadoPorUserId = criadoPorUserId;
            AtividadeId = atividadeId;
            CorpoDoEmail = corpoDoEmail;
            Sentido = sentido;
        }

        public void Inativar(string userId)
        {
            Ativo = false;

            if (Atividade != null)
            {
                Atividade.Finalizar(userId, null);
            }
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public Email(string endereco, string assunto, string html, string texto, string criadoPorUserId, string sentido,
            string uId, string messageId, long? emailPaiId, int? configuracaoContasEmailId,
            IEnumerable<EmailAnexo> anexos, DateTime? criadoEm, Atividade atividade, long? pessoaFisicaId,
            long? pessoaJuridicaId, string identificadorEmail)
        {
            ValidationResult = new ValidationResult();
            Anexos = new List<EmailAnexo>();
            Endereco = endereco;
            Assunto = assunto;
            CriadoPorUserId = criadoPorUserId;
            CorpoDoEmail = html;
            CriadoEm = criadoEm ?? DateTime.Now;
            Ativo = true;
            Sentido = sentido;
            Uid = uId;
            MessageId = string.IsNullOrEmpty(messageId) ? null : messageId.Replace("<", "").Replace(">", "");
            EmailPaiId = emailPaiId;
            Anexos = anexos;
            Atividade = atividade;
            ConfiguracaoContasEmailId = configuracaoContasEmailId;
            Texto = texto;
            ClientePessoaFisicaId = pessoaFisicaId;
            ClientePessoaJuridicaId = pessoaJuridicaId;
            AtividadeId = atividade != null ? atividade.Id : 0;
            IdentificadorEmail = identificadorEmail;
        }

        public bool IsValid()
        {
            //Preciso validar algumas informações aqui
            return true;
        }

        public void SetarAtividadeId(long id)
        {
            AtividadeId = id;
        }

        public void SetarCorpoEmail(string html)
        {
            CorpoDoEmail = html;
        }

        public void SetarIdEmailReferenciaHtml()
        {
            CorpoDoEmail = CorpoDoEmail.Replace("[EmailId]", Id.ToString());
        }
    }
}
