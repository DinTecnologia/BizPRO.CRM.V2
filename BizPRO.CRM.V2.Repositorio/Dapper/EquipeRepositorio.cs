using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Linq;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class EquipeRepositorio : Repositorio<Equipe>, IEquipeRepositorio
    {
        public EquipeRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Equipe> ObterEquipes()
        {
            return ObterTodos();
        }

        public IEnumerable<Equipe> ObterPorDepartamentoId(int DepartamentoId)
        {
            return ObterTodos().Where(x => x.DepartamentoId == DepartamentoId);
        }

        
        public Equipe ObterPorId(int id)
        {
            return ObterPorId(Convert.ToInt64(id));
        }

        public IEnumerable<Equipe> ObterPorUsuario(string usuarioId)
        {
            var parametros = new DynamicParameters();

            if (!string.IsNullOrEmpty(usuarioId))
                parametros.Add("@usuarioId", usuarioId);

            return ObterPorProcedimento("usp_front_sel_EquipePorUsuario", parametros);
        }
    }
}
