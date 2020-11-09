using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class PerfilServico : Servico<Perfil>, IPerfilServico
    {
        private readonly IPerfilRepositorio _repositorio;

        public PerfilServico(IPerfilRepositorio repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public System.Collections.Generic.IEnumerable<Perfil> ObterPerfis(string usuarioId)
        {
            return _repositorio.ObterPerfis(usuarioId);
        }
    }
}
