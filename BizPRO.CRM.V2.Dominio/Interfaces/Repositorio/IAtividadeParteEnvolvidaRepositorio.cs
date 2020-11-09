using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IAtividadeParteEnvolvidaRepositorio : IRepositorio<AtividadeParteEnvolvida>
    {
        IEnumerable<AtividadeParteEnvolvida> ObterPorAtividadeId(long atividadeId);
        IEnumerable<AtividadeParteEnvolvida> BuscarPor(long atividadeId, string tipoParteEnvolvida);
        IEnumerable<AtividadeParteEnvolvida> BuscarPor(long atividadeId, long? pessoaFisicaId, long? pessoaJuridicaId);
    }
}
