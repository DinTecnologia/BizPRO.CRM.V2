using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using Dapper;
using DomainValidation.Validation;
using System.Linq;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class ContratoServico : Servico<Contrato>, IContratoServico
    {
        private readonly IContratoRepositorio _repositorio;
        private readonly IStatusEntidadeServico _servicoStatusEntidade;
        private readonly IContratoProdutoServico _servicoContratoProduto;

        public ContratoServico(IContratoRepositorio repositorio, IStatusEntidadeServico servicoStatusEntidade,
            IContratoProdutoServico servicoContratoProduto)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _servicoStatusEntidade = servicoStatusEntidade;
            _servicoContratoProduto = servicoContratoProduto;
        }

        public IEnumerable<Contrato> ObterContratosNovaOcorrencia(long? pessoaFisicaId, long? pessoaJuridicaId)
        {
            if (pessoaFisicaId == null && pessoaJuridicaId == null)
                return new List<Contrato>();

            var parametros = new DynamicParameters();
            parametros.Add("@pessoaFisicaID", pessoaFisicaId);
            parametros.Add("@pessoaJuridicaID", pessoaJuridicaId);

            return
                _repositorio.ObterPorProcedimento("usp_front_sel_contratosNovaOcorrencia", parametros)
                    .OrderByDescending(c => c.DataInicio);
        }

        public IEnumerable<Contrato> ObterContratosPorCliente(long? pessoaFisicaId, long? pessoaJuridicaId,
            int? quantidade)
        {
            if (pessoaFisicaId == null && pessoaJuridicaId == null)
                return null;

            var parametros = new DynamicParameters();
            parametros.Add("@pessoaFisicaID", pessoaFisicaId ?? (long?) null);
            parametros.Add("@pessoaJuridicaID", pessoaJuridicaId ?? (long?) null);
            parametros.Add("@quantidade", quantidade ?? (long?) null);
            var contratos = _repositorio.ObterContratosPorCliente("usp_front_sel_contratosPorCliente", parametros);
            return contratos.OrderByDescending(c => c.DataInicio);
        }

        public Contrato AdicionarNovoContrato(string criadoPorUserId, string numeroContrato, decimal? valorContrato,
            decimal? valorDesconto, long? pessoaFisicaId, long? pessoaJuridicaId, DateTime? dataInicio,
            DateTime? dataTerminco, string tipoContrato, long? contratoPaiId, long? statusEntidadeId, string apelido,
            DateTime? dataEncerramento, IEnumerable<ContratoProduto> contratoProdutos)
        {
            var retorno = new Contrato();

            if (!statusEntidadeId.HasValue)
            {
                var statusEntidade = _servicoStatusEntidade.ObterStatusEntidadeNovoContrato();

                if (statusEntidade == null)
                {
                    retorno.ValidationResult.Add(
                        new ValidationError("Status Entidade padrão novo Contrato não cadastrado no CRM"));
                    return retorno;
                }

                statusEntidadeId = statusEntidade.id;
            }

            retorno = new Contrato(criadoPorUserId, numeroContrato, valorContrato, valorDesconto, pessoaFisicaId,
                pessoaJuridicaId, dataInicio, dataTerminco, tipoContrato, contratoPaiId, (long) statusEntidadeId,
                apelido, dataEncerramento);
            _repositorio.Adicionar(retorno);

            if (!retorno.ValidationResult.IsValid) return retorno;

            if (contratoProdutos == null) return retorno;

            foreach (var contratoProduto in contratoProdutos)
            {
                contratoProduto.ContratoId = retorno.Id;
                _servicoContratoProduto.Adicionar(contratoProduto);
            }

            return retorno;
        }
        
        public Contrato ObterContratoDetalhe(long contratoId)
        {
            return _repositorio.ObterContratoDetalhe(contratoId);
        }
    }
}
