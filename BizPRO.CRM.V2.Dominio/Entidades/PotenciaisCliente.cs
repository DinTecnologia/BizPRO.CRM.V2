using System;
using DomainValidation.Validation;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Validacoes.PotenciaisClientes;


namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class PotenciaisCliente
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public string documento { get; set; }
        public string contato { get; set; }
        public string contatoDocumento { get; set; }
        public string email { get; set; }
        public string contatoEmail { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public int? CidadesID { get; set; }
        public string responsavelPorAspNetUserID { get; set; }
        public DateTime responsavelDesde { get; set; }
        public string criadoPorAspNetUserID { get; set; }
        public DateTime criadoEm { get; set; }
        public string alteradoPorAspNetUserID { get; set; }
        public DateTime? alteradoEm { get; set; }
        public IEnumerable<Telefone> ListaTelefones { get; set; }
        public DateTime? convertidoEmClienteEm { get; set; }
        public string convertidoEmClientePorAspNetUserID { get; set; }
        public long? convertidoEmClientePessoasFisicasID { get; set; }
        public long? convertidoEmClientePessoasJuridicasID { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public PotenciaisCliente()
        {
            ValidationResult = new ValidationResult();
        }

        public bool IsValid()
        {
            ValidationResult = new PotenciaisClienteValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }

        public PotenciaisCliente
        (
            long? id
            , string nome
            , string documento
            , string contato
            , string contatoDocumento
            , string email
            , string logradouro
            , string numero
            , string bairro
            , int? CidadesID
            , string criadoPorAspNetUserID
            , string tipo
            , string cep
            , string contatoEmail
            , string alteradoPorAspNetUserID
            , DateTime? convertidoEmClienteEm
            , string convertidoEmClientePorAspNetUserID
            , long? convertidoEmClientePessoasFisicasID
            , long? convertidoEmClientePessoasJuridicasID
        )
        {
            if (id != null)
                this.id = (long) id;
            this.nome = nome;
            this.documento = documento;
            this.contato = contato;
            this.contatoDocumento = contatoDocumento;
            this.email = email;
            this.logradouro = logradouro;
            this.numero = numero;
            this.bairro = bairro;
            this.CidadesID = CidadesID;
            this.criadoPorAspNetUserID = criadoPorAspNetUserID;
            this.tipo = tipo;
            this.cep = cep;
            this.contatoEmail = contatoEmail;
            this.alteradoPorAspNetUserID = alteradoPorAspNetUserID;
            this.convertidoEmClienteEm = convertidoEmClienteEm;
            this.convertidoEmClientePorAspNetUserID = convertidoEmClientePorAspNetUserID;
            this.convertidoEmClientePessoasFisicasID = convertidoEmClientePessoasFisicasID;
            this.convertidoEmClientePessoasJuridicasID = convertidoEmClientePessoasJuridicasID;
            ValidationResult = new ValidationResult();
        }
    }
}