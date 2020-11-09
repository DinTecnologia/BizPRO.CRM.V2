using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AspNetRolesMenuServico : Servico<AspNetRolesMenu>, IAspNetRolesMenuServico
    {
        private readonly IAspNetRolesMenuRepositorio _repositorio;

        public AspNetRolesMenuServico(IAspNetRolesMenuRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<AspNetRolesMenu> BuscarPorMenuId(int id)
        {
            return _repositorio.BuscarPorMenuId(id);
        }
    }
}
