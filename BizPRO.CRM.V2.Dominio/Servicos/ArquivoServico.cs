using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ArquivoServico : Servico<Arquivo>, IArquivoServico
    {
        private readonly IArquivoRepositorio _repositorio;

        public ArquivoServico(IArquivoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Arquivo> ObterPor(long chaveEntidadeId, long entidadeId)
        {
            return _repositorio.ObterPor(chaveEntidadeId, entidadeId);
        }
    }
}
