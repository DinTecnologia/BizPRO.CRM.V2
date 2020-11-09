using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AspNetRolesFilaServico : Servico<AspNetRolesFila>, IAspNetRolesFilaServico
    {
        private readonly IAspNetRolesFilaRepositorio _repositorio;

        public AspNetRolesFilaServico(IAspNetRolesFilaRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<AspNetRolesFila> ObterPorFila(long id)
        {
            return _repositorio.ObterTodos().Where(c => c.FilasId == id);
        }

        public AspNetRolesFila InserirFilas(AspNetRolesFila aspNetRolesFila)
        {
            var dados = _repositorio.ObterTodos().Where(c => c.FilasId == aspNetRolesFila.FilasId && c.AspNetRolesId == aspNetRolesFila.AspNetRolesId);
            var _AspNetRolesFila = new AspNetRolesFila();
            if (dados.Count() < 1)
            {
                var _id = _repositorio.Adicionar(new AspNetRolesFila(aspNetRolesFila.FilasId, aspNetRolesFila.AspNetRolesId));

                if (_id != null)
                    _AspNetRolesFila = _repositorio.ObterPorId((long)_id);
            }
            else
                _AspNetRolesFila = dados.FirstOrDefault();

            return _AspNetRolesFila;
        }

        public void DeletaRolesFilas(long filaId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@filaID", filaId);
            var listaRetorno = _repositorio.ObterPorProcedimento("usp_front_del_DeletaRolesFilas", parametros);
        }
    }
}
