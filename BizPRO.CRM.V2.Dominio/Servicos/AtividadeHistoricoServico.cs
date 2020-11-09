using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AtividadeHistoricoServico:Servico<AtividadesHistorico>,IAtividadeHistoricoServico
    {
        private IAtividadeHistoricoRepositorio _repositorio;

        public AtividadeHistoricoServico(IAtividadeHistoricoRepositorio repositorio)
            :base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
