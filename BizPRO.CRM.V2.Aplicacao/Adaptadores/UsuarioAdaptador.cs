using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Identity.Model;

namespace BizPRO.CRM.V2.Aplicacao.Adaptadores
{
    public class UsuarioAdaptador
    {
        public static Usuario ToDominioModelo(string userid, UsuarioItemViewModel register, string criadoPor)
        {
            var usuario = new Usuario(
                userid,
                register.Nome,
                register.Email,
                criadoPor);

            return usuario;
        }
    }
}
