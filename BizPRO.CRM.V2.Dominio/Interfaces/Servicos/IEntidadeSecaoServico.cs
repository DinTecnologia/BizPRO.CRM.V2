using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IEntidadeSecaoServico
    {
        EntidadeSecao ObterPor(string siglaEntidade, string nomeAba, string nomeSecao);
    }
}
