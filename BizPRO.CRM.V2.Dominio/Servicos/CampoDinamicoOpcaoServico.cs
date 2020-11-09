using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class CampoDinamicoOpcaoServico : ICampoDinamicoOpcaoServico
    {
        private readonly ICampoDinamicoOpcaoRepositorio _repositorio;

        public CampoDinamicoOpcaoServico(ICampoDinamicoOpcaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<CampoDinamicoOpcao> ObterPor(long camposDinamicosId)
        {
            return _repositorio.ObterPor(camposDinamicosId);
        }

        public IEnumerable<CampoDinamicoOpcao> ObterPor(string entidadeSigla, string abaSecao, string campoDinamicoTipo,
            string campoDinamicoNome)
        {
            return _repositorio.ObterPor(entidadeSigla, abaSecao, campoDinamicoTipo, campoDinamicoNome);
        }

        public CampoDinamicoOpcao ObterPorId(long campoDinamicoId)
        {
            return _repositorio.ObterPorId(campoDinamicoId);
        }

        public IEnumerable<CampoDinamicoOpcao> BuscaPor(int campoDinamicoId, string termo,
            int? quantidade = 100)
        {
            return _repositorio.BuscarPor(campoDinamicoId, termo, quantidade);
        }
    }
}
