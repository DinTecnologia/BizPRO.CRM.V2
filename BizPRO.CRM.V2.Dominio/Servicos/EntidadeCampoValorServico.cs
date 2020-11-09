using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class EntidadeCampoValorServico : IEntidadeCampoValorServico
    {
        private readonly IEntidadeCampoValorRepositorio _repositorio;

        public EntidadeCampoValorServico(IEntidadeCampoValorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<EntidadeCampoValor> ObterPor(string nomeLogicoEntidade, string nomeCampo, bool? ativo, bool? valorPadrao)
        {
            return _repositorio.ObterPor(nomeLogicoEntidade, nomeCampo, ativo, valorPadrao);
        }
    }
}
