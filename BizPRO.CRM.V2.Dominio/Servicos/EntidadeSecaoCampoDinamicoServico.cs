using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class EntidadeSecaoCampoDinamicoServico : IEntidadeSecaoCampoDinamicoServico
    {
        private readonly IEntidadeSecaoCampoDinamicoRepositorio _repositorio;

        public EntidadeSecaoCampoDinamicoServico(IEntidadeSecaoCampoDinamicoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
