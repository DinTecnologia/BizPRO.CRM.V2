using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class LocalServicoServico : ILocalServicoServico
    {
        private readonly ILocalServicoServico _repositorio;

        public LocalServicoServico(ILocalServicoServico repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
