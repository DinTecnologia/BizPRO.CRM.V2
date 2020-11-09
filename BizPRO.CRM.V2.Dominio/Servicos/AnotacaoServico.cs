using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AnotacaoServico : Servico<Anotacao>, IAnotacaoServico
    {
        private readonly IAnotacaoRepositorio _repositorio;

        public AnotacaoServico(IAnotacaoRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public Anotacao AdicionarAnotacao(Anotacao anotacao)
        {
            return _repositorio.Adicionar(anotacao);
        }
        public IEnumerable<Anotacao> ObterPorOcorrenciaId(long id)
        {
            return _repositorio.ObterPorOcorrenciaId(id);
        }
        public IEnumerable<Anotacao> ObterPor(long? ocorrenciaId, long? atividadeId, long? pessoaFisicaId, long? pessoaJuridicaId)
        {
            return _repositorio.ObterPor(ocorrenciaId, atividadeId, pessoaFisicaId, pessoaJuridicaId);
        }
        public IEnumerable<Anotacao> ObterPorTarefaId(long id)
        {
            return _repositorio.ObterPorTarefaId(id);
        }
    }
}
