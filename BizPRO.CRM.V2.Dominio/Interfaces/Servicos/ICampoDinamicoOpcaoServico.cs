using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface ICampoDinamicoOpcaoServico
    {
        CampoDinamicoOpcao ObterPorId(long campoDinamicoId);
        IEnumerable<CampoDinamicoOpcao> ObterPor(long camposDinamicosId);

        IEnumerable<CampoDinamicoOpcao> ObterPor(string entidadeSigla, string abaSecao, string campoDinamicoTipo,
            string campoDinamicoNome);

        IEnumerable<CampoDinamicoOpcao> BuscaPor(int campoDinamicoId, string termo, int? quantidade = 100);
    }
}
