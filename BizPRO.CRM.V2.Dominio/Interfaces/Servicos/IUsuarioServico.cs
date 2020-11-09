using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;


namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IUsuarioServico : IDisposable
    {
        Usuario Adicionar(Usuario usuario);
        Usuario ObterPorId(long id);
        Usuario ObterPorEmail(string email);
        IEnumerable<Usuario> ObterTodos();
        Usuario Atualizar(Usuario usuario);
        void Deletar(long id);
        Usuario ObterPorUserId(string userId);
        IEnumerable<Usuario> CarregarUsuariosVendas();
        IEnumerable<Usuario> CarregarUsuariosLigacoes();
        bool ObterPermissaoUsuario(string userId);
        bool VerificaTrocaSenha(string userId);
        Usuario TrocarSenha(bool trocarSenha, string userId);
        IEnumerable<Usuario> ObterUsuariosOcorrencia();
        bool GerarTokenAcessoRapido(Usuario entidade);
        IEnumerable<Usuario> BuscarPorNome(string nome);
        IEnumerable<Usuario> ObterUsuariosContatos();
        IEnumerable<Usuario> ObterUsuariosAtividades();
        IEnumerable<Usuario> ObterCriadoresAtividades();
        IEnumerable<Usuario> ObterResponsaveisAtividades();
        IEnumerable<Usuario> ObterResponsaveisAtribuicao(long? ocorrenciaId, long? atividadeId);
        Usuario ObterResponsavel(long? ocorrenciaId, long? atividadeId);
    }
}
