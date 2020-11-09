using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ServicoServico : IServicoServico
    {
        private readonly IServicoRepositorio _repositorio;

        public ServicoServico(IServicoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
