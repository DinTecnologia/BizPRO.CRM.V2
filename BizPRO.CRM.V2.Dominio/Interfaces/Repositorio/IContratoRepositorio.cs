using BizPRO.CRM.V2.Dominio.Entidades;
using Dapper;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IContratoRepositorio : IRepositorio<Contrato>
    {
        IEnumerable<Contrato> ObterContratosPorCliente(string procedimento, DynamicParameters parametros);
        Contrato ObterContratoDetalhe(long contratoId);
    }
}
