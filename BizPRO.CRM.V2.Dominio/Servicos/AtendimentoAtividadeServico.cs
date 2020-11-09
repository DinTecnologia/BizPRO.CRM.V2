using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AtendimentoAtividadeServico : Servico<AtendimentoAtividade>, IAtendimentoAtividadeServico
    {
        private readonly IAtendimentoAtividadeRepositorio _repositorio;

        public AtendimentoAtividadeServico(IAtendimentoAtividadeRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
