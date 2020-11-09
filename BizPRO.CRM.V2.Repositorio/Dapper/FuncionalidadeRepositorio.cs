using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Linq;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class FuncionalidadeRepositorio : Repositorio<Funcionalidade>, IFuncionalidadeRepositorio
    {
        public FuncionalidadeRepositorio(IDapperContexto context)
            : base(context)
        {
        }

        public Funcionalidade ObterTelaInicial(string usuarioId)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@usuarioId", usuarioId);
            return ObterPorProcedimento("usp_front_sel_FuncionalidadeInicialPorUsuarioId", parametros).FirstOrDefault();
        }
    }
}
