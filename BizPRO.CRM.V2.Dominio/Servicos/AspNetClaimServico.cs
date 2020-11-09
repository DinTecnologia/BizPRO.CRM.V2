using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AspNetClaimServico : IAspNetClaimServico
    {
        private readonly IAspNetClaimRepositorio _repositorio;

        public AspNetClaimServico(IAspNetClaimRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<AspNetClaim> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }
        public IEnumerable<AspNetClaim> ObterTodosProc()
        {
            return _repositorio.ObterTodosProc();
        }
    }
}
