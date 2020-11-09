using BizPRO.CRM.V2.Aplicacao.ViewModels;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IClienteAppServico
    {
        ClienteBuscaViewModel PesquisarCliente(ClienteBuscaViewModel clienteBuscaViewModel);

        ClientePerfilViewModel Carregar(long? pessoaFisicaId, long? pessoaJuridicaId, bool trocarCliente);

        ClienteBuscaViewModel AtualizarClienteAtividade(long atividadeId, long novoClienteId, string novoClienteTipo,
            string userId, bool clienteSomenteContato, long? atualClienteId, string atualClienteTipo,
            long? clienteTipoContato);

        IEnumerable<ClienteListaViewModel> ObterSugestoes(string nome, string documento, string telefone, string email,
            string informacaoUra, string criadoPor, bool registroComTodosCamposFornecidos = true);

        ClienteBuscaViewModel PesquisarGenerico(long? atividadeId, bool? carregarComPost, string nomeAction,
            string nomeController, long? atualClienteId, string atualClienteTipo, bool? clienteContato, string criadoPor);

        ClienteNovoViewModel NovoGenerico(long? atividadeId, bool? carregarComPost, string nomeAction,
            string nomeController, long? atualClienteId, string atualClienteTipo, bool? clienteContato);

        bool AbrirOcorrenciaIframe();

        bool DocumentoPossuiCadastro(string documento, string tipoCliente);
    }
}
