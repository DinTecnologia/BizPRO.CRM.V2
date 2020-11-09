using System;
using System.Collections.Generic;
using System.Linq;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Dominio.Validacoes.Usuarios;
using Dapper;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ITokenAcessoRapidoRepositorio _tokenAcessoRapidoRepositorio;
        private readonly IConfiguracaoServico _servicoConfiguracao;
        private DynamicParameters _parametros;

        public UsuarioServico(IUsuarioRepositorio usuarioRapositorio,
            ITokenAcessoRapidoRepositorio tokenAcessoRapidoRepositorio, IConfiguracaoServico servicoConfiguracao)
        {
            _usuarioRepositorio = usuarioRapositorio;
            _tokenAcessoRapidoRepositorio = tokenAcessoRapidoRepositorio;
            _servicoConfiguracao = servicoConfiguracao;
            _parametros = new DynamicParameters();
        }

        public Usuario Adicionar(Usuario usuario)
        {
            if (!usuario.IsValid())
            {
                return usuario;
            }

            usuario.ValidationResult = new UsuarioAptoParaCadastroValidacoes(_usuarioRepositorio).Validate(usuario);

            if (!usuario.ValidationResult.IsValid)
            {
                return usuario;
            }

            usuario.ValidationResult.Message = "Usuario cadastrado com sucesso :)";
            return _usuarioRepositorio.Adicionar(usuario);
        }
        public Usuario ObterPorId(long id)
        {
            return _usuarioRepositorio.ObterPorId(id);
        }
        public Usuario ObterPorEmail(string email)
        {
            return _usuarioRepositorio.ObterPorEmail(email);
        }
        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioRepositorio.ObterTodos().OrderBy(b => b.Nome);
        }
        public Usuario Atualizar(Usuario cliente)
        {
            return _usuarioRepositorio.Atualizar(cliente);
        }
        public void Deletar(long id)
        {
            _usuarioRepositorio.Remover(id);
        }
        public void Dispose()
        {
            _usuarioRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }
        public Usuario ObterPorUserId(string userId)
        {
            return _usuarioRepositorio.ObterPorUserId(userId);
        }
        public IEnumerable<Usuario> CarregarUsuariosVendas()
        {
            return _usuarioRepositorio.ObterUsuariosVenda().OrderBy(b => b.Nome);
        }
        public IEnumerable<Usuario> CarregarUsuariosLigacoes()
        {
            return _usuarioRepositorio.ObterUsuariosPorLigacao().OrderBy(b => b.Nome);
        }
        //public IEnumerable<Usuario> Teste()
        //{
        //    return _usuarioRepositorio.ObterUsuariosVenda();            
        //}
        public bool ObterPermissaoUsuario(string userId)
        {
            return _usuarioRepositorio.ObterPermissaoUsuario(userId);
        }
        public bool VerificaTrocaSenha(string userId)
        {
            return _usuarioRepositorio.VerificaTrocaSenha(userId);
        }
        public Usuario TrocarSenha(bool trocarSenha, string userId)
        {
            var retorno = _usuarioRepositorio.TrocarSenha(trocarSenha, userId);
            retorno.DefinirEmail("thiago.din@bizpro.com.br");

            if (retorno.IsValid())
            {
                var configuracao = new Configuracao();
                configuracao.SetarPeriodoExpiracaoSenha();
                var resultadoConfiguracaoPeriodoExpiracaoSenha = _servicoConfiguracao.ObterPor(configuracao);

                if (resultadoConfiguracaoPeriodoExpiracaoSenha.Any())
                {

                }
            }

            return retorno;
        }
        public IEnumerable<Usuario> ObterUsuariosOcorrencia()
        {
            return _usuarioRepositorio.ObterUsuariosOcorrencia().OrderBy(b => b.Nome);
        }
        public IEnumerable<Usuario> ObterUsuariosContatos()
        {
            return _usuarioRepositorio.ObterUsuariosOcorrencia().OrderBy(b => b.Nome);
        }
        public bool GerarTokenAcessoRapido(Usuario entidade)
        {
            entidade.GerarTokenAcessoRapido();
            var resultado = _tokenAcessoRapidoRepositorio.Adicionar(entidade.Token);
            return resultado == null ? false : true;
        }
        public IEnumerable<Usuario> BuscarPorNome(string nome)
        {
            return _usuarioRepositorio.ObterUsuarioPorNome(nome).OrderBy(b => b.Nome);
        }
        public IEnumerable<Usuario> ObterUsuariosAtividades()
        {
            return _usuarioRepositorio.ObterUsuariosAtividade();
        }
        public IEnumerable<Usuario> ObterCriadoresAtividades()
        {
            return _usuarioRepositorio.ObterCriadoresAtividade();
        }
        public IEnumerable<Usuario> ObterResponsaveisAtividades()
        {
            return _usuarioRepositorio.ObterResponsaveisAtividade();
        }
        public IEnumerable<Usuario> ObterResponsaveisAtribuicao(long? ocorrenciaId, long? atividadeId)
        {
            //return _usuarioRepositorio.ObterUsuariosAtribuicaoResponsavel(ocorrenciaId, atividadeId);
            return _usuarioRepositorio.ObterResponsaveisAtribuicao(ocorrenciaId, atividadeId);
        }
        public Usuario ObterResponsavel(long? ocorrenciaId, long? atividadeId)
        {
            return _usuarioRepositorio.ObterResponsavel(ocorrenciaId, atividadeId);
        }
    }
}
