using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IContratoAppServico
    {
        IEnumerable<ContratoListaViewModel> ListarContratos();
        ContratoViewModel ObterPorId(long contratoId);

        IEnumerable<ContratoListaViewModel> ObterContratosPorCliente(long? pessoaFisicaId, long? pessoaJuridicaId,
            long? atendimentoId);

        ContratoFormViewModel NovoContrato(long? pessoaFisicaId, long? pessoaJuridicaId);
        ValidationResult Adicionar(ContratoFormViewModel model, string usuarioId);
        IEnumerable<Produto> ObterProdutos(long produtoTipoId);
    }
}
