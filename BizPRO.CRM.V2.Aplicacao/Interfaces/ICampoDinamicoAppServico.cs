using System.Collections.Generic;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface ICampoDinamicoAppServico
    {
        CampoDinamicoBuscaViewModel ObterOcorrenciaOriginal(CampoDinamicoBuscaViewModel model);
        string ObterNomeOcorrenciaOriginal(long ocorrenciaId);
        IEnumerable<CampoDinamicoOpcao> ObterOpcoes(int campoDinamicoId, long? id, string termo, int? quantidade);
    }
}
