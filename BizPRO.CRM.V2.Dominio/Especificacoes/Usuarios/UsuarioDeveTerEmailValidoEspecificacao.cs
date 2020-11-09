using BizPRO.CRM.V2.Core.ValueObjects;
using DomainValidation.Interfaces.Specification;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Especificacoes.Usuarios
{
    public class UsuarioDeveTerEmailValidoEspecificacao : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return EmailObjeto.IsValid(usuario.Email.Endereco);
        }
    }
}