using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AtividadeTipoServico : Servico<AtividadeTipo>, IAtividadeTipoServico
    {
        private readonly IAtividadeTipoRepositorio _repositorio;

        public AtividadeTipoServico(IAtividadeTipoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public AtividadeTipo BuscarPorNome(string nome)
        {
            return _repositorio.BuscarPorNome(nome);
        }
    }
}
