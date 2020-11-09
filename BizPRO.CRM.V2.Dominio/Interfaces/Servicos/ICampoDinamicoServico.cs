using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface ICampoDinamicoServico
    {
        IEnumerable<CampoDinamico> ObterPor(long? chaveEntidadeId, string siglaEntidade, string aba, string secao);
        IEnumerable<CampoDinamico> ObterCamposDinamicosPorEntidade(string siglaEntidade);
    }
}
