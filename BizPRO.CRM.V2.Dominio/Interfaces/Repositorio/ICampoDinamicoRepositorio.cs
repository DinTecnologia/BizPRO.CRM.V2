using BizPRO.CRM.V2.Dominio.Entidades;
using Dapper;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface ICampoDinamicoRepositorio : IRepositorio<CampoDinamico>
    {
        IEnumerable<CampoDinamico> ObterPor(string siglaEntidade, string nomeAba, string secao);
        IEnumerable<CampoDinamico> ObterCamposDinamicosPorEntidade(string procedimento, DynamicParameters parametros);
    }
}
