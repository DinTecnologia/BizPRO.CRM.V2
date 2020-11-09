using System;
using System.ComponentModel.DataAnnotations;
using ValidationResult = DomainValidation.Validation.ValidationResult;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class LocalViewModel
    {
        public string Id { get; set; }
        public string CodigoIdentificacao { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Nome Contato")]
        public string NomeContato { get; set; }

        [Display(Name = "Tipo Local")]
        public string LocalTipo { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        [Display(Name = "Telefone#1")]
        public string Telefone01 { get; set; }

        [Display(Name = "Telefone#2")]
        public string Telefone02 { get; set; }

        [Display(Name = "Telefone#3")]
        public string Telefone03 { get; set; }

        [Display(Name = "E-mail#1")]
        public string Email01 { get; set; }

        [Display(Name = "E-mail#2")]
        public string Email02 { get; set; }

        [Display(Name = "Site")]
        public string WebSite { get; set; }

        public long? LocalAtendimentoID { get; set; }
        public string EnderecoProduto { get; set; }
        public string NomeSegmento { get; set; }
        public string NomeTipoAtendimento { get; set; }

        public string EnderecoCompleto
        {
            get
            {
                return String.Format("{0}, {1} - {2}, {3} - {4}, {5}", Logradouro, Numero, Bairro, Cidade, Estado, Cep);
            }
        }

        public string Telefones
        {
            get
            {
                var retorno = "";

                if (!string.IsNullOrEmpty(Telefone01))
                    retorno = Telefone01;

                if (!string.IsNullOrEmpty(Telefone02))
                    retorno += " / " + Telefone02;

                if (!string.IsNullOrEmpty(Telefone03))
                    retorno += " / " + Telefone03;

                return retorno;
            }
        }

        public string Emails
        {
            get
            {
                var retorno = "";

                if (!string.IsNullOrEmpty(Email01))
                    retorno = Email01;

                if (!string.IsNullOrEmpty(Email02))
                    retorno += " / " + Email02;

                return retorno;
            }
        }

        public ValidationResult ValidationResult { get; set; }

        public LocalViewModel()
        {
            ValidationResult = new ValidationResult();
        }

        public LocalViewModel(string nome, string nomeContato, string localTipo, string logradouro, string numero,
            string bairro, string cidade, string estado, string cep, double? latitude, double? longitude,
            string telefone1, string telefone2, string telefone3, string email1, string email2, string webSite,
            long? localAtendimentoId, string enderecoProduto)
        {
            ValidationResult = new ValidationResult();
            Nome = nome;
            NomeContato = nomeContato;
            LocalTipo = localTipo;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Latitude = latitude != null ? "" : latitude.ToString();
            Longitude = longitude != null ? "" : longitude.ToString();
            Telefone01 = telefone1;
            Telefone02 = telefone2;
            Telefone03 = telefone3;
            Email01 = email1;
            Email02 = email2;
            WebSite = webSite;
            LocalAtendimentoID = localAtendimentoId;
            EnderecoProduto = enderecoProduto;
        }

        public LocalViewModel(string nome, string nomeLocalTipo, string logradouro, string numero, string bairro,
            string cidade, string estado, string cep, string telefone1, string telefone2, string telefone3,
            string email1, string email2, string webSite, string enderecoProduto, string nomeTipoAtendimento)
        {
            ValidationResult = new ValidationResult();
            Nome = nome;
            NomeContato = nomeLocalTipo;
            LocalTipo = LocalTipo;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Telefone01 = telefone1;
            Telefone02 = telefone2;
            Telefone03 = telefone3;
            Email01 = email1;
            Email02 = email2;
            WebSite = webSite;
            EnderecoProduto = enderecoProduto;
            NomeTipoAtendimento = nomeTipoAtendimento;
        }
    }
}
