using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Contexto;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using Dapper;

namespace BizPRO.CRM.V2.Repositorio.Entity
{
    public class UsuarioRepositorio : RepositorioEntity<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(CrudContext context)
            : base(context)
        {

        }

        public Usuario ObterPorEmail(string email)
        {
            return Buscar(c => c.EnderecoEmail == email).FirstOrDefault();
        }

        public override IEnumerable<Usuario> ObterTodos()
        {
            var cn = Db.Database.Connection;
            const string sql = @"SELECT * FROM AspNetUsers";
            return cn.Query<Usuario>(sql);
        }

        public override Usuario ObterPorId(long id)
        {
            var usuario = new List<Usuario>();
            return usuario.FirstOrDefault();
        }

        public Usuario ObterPorUserId(string userId)
        {
            return Buscar(c => c.Id == userId).FirstOrDefault();
        }

        public IEnumerable<Usuario> ObterUsuariosVenda()
        {
            return ObterPorProcedimento("usp_front_sel_UsuariosVenda", null).ToList();
        }

        public IEnumerable<Usuario> ObterUsuariosPorLigacao()
        {
            return ObterPorProcedimento("usp_front_sel_UsuariosLigacoes", null).ToList();
        }

        public bool ObterPermissaoUsuario(string userId)
        {
            var retorno = ObterPorProcedimento("usp_axaExterno_sel_validaPermissao '" + userId + "'", null).ToList();
            return retorno.Count() > 0 ? true : false;
        }

        public bool VerificaTrocaSenha(string userId)
        {
            var retorno = ObterPorProcedimento("usp_front_sel_verificaTrocaSenha '" + userId + "'", null).ToList();
            return retorno.Any();
        }

        public Usuario TrocarSenha(bool trocarSenha, string userId)
        {
            var retorno =
                ObterPorProcedimento("usp_front_upd_TrocaSenha '" + trocarSenha + "' ,'" + userId + "'", null).ToList();
            return retorno.FirstOrDefault();
        }

        public IEnumerable<Usuario> ObterUsuariosOcorrencia()
        {
            return ObterPorProcedimento("usp_front_sel_usuariosOcorrencias", null).OrderByDescending(c => c.CriadoEm);
        }

        public IEnumerable<Usuario> ObterUsuariosContatos()
        {
            return ObterPorProcedimento("usp_front_sel_Contatos", null).OrderByDescending(c => c.CriadoEm);
        }

        public IEnumerable<Usuario> ObterUsuarioPorNome(string nome)
        {
            return ObterPorProcedimento("usp_front_sel_BuscarUsuarioPorNome  '" + nome + "'", null).ToList();
        }

        public IEnumerable<Usuario> ObterUsuariosAtividade()
        {
            return ObterPorProcedimento("usp_front_sel_UsuarioAtividade", null);
        }

        public IEnumerable<Usuario> ObterResponsaveisAtividade()
        {
            return ObterPorProcedimento("usp_front_sel_UsuarioResponsaveisAtividade", null);
        }

        public IEnumerable<Usuario> ObterCriadoresAtividade()
        {
            return ObterPorProcedimento("usp_front_sel_UsuarioCriadoresAtividade", null);
        }

        public IEnumerable<Usuario> ObterResponsaveisAtribuicao(long? ocorrenciaId, long? atividadeId)
        {
            ////Precisco Avaliar Aqui melhor
            var parametros = "";

            if (ocorrenciaId.HasValue)
                parametros = "@ocorrenciaId=" + ocorrenciaId;

            if (atividadeId.HasValue)
                parametros = "@atividadeId=" + atividadeId;

            return
                ObterPorProcedimento(
                    string.Format("{0} {1}", "usp_front_sel_UsuarioAtribuicaoResponsavel", parametros), null).ToList();
        }

        public Usuario ObterResponsavel(long? ocorrenciaId, long? atividadeId)
        {
            var parametros = "";

            if (ocorrenciaId.HasValue)
                parametros = "@ocorrenciaId=" + ocorrenciaId;

            if (atividadeId.HasValue)
                parametros = "@atividadeId=" + atividadeId;

            return
                ObterPorProcedimento(string.Format("{0} {1}", "usp_front_sel_Responsavel", parametros), null)
                    .FirstOrDefault();
        }
    }
}
