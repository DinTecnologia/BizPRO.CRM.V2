using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using Dapper;
using System.Data;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class ProdutoTipoRepositorio : Repositorio<ProdutoTipo>, IProdutoTipoRepositorio
    {
        public ProdutoTipoRepositorio(IDapperContexto context)
            : base(context)
        {

        }

        public IEnumerable<ProdutoTipo> ObterProdutoTipoAtivo(long? idProdutoTipo)
        {
            var p = new DynamicParameters();
            p.Add("@id", idProdutoTipo);
            var retorno = Conn.Query<ProdutoTipo>("usp_front_sel_produtosTipo", p,
                commandType: CommandType.StoredProcedure);
            return retorno.ToList();
        }
    }
}
