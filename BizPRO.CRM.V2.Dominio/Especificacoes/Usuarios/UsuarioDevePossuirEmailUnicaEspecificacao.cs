using DomainValidation.Interfaces.Specification;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;

namespace BizPRO.CRM.V2.Dominio.Especificacoes.Usuarios
{
    public class UsuarioDevePossuirEmailUnicaEspecificacao : ISpecification<Usuario>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioDevePossuirEmailUnicaEspecificacao(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public bool IsSatisfiedBy(Usuario usuario)
        {
            return _usuarioRepositorio.ObterPorEmail(usuario.Email.Endereco) == null;
        }
    }
}
