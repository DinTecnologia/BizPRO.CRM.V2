using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Contexto.Interfaces;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class MenuRepositorio : Repositorio<Menu>, IMenuRepositorio
    {
        public MenuRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<Menu> ObterMenu(string userId, string url)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@userID", userId);

            if (!string.IsNullOrEmpty(url))
                parametros.Add("@url", url);

            return ObterPorProcedimento("usp_front_sel_Menu", parametros);
        }
    }
}
