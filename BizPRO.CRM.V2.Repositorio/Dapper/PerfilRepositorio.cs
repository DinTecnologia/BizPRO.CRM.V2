using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class PerfilRepositorio : Repositorio<Perfil>, IPerfilRepositorio
    {
        public PerfilRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Perfil> ObterPerfis(string usuarioId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@UsuarioId", usuarioId);
            return ObterPorProcedimento("usp_front_sel_UsuarioPerfis", parametros);
        }
    }
}
