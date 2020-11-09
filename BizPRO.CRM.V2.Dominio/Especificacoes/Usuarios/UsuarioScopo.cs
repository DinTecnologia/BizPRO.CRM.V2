using BizPRO.CRM.V2.Core.ValueObjects;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Especificacoes.Usuarios
{
    public static class UsuarioScopo
    {
        public static bool DefinirSenhaDistribuidorScopeEhValido(this Usuario usuario, string password,
            string confirmPassword)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(password, "A senha é obrigatória"),
                AssertionConcern.AssertNotNullOrEmpty(confirmPassword, "A confirmação de senha é obrigatória"),
                AssertionConcern.AssertAreEquals(password, confirmPassword, "As senhas são iguais")
            );
        }

        public static bool ValidarSenhaUsuarioScopeEhValido(this Usuario usuario, string password)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(password, "A senha é obrigatória"),
                AssertionConcern.AssertLength(password, Usuario.SenhaMinLength, Usuario.SenhaMaxLength,
                    "O tamanho da senha não corresponde")
            );
        }

        public static bool DefinirEmailUsuarioScopeEhValido(this Usuario usuario, EmailObjeto email)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertLength(email.Endereco, EmailObjeto.EnderecoMinLength,
                    EmailObjeto.EnderecoMaxLength, "E-mail em tamanho incorreto"),
                AssertionConcern.AssertNotNullOrEmpty(email.Endereco, "O e-mail obrigatória"),
                AssertionConcern.AssertTrue(EmailObjeto.IsValid(email.Endereco), "E-mail em formato inválido")
            );
        }

        public static bool DefinircpfUsuarioScopeEhValido(this Usuario usuario, CpfObjeto cpf)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertFixedLength(cpf.Codigo, CpfObjeto.ValorMaxCpf, "cpf em tamanho incorreto"),
                AssertionConcern.AssertNotNullOrEmpty(cpf.Codigo, "O cpf é obrigatória"),
                AssertionConcern.AssertTrue(CpfObjeto.Validar(cpf.Codigo), "cpf em formato inválido")
            );
        }
    }
}