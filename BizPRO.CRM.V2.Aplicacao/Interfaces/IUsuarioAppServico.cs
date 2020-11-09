using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Identity.Model;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IUsuarioAppServico : IDisposable
    {
        IdentityResult AdicionarIndentidade(UsuarioItemViewModel register, string userId);
        IEnumerable<Usuario> ObterTodos();
        Usuario ObterPorUserId(string userId);
        Usuario Deletar(string id, string userIdAcao);
        List<string> ListaErros(IEnumerable<string> erros);
        bool ObterPermissaoUsuario(string userId);
        bool VerificaTrocaSenha(string userId);
        Usuario TrocarSenha(bool trocarSenha, string userId);
        Usuario LoginToken(string token);
        IEnumerable<Departamento> ObterDepartamentos();
        IEnumerable<Departamento> ObterDepartamentoPorUser(string userId);
        IEnumerable<Equipe> ObterEquipes();
        IEnumerable<Equipe> ObterEquipesPorUsuario(string userId);
        AlterarResponsavelViewModel CarregarAlterarResponsavel(long? ocorrenciaId, long? atividadeId);
        AlterarResponsavelViewModel AlterarResponsavel(AlterarResponsavelViewModel model);
        UsuarioViewModel CarregarPerfil(string usuarioId, bool partialViewMinimizada);
    }
}
