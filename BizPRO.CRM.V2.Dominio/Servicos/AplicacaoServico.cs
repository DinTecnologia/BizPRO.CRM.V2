
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AplicacaoServico : IAplicacaoServico
    {
        private readonly IAplicacaoRepositorio _repositorio;

        public AplicacaoServico(IAplicacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public bool Redirecionar(string host, string protocolo)
        {
            IEnumerable<Dominio.Entidades.Aplicacao> aplicacoes = _repositorio.BuscarAplicacao(host);
            //var aplicacoes = _repositorio.BuscarAplicacao(host);
            var ssl = protocolo.ToLower().Trim() == "https";

            if (!aplicacoes.Any()) return false;

            return !aplicacoes.Where(w => w.Ssl == ssl).ToList().Any();
        }

        public Dominio.Entidades.Aplicacao ObterAplicacao(string nome)
        {
            IEnumerable<Dominio.Entidades.Aplicacao> aplicacoes = _repositorio.ObterAplicacao(nome);
            return aplicacoes.Any() ? aplicacoes.FirstOrDefault() : null;
        }
    }
}
