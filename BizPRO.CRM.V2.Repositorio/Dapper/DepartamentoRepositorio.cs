using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class DepartamentoRepositorio : Repositorio<Departamento>, IDepartamentoRepositorio
    {
        public DepartamentoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Departamento> ObterDepartamentos()
        {
            return ObterTodos();
        }

        public Departamento ObterPorId(int id)
        {
            return ObterPorId(Convert.ToInt64(id));
        }

        public IEnumerable<Departamento> ObterPorUsuario(string usuarioId)
        {
            var parametros = new DynamicParameters();

            if (!string.IsNullOrEmpty(usuarioId))
                parametros.Add("@usuarioId", usuarioId);

            return ObterPorProcedimento("usp_front_sel_FilaPorUsuario", parametros);
        }

        public IEnumerable<Departamento> ObterDepartamentoPorUser(string usuarioId)
        {
            var parametros = new DynamicParameters();

            if (!string.IsNullOrEmpty(usuarioId))
                parametros.Add("@usuarioId", usuarioId);

            return ObterPorProcedimento("usp_front_sel_DepartamentoPorUsuario", parametros);
        }
    }
}
