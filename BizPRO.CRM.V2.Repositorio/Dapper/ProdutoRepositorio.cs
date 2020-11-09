using System.Collections.Generic;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Data;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(IDapperContexto context)
            : base(context)
        {
        }

        public IEnumerable<Produto> ObterProdutoAtivo(long? idProduto)
        {
            var p = new DynamicParameters();
            p.Add("@id", idProduto);

            var retorno = Conn.Query<Produto, ProdutoTipo, Produto>("usp_front_sel_produtos",
                (ret, proTp) =>
                {
                    ret.sProdutoTipo = proTp;
                    return ret;
                },
                p,
                splitOn: "Id,Id",
                commandType: CommandType.StoredProcedure);

            return retorno;
        }
    }
}
