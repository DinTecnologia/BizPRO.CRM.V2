using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using BizPRO.CRM.V2.Aplicacao.Adaptadores;
using BizPRO.CRM.V2.Aplicacao.Interfaces;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using BizPRO.CRM.V2.Dominio.Eventos;
using DomainValidation.Validation;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Contexto.Interfaces;
using BizPRO.CRM.V2.Core.Events;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL;
using BizPRO.CRM.V2.Identity.Configuration;
using BizPRO.CRM.V2.Identity.Context;
using BizPRO.CRM.V2.Identity.Model;

namespace BizPRO.CRM.V2.Aplicacao
{
    public class UsuarioAppServico : AppServico, IUsuarioAppServico
    {
        private readonly IUsuarioServico _usuarioServico;
        private readonly ITokenAcessoRapidoServico _tokenAcessoRapidoServico;
        private readonly IDepartamentoServico _departamentoServico;
        private readonly IEquipeServico _equipeServico;
        private readonly IOcorrenciaServico _ocorrenciaServico;
        private readonly IAtividadeServico _atividadeServico;
        private readonly IUsuarioRepositorioDal _usuarioRepositorio;
        private readonly ApplicationUserManager _userManager;

        public UsuarioAppServico(IUsuarioServico usuarioService, IUnitOfWorkEntity uow,
            ApplicationUserManager userManager, ITokenAcessoRapidoServico tokenAcessoRapidoServico,
            IDepartamentoServico departamentoServico, IEquipeServico equipeServico,
            IOcorrenciaServico ocorrenciaServico,
            IAtividadeServico atividadeServico, IUsuarioRepositorioDal usuarioRepositorio)
            : base(uow)
        {
            _usuarioServico = usuarioService;
            _userManager = userManager;
            _tokenAcessoRapidoServico = tokenAcessoRapidoServico;
            _departamentoServico = departamentoServico;
            _equipeServico = equipeServico;
            _ocorrenciaServico = ocorrenciaServico;
            _atividadeServico = atividadeServico;
            _usuarioRepositorio = usuarioRepositorio;

        }

        public Usuario Adicionar(Usuario usuario)
        {
            if (!Notifications.HasNotifications())
            {
                _usuarioServico.Adicionar(usuario);
            }

            return usuario;
        }

        public IdentityResult AdicionarIndentidade(UsuarioItemViewModel register, string userId)
        {
            using (var store = new UserStore<ApplicationUser>(new ApplicationDbContext()) {AutoSaveChanges = false})
            {
                var manager = _userManager;

                var user = new ApplicationUser
                {
                    UserName = register.Email,
                    Email = register.Email,
                    ativo = true,
                    nome = register.Nome.ToUpper()
                };
                var result = manager.Create(user, register.Password);

                if (result.Succeeded)
                {
                    var usuario = UsuarioAdaptador.ToDominioModelo(user.Id, register, userId);
                    Adicionar(usuario);

                    if (Commit())
                    {
                        DomainEvent.Raise(new UsuarioCadastradoEvento(usuario));
                    }
                    else
                    {
                        manager.Delete(user);
                        return new IdentityResult(Notifications.ToString());
                    }
                }
                else
                {
                    var errosBr = new List<string>();
                    var notificationList = new List<DomainNotification>();

                    foreach (var erro in result.Errors)
                    {
                        string erroBr;
                        if (erro.Contains("Passwords must have at least one digit ('0'-'9')."))
                        {
                            erroBr = "A senha precisa ter ao menos um dígito";
                            notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                            errosBr.Add(erroBr);
                        }

                        if (erro.Contains("Passwords must have at least one non letter or digit character."))
                        {
                            erroBr = "A senha precisa ter ao menos um caractere especial (@, #, etc...)";
                            notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                            errosBr.Add(erroBr);
                        }

                        if (erro.Contains("Passwords must have at least one lowercase ('a'-'z')."))
                        {
                            erroBr = "A senha precisa ter ao menos uma letra em minúsculo";
                            notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                            errosBr.Add(erroBr);
                        }

                        if (erro.Contains("Passwords must have at least one uppercase ('A'-'Z')."))
                        {
                            erroBr = "A senha precisa ter ao menos uma letra em maiúsculo";
                            notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                            errosBr.Add(erroBr);
                        }

                        if (erro.Contains("Name " + register.Email + " is already taken"))
                        {
                            erroBr = "E-mail já registrado, esqueceu sua senha?";
                            notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                            errosBr.Add(erroBr);
                        }

                    }

                    notificationList.ForEach(DomainEvent.Raise);
                    result = new IdentityResult(errosBr);
                }

                return result;
            }
        }

