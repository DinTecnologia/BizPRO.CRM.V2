using BizPRO.CRM.V2.Dominio.Entidades;
using Dapper;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IPessoaJuridicaContatoRepositorio : IRepositorio<PessoaJuridicaContato>
    {
        IEnumerable<PessoaJuridicaContato> ObterEntidadeCompletaPorProcedimento(string procedimento,
            DynamicParameters parametros);
    }
}
