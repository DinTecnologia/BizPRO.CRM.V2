using System;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IIntegracaoAppServico
    {
        bool ConsultarIntegracao();

        ClienteIntegracaoViewModel AdicionarClienteIntegracao(string documento, long identificadorIntegracao,
            string criadoPor);

        ClienteIntegracaoBusca ObterClientesIntegracaoPor(string nome, string telefone, string documento,
            long? identificador, string criadoPor);

        PessoaFisicaFormViewModel CarregarAbaClienteIntegracaoPf(string documento, long clienteId, string criadoPor);

        PessoaJuridicaFormViewModel CarregarAbaClienteIntegracaoPj(string documento, long clienteId, string criadoPor);

        ClienteIntegracaoViewModel SincronizarClienteIntegracao(long? pessoaFisicaId, long? pessoaJuridicaId,
            string criadoPor);

        DateTime? ObterDataUltimaIntegracao(long? pessoaFisicaId, long? pessoaJuridicaId, long? contratoId);
    }
}
