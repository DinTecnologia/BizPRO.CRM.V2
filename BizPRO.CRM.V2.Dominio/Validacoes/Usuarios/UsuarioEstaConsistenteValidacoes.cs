using DomainValidation.Validation;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Especificacoes.Usuarios;

namespace BizPRO.CRM.V2.Dominio.Validacoes.Usuarios
{
    public class UsuarioEstaConsistenteValidacoes : Validator<Usuario>
    {
        public UsuarioEstaConsistenteValidacoes()
        {
            var usuarioEmail = new UsuarioDeveTerEmailValidoEspecificacao();
            base.Add("clienteEmail", new Rule<Usuario>(usuarioEmail, "Usuario informou um e-mail inválido."));
        }
    }
}
