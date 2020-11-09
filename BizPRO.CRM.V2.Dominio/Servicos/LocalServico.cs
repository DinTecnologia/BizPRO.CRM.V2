using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class LocalServico : ILocalServico
    {
        private readonly ILocalRepositorio _repositorio;

        public LocalServico(ILocalRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Local> Pesquisar(string segmento)
        {
            return _repositorio.Pesquisar(segmento);
        }

        public IEnumerable<Local> Pesquisar(string segmento, double latitude, double longitude)
        {
            return _repositorio.Pesquisar(segmento, latitude, longitude);
        }

        public Local ObterPorId(long localId)
        {
            return _repositorio.ObterPorId(localId);
        }

        public Local ObterLocalPorOcorrenciaId(long ocorrenciaId)
        {
            return _repositorio.ObterLocalPorOcorrenciaId(ocorrenciaId);
        }
    }
}