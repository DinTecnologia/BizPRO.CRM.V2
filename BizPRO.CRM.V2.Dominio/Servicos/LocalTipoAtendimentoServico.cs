using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class LocalTipoAtendimentoServico : ILocalTipoAtendimentoServico
    {
        private readonly ILocalTipoAtendimentoRepositorio _repositorio;

        public LocalTipoAtendimentoServico(ILocalTipoAtendimentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<LocalTipoAtendimento> ObterLocalTiposAtendimentoPorLocalId(long localId)
        {
            return _repositorio.ObterLocalTiposAtendimentoPorLocalId(localId);
        }
    }
}
