using System.Collections.Generic;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Camadas.Infra.Repositorio.Dapper.Comum;
using System.Data;
using Dapper;

namespace BizPRO.CRM.V2.Repositorio.Dapper
{
    public class ContratoProdutoRepositorio : Repositorio<ContratoProduto>, IContratoProdutoRepositorio
    {
        public ContratoProdutoRepositorio(IDapperContexto context)
            : base(context)
        {
        }

        public IEnumerable<ContratoProduto> ListarContratoProduto(string procedimento, DynamicParameters parametros)
        {
            var retorno = Conn.Query<ContratoProduto, Contrato, Produto, ContratoProduto>(procedimento,
                (ret, cont, pro) =>
                {
                    ret.Contrato = cont;
                    ret.Produto = pro;
                    return ret;
                },
                parametros,
                splitOn: "Id",
                commandType: CommandType.StoredProcedure);

            return retorno;
        }
    }
}
