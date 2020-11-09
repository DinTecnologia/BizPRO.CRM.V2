using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class TextoFilaServico : Servico<TextoFila>, ITextoFilaServico
    {
        private readonly ITextoFilaRepositorio _repositorio;

        public TextoFilaServico(ITextoFilaRepositorio repositorio) : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public void DeletarTodosAtivo(long textoId, string usuarioId)
        {
            _repositorio.DeletarTodosAtivo(textoId, usuarioId);
        }        

        public IEnumerable<TextoFila> ObterPorTextoId(long id)
        {
            return _repositorio.ObterPorTextoId(id);
        }
    }
}