        public void Dispose()
        {
            _usuarioServico.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPorUserId(string userId)
        {
            var usuario = new Usuario();

            if (!Notifications.HasNotifications())
            {
                //usuario = _usuarioServico.ObterPorUserId(userId);
                usuario = _usuarioRepositorio.ObterPorUserId(userId);
            }

            return usuario;
        }

        public Usuario Deletar(string id, string userIdAcao)
        {
            var usuario = _usuarioServico.ObterPorUserId(id);

            if (usuario != null)
            {
                usuario.Inativar(userIdAcao);
                _usuarioServico.Atualizar(usuario);
            }

            return Commit() ? usuario : usuario;
        }

        public List<string> ListaErros(IEnumerable<string> erros)
        {
            var errosBr = new List<string>();
            var notificationList = new List<DomainNotification>();

            foreach (var erro in erros)
            {
                string erroBr;
                if (erro.Contains("Passwords must have at least one digit ('0'-'9')."))
                {
                    erroBr = "A senha precisa ter ao menos um dígito";
                    notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                    errosBr.Add(erroBr);
                }

                if (erro.Contains("Passwords must have at least one non letter or digit character."))
                {
                    erroBr = "A senha precisa ter ao menos um caractere especial (@, #, etc...)";
                    notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                    errosBr.Add(erroBr);
                }

                if (erro.Contains("Passwords must have at least one lowercase ('a'-'z')."))
                {
                    erroBr = "A senha precisa ter ao menos uma letra em minúsculo";
                    notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                    errosBr.Add(erroBr);
                }

                if (erro.Contains("Passwords must have at least one uppercase ('A'-'Z')."))
                {
                    erroBr = "A senha precisa ter ao menos uma letra em maiúsculo";
                    notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                    errosBr.Add(erroBr);
                }

                if (erro.Contains("Email") && erro.Contains("already taken"))
                {
                    erroBr = "E-mail já registrado !";
                    notificationList.Add(new DomainNotification("IdentityValidation", erroBr));
                    errosBr.Add(erroBr);
                }
            }

            return errosBr;
        }

        public bool ObterPermissaoUsuario(string userId)
        {
            return _usuarioServico.ObterPermissaoUsuario(userId);
        }

        public bool VerificaTrocaSenha(string userId)
        {
            //return _usuarioServico.VerificaTrocaSenha(userId);
            return _usuarioRepositorio.VerificaTrocaSenha(userId);
        }

        public Usuario TrocarSenha(bool trocarSenha, string userId)
        {
            return _usuarioServico.TrocarSenha(trocarSenha, userId);
        }

        public Usuario LoginToken(string token)
        {
            var retorno = new Usuario();
            var resultado = _tokenAcessoRapidoServico.ObterPorId(token);

            if (resultado != null)
            {
                if (resultado.Ativo())
                    return _usuarioServico.ObterPorUserId(resultado.AspNetUsersId);
                var msgRetorno = new ValidationResult();
                msgRetorno.Add(new ValidationError("Token vencido"));
                retorno.ValidationResult = msgRetorno;
            }
            else
            {
                var msgRetorno = new ValidationResult();
                msgRetorno.Add(new ValidationError("Token inválido"));
                retorno.ValidationResult = msgRetorno;
            }

            return retorno;
        }

        public IEnumerable<Departamento> ObterDepartamentos()
        {
            return _departamentoServico.ObterTodos();
        }

        public IEnumerable<Departamento> ObterDepartamentoPorUser(string userId)
        {
            return _departamentoServico.ObterDepartamentoPorUser(userId);
        }

        public IEnumerable<Equipe> ObterEquipes()
        {
            return _equipeServico.ObterTodos();
        }






        public IEnumerable<Equipe> ObterEquipesPorUsuario(string userId)
        {
            return _equipeServico.ObterPorUsuario(userId);
        }

        public AlterarResponsavelViewModel CarregarAlterarResponsavel(long? ocorrenciaId, long? atividadeId)
        {
            Usuario usuarioAtual;

            if (ocorrenciaId.HasValue)
            {
                var ocorrencia = _ocorrenciaServico.ObterPorId((long) ocorrenciaId);
                usuarioAtual = _usuarioServico.ObterPorUserId(ocorrencia.ResponsavelPorAspNetUserId);
            }
            else
            {
                var atividade = _atividadeServico.ObterPorId((long) atividadeId);
                usuarioAtual = _usuarioServico.ObterPorUserId(atividade.ResponsavelPorUserId);
            }

            var listaUsuarios = _usuarioServico.ObterResponsaveisAtribuicao(ocorrenciaId, atividadeId);

            if (usuarioAtual == null)
                usuarioAtual = new Usuario();

            return new AlterarResponsavelViewModel(ocorrenciaId, atividadeId, usuarioAtual.Id, usuarioAtual.Nome,
                new System.Web.Mvc.SelectList(listaUsuarios, "id", "nome"));
        }

        public AlterarResponsavelViewModel AlterarResponsavel(AlterarResponsavelViewModel model)
        {
            if (model.OcorrenciaId == null && model.AtividadeId == null)
            {
                model.ValidationResult.Add(
                    new ValidationError("Não é possível atualizar o responsável, não foi identificado o chave."));
                return model;
            }

            model.ValidationResult = model.OcorrenciaId.HasValue
                ? _ocorrenciaServico.AtualizarResponsavel((long) model.OcorrenciaId, model.ResponsavalNovoId,
                    model.AtualizadoPorUserId)
                : _atividadeServico.AtualizarResponsavel((long) model.AtividadeId, model.ResponsavalNovoId,
                    model.AtualizadoPorUserId);

            return model;
        }

        public UsuarioViewModel CarregarPerfil(string usuarioId, bool partialViewMinimizada)
        {
            var usuario = _usuarioServico.ObterPorUserId(usuarioId);

            if (usuario == null)
            {
                return
                    new UsuarioViewModel(
                        string.Format("Nenhum usúario encontrado com o id ({0}) informado", usuarioId),
                        partialViewMinimizada);
            }

            var departamentoNome = string.Empty;

            if (usuario.DepartamentoId.HasValue)
            {
                var departamento = _departamentoServico.ObterPorId((int) usuario.DepartamentoId);
                if (departamento != null)
                    departamentoNome = departamento.Nome;
            }

            return new UsuarioViewModel(usuario.Nome, usuario.EnderecoEmail, usuario.EnderecoEmail, departamentoNome,
                partialViewMinimizada);
        }
    }
}
