using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface ICampoDinamicoOpcaoRepositorio : IRepositorio<CampoDinamicoOpcao>
    {
        IEnumerable<CampoDinamicoOpcao> ObterPor(long camposDinamicosId);

        IEnumerable<CampoDinamicoOpcao> ObterPor(string entidadeSigla, string abaSecao, string campoDinamicoTipo,
            string campoDinamicoNome);

        IEnumerable<CampoDinamicoOpcao> BuscarPor(int campoDinamicoId, string termo, int? quantidade = 100);
    }
}
