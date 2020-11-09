using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Servicos
{

    public class EnderecoServico : IEnderecoServico
    {
        private readonly IEnderecoRepositorio _repositorio;

        public EnderecoServico(IEnderecoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Endereco> ObterEnderecosProduto(long? ocorrenciaId, long? pessoaFisicaId,
            long? pessoaJuridicaId)
        {
            return _repositorio.ObterEnderecosProduto(ocorrenciaId, pessoaFisicaId, pessoaJuridicaId);
        }
    }
}
