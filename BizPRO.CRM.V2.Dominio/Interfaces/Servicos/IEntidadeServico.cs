using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IEntidadeServico
    {
        string ObterScriptEntidade(string nomeLogico);
        Entidade ObterPorNomeLogico(string nomeLogico);
        Entidade ObterPorId(long id);

    }
}
