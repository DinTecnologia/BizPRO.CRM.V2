using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class EntidadeServico : IEntidadeServico
    {
        private readonly IEntidadeRepositorio _repositorio;

        public EntidadeServico(IEntidadeRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public string ObterScriptEntidade(string nomeLogico)
        {
            var retorno = "";
            var entidade = _repositorio.ObterEntidadePorNomeLogico(nomeLogico);

            if (entidade != null)
                retorno = entidade.ScriptOnPage;

            return retorno;
        }

        public Entidade ObterPorNomeLogico(string nomeLogico)
        {
            return _repositorio.ObterPorNomeLogico(nomeLogico);
        }

        public Entidade ObterPorId(long id)
        {
            return _repositorio.ObterPorId(id);
        }
    }
}
