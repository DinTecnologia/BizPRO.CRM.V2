using System;
using BizPRO.CRM.V2.Core.ValueObjects;
using BizPRO.CRM.V2.Dominio.Especificacoes.Usuarios;
using BizPRO.CRM.V2.Dominio.Validacoes.Usuarios;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Entidades
{
    public class Usuario
    {
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public string CriadoPor { get; private set; }
        public DateTime? AlteradoEm { get; private set; }
        public string AlteradoPor { get; private set; }
        public bool Ativo { get; private set; }
        public ValidationResult ValidationResult { get; set; }
        public EmailObjeto Email { get; private set; }
        public bool TrocarSenha { get; set; }
        public DateTime? UltimaTrocaDeSenha { get; set; }
        public int TrocarSenhaEmXDias { get; set; }
        public string EnderecoEmail { get; set; }
        public TokenAcessoRapido Token { get; set; }
        public int? DepartamentoId { get; set; }

        public Usuario()
        {
            ValidationResult = new ValidationResult();
        }

        public Usuario(string userId, string nome, string email, string criadoPor)
        {
            Id = userId;
            Nome = nome;
            CriadoEm = DateTime.Now;
            Ativo = true;
            DefinirEmail(email);
            CriadoPor = criadoPor;
            ValidationResult = new ValidationResult();
        }

        public void ValidarSenha(string senha)
        {
            if (this.ValidarSenhaUsuarioScopeEhValido(senha))
                return;
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Inativar(string userId)
        {
            Ativo = false;
            AlteradoPor = userId;
            AlteradoEm = DateTime.Now;
        }

        public void DefinirEmail(string email)
        {
            var myEmail = new EmailObjeto(email);

            if (this.DefinirEmailUsuarioScopeEhValido(myEmail))
                Email = myEmail;
        }

        public bool IsValid()
        {
            ValidationResult = new UsuarioEstaConsistenteValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }

        public void GerarTokenAcessoRapido()
        {
            Token = new TokenAcessoRapido(Id);
        }

        public const int SenhaMinLength = 6;
        public const int SenhaMaxLength = 30;
    }
}