using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IEntidadeSecaoRepositorio : IRepositorio<EntidadeSecao>
    {
        EntidadeSecao ObterPor(string siglaEntidade, string nomeAba, string nomeSecao);
    }
}
