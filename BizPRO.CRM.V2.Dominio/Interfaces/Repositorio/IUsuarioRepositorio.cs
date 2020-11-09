using BizPRO.CRM.V2.Dominio.Entidades;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IUsuarioRepositorio : IRepositorioEntity<Usuario>
    {
        Usuario ObterPorEmail(string email);
        Usuario ObterPorUserId(string userId);
        IEnumerable<Usuario> ObterUsuariosVenda();
        IEnumerable<Usuario> ObterUsuariosPorLigacao();
        bool ObterPermissaoUsuario(string userId);
        bool VerificaTrocaSenha(string userId);
        Usuario TrocarSenha(bool trocarSenha, string userId);
        IEnumerable<Usuario> ObterUsuariosOcorrencia();
        IEnumerable<Usuario> ObterUsuarioPorNome(string nome);
        IEnumerable<Usuario> ObterUsuariosContatos();
        IEnumerable<Usuario> ObterUsuariosAtividade();
        IEnumerable<Usuario> ObterResponsaveisAtividade();
        IEnumerable<Usuario> ObterCriadoresAtividade();
        IEnumerable<Usuario> ObterResponsaveisAtribuicao(long? ocorrenciaId, long? atividadeId);
        Usuario ObterResponsavel(long? ocorrenciaId, long? atividadeId);
    }
}
