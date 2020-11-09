using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class TextoServico : Servico<Texto>, ITextoServico
    {
        private readonly ITextoRepositorio _repositorio;

        public TextoServico(ITextoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Texto> FiltrarPor(int? filaId, int? canalId, int? tipoId, int? formatoId)
        {
            return _repositorio.FiltrarTexto(filaId, canalId, tipoId, formatoId);            
        }

        public IEnumerable<Texto> ObterPorFilaId(int? filaId)
        {
            return _repositorio.ObterPorFilaId(filaId);
        }
    }
}
