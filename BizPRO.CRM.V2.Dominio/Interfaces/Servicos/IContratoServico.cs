using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IContratoServico : IServico<Contrato>
    {
        IEnumerable<Contrato> ObterContratosNovaOcorrencia(long? pessoaFisicaId, long? pessoaJuridicaId);

        IEnumerable<Contrato> ObterContratosPorCliente(long? pessoaFisicaId, long? pessoaJuridicaId, int? quantidade = 5);

        Contrato AdicionarNovoContrato(string criadoPorUserId, string numeroContrato, decimal? valorContrato,
            decimal? valorDesconto, long? pessoaFisicaId, long? pessoaJuridicaId, DateTime? dataInicio,
            DateTime? dataTerminco, string tipoContrato, long? contratoPaiId, long? statusEntidadeId, string apelido,
            DateTime? dataEncerramento, IEnumerable<ContratoProduto> contratoProdutos);

        Contrato ObterContratoDetalhe(long contratoId);
    }
}
