using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class LocaisLocalTipoAtendimentoServico : ILocaisLocalTipoAtendimentoServico
    {
        private readonly ILocaisLocalTipoAtendimentoRepositorio _repositorio;

        public LocaisLocalTipoAtendimentoServico(ILocaisLocalTipoAtendimentoRepositorio repositorio)
        {
            this._repositorio = repositorio;
        }
    }
}
