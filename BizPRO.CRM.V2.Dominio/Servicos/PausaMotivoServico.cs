using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class PausaMotivoServico : Servico<PausaMotivo>, IPausaMotivoServico
    {
        private readonly IPausaMotivoRepositorio _repositorio;

        public PausaMotivoServico(IPausaMotivoRepositorio repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<PausaMotivo> ObterPorCanalIds(string canalIds)
        {
            return _repositorio.ObterPorCanalIds(canalIds);
        }

      
    }
}
