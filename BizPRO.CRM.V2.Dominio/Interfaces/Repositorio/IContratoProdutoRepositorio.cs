using BizPRO.CRM.V2.Dominio.Entidades;
using Dapper;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IContratoProdutoRepositorio : IRepositorio<ContratoProduto>
    {
        IEnumerable<ContratoProduto> ListarContratoProduto(string procedimento, DynamicParameters parametros);
    }
}
