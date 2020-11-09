using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class TextoCategoriaServico : Servico<TextoCategoria>, ITextoCategoriaServico
    {
        private ITextoCategoriaRepositorio _repositorio;

        public TextoCategoriaServico(ITextoCategoriaRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<TextoCategoria> ObterPorFilaId(int? filaId)
        {
            return _repositorio.ObterPorFilaId(filaId);
        }
    }
}
