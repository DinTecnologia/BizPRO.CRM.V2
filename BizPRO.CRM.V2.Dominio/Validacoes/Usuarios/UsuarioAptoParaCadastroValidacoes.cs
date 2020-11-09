using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Especificacoes.Usuarios;

namespace BizPRO.CRM.V2.Dominio.Validacoes.Usuarios
{
    public class UsuarioAptoParaCadastroValidacoes : Validator<Usuario>
    {
        public UsuarioAptoParaCadastroValidacoes(IUsuarioRepositorio usuarioRepositorio)
        {
            var emailDuplicado = new UsuarioDevePossuirEmailUnicaEspecificacao(usuarioRepositorio);
            base.Add("emailDuplicado", new Rule<Usuario>(emailDuplicado, "E-mail já cadastrado! Esqueceu sua senha?"));
        }
    }
}
