using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class AtendimentoServico : Servico<Atendimento>, IAtendimentoServico
    {
        private readonly IAtendimentoRepositorio _repositorio;
        private readonly IEntidadeCampoValorServico _servicoEntidadeCamporValor;

        public AtendimentoServico(IAtendimentoRepositorio repositorio,
            IEntidadeCampoValorServico servicoEntidadeCamporValor)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _servicoEntidadeCamporValor = servicoEntidadeCamporValor;
        }

        public string GerarNumeroProtocolo(DateTime? data)
        {
            return _repositorio.GerarNumeroProtocolo(data);
        }

        public IEnumerable<Atendimento> ObterAtendimentosPorCliente(long? pessoaFisicaId, long? pessoaJuridicaId,
            int? quantidade)
        {
            if (pessoaFisicaId == null && pessoaJuridicaId == null)
                return null;

            return _repositorio.BuscarPorCliente(pessoaFisicaId, pessoaJuridicaId, quantidade);
        }

        public Atendimento InserirAtendimento(Atendimento entidade)
        {
            return _repositorio.AdicionarAtendimento(entidade);
        }

        public Atendimento BuscarPorProtocolo(string protocolo)
        {
            return _repositorio.BuscarPorProtocolo(protocolo);
        }

        public Atendimento AdicionarNovoAtendimento(int? canalId, string criadoPorId, long? midiaId)
        {
            /// Retirado em 17/01/2019, com objetivo de ganhar performance e evitar protocolo duplicado nas operações - Thiago H. din
            //var atendimento = new Atendimento(criadoPorId, _repositorio.GerarNumeroProtocolo(DateTime.Now), canalId, midiaId);

            var atendimento = new Atendimento
            {
                CriadoPorUserId = criadoPorId,
                CanalOrigemId = canalId,
                MidiasId = midiaId
            };

            atendimento = _repositorio.AdicionarAtendimentoCompleto(atendimento);

            //if (atendimento.IsValid())
            //    _repositorio.AdicionarAtendimentoCompleto(atendimento);
            //else
            //    atendimento.ValidationResult.Add(new ValidationError("Número de protocolo inválido."));

            return atendimento;
        }

        public bool AtualizarClienteSomenteContato(long atendimentoId, bool clienteSomenteContato,
            long? tipoClienteContatoId)
        {
            var atendimento = _repositorio.ObterPorId(atendimentoId);
            if (atendimento == null) return true;

            atendimento.ClienteSomenteContato = clienteSomenteContato;
            atendimento.TipoClienteContatoEntidadesCamposValoresId = tipoClienteContatoId;
            _repositorio.Atualizar(atendimento);

            return true;
        }

        public IEnumerable<EntidadeCampoValor> ObterTiposClienteContato()
        {
            return _servicoEntidadeCamporValor.ObterPor("Atendimento", "tipoClienteContatoEntidadesCamposValoresId",
                true, null);
        }

        public void AtualizarMidia(long atendimentoId, int midiaId)
        {
            var atendimento = _repositorio.ObterPorId(atendimentoId);
            if (atendimento == null) return;

            atendimento.MidiasId = midiaId;
            _repositorio.Atualizar(atendimento);
        }      
    }
}

