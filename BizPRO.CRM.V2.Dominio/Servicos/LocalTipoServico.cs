using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class LocalTipoServico : ILocalTipoServico
    {
        private readonly ILocalTipoRepositorio _repositorio;

        public LocalTipoServico(ILocalTipoRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }
        public Entidades.LocalTipo ObterPorId(long id)
        {
            return _repositorio.ObterPorId(id);
        }
    }
}
