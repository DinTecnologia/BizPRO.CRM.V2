using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio;
using BizPRO.CRM.V2.Dominio.Interfaces.Servicos;
using DomainValidation.Validation;
using System.Linq;
using System.Text;
using BizPRO.CRM.V2.Dominio.Interfaces.Repositorio.IDAL;

namespace BizPRO.CRM.V2.Dominio.Servicos
{
    public class EmailServico : Servico<Email>, IEmailServico
    {
        private readonly IEmailRepositorio _repositorio;
        private readonly IAtividadeServico _atividadeServico;
        private readonly IStatusAtividadeServico _statusAtividadeServico;
        private readonly IEmailLogServico _emailLogServico;
        private readonly IEmailAnexoServico _emailAnexoServico;
        private readonly IAtividadeFilaServico _atividadeFilaServico;
        private readonly IAtividadeParteEnvolvidaServico _atividadeParteEnvolvidaServico;
        private readonly IAtendimentoServico _atendimentoServico;
        private readonly IUsuarioServico _usuarioServico;
        private readonly IEmailModeloServico _emailModelServico;
        private readonly IConfiguracaoContasEmailsServico _configuracaoContaEmailServico;
        private readonly IFilaServico _filaServico;
        private readonly IEmailRepositorioDal _repositorioDal;

        public EmailServico(IEmailRepositorioDal repositorioDal, IEmailRepositorio repositorio, IAtividadeServico atividadeServico,
            IStatusAtividadeServico statusAtividadeServico, IEmailLogServico emailLogServico,
            IEmailAnexoServico emailAnexoServico, IAtividadeFilaServico atividadeFilaServico,
            IAtividadeParteEnvolvidaServico atividadeParteEnvolvidaServico, IAtendimentoServico atendimentoServico,
            IUsuarioServico usuarioServico, IEmailModeloServico emailModelServico,
            IConfiguracaoContasEmailsServico configuracaoContaEmailServico, IFilaServico filaServico)
            : base(repositorio)
        {
            _repositorio = repositorio;
            _atividadeServico = atividadeServico;
            _statusAtividadeServico = statusAtividadeServico;
            _emailLogServico = emailLogServico;
            _emailAnexoServico = emailAnexoServico;
            _atividadeFilaServico = atividadeFilaServico;
            _atividadeParteEnvolvidaServico = atividadeParteEnvolvidaServico;
            _atendimentoServico = atendimentoServico;
            _usuarioServico = usuarioServico;
            _emailModelServico = emailModelServico;
            _configuracaoContaEmailServico = configuracaoContaEmailServico;
            _filaServico = filaServico;
            //_repositorioDal = repositorioDal;
        }

        public ValidationResult AtualizarEmailEnviado(long emailId)
        {
            var retorno = new ValidationResult();
            var email = _repositorio.ObterPorId(emailId);

            if (email == null)
            {
                retorno.Add(new ValidationError("Nenhum e-mail retornado com o id: " + emailId));
                return retorno;
            }

            var status = _statusAtividadeServico.ObterStatusAtividadePadraoFinalizaParaEmail();
            if (status == null)
            {
                retorno.Add(new ValidationError("Nenhum Status finalizador padrão cadastrado."));
                return retorno;
            }

            _atividadeServico.AtualizarStatus(email.AtividadeId, status.Id, null, null);
            _atividadeFilaServico.AtualizaSaiuDaFilaPorAtividadeId(email.AtividadeId);

            return retorno;
        }

        public void LogarTentativaEnvio(long emailId, IEnumerable<ValidationError> erros)
        {
            var email = _repositorio.ObterPorId(emailId);
            email.QuantidadeDeEnvios = email.QuantidadeDeEnvios + 1;
            if (!_repositorio.Atualizar(email)) return;
            var mensagemErro = new StringBuilder();

            if (erros != null)
            {
                foreach (var item in erros)
                {
                    if (string.IsNullOrEmpty(mensagemErro.ToString()))
                        mensagemErro.Append(item.Message);
                    else
                        mensagemErro.Append("/ " + item.Message);
                }
            }

            var emailLog = new EmailLog(email.Id, mensagemErro.ToString());
            _emailLogServico.Adicionar(emailLog);
        }

        public IEnumerable<Email> ObterEmailsPendentesDeEnvio(long filaId)
        {
            return _repositorio.ObterEmailsPendentesDeEnvio(filaId);
        }

        public ValidationResult Adicionar(Email entidade, int? filaId)
        {
            var retorno = new ValidationResult();

            if (!entidade.IsValid())
                return entidade.ValidationResult;

            if (!entidade.ValidationResult.IsValid)
                return entidade.ValidationResult;

            var emailId = _repositorio.Adicionar(entidade);

            if (emailId != null)
            {
                if (entidade.Anexos.Any())
                {
                    foreach (var anexo in entidade.Anexos)
                    {
                        anexo.SetarEmailId(emailId);
                        _emailAnexoServico.Adicionar(anexo);

                        ////Tratando os anexos do corpo do E-mail                        
                        if (!string.IsNullOrEmpty(anexo.IdProvisorio))
                        {
                            var oldString = @"/Imagem/CorpoEmail/" + anexo.IdProvisorio;
                            entidade.SetarCorpoEmail(entidade.CorpoDoEmail.Replace(oldString,
                                @"/Imagem/CorpoEmail/" + anexo.Id));
                            entidade.SetarCorpoEmail(
                                entidade.CorpoDoEmail.Replace(oldString.Replace("<", "").Replace(">", ""),
                                    @"/Imagem/CorpoEmail/" + anexo.Id));
                        }

                        if (!string.IsNullOrEmpty(anexo.ContentId))
                        {
                            var oldStringCompleto = "cid:" + anexo.Nome + anexo.ContentId;
                            var oldString = "cid:" + anexo.ContentId;
                            entidade.SetarCorpoEmail(entidade.CorpoDoEmail.Replace(oldString,
                                @"/Imagem/CorpoEmail/" + anexo.Id));
                            entidade.SetarCorpoEmail(
                                entidade.CorpoDoEmail.Replace(oldString.Replace("<", "").Replace(">", ""),
                                    @"/Imagem/CorpoEmail/" + anexo.Id));
                            entidade.SetarCorpoEmail(entidade.CorpoDoEmail.Replace(oldStringCompleto,
                                @"/Imagem/CorpoEmail/" + anexo.Id));
                            entidade.SetarCorpoEmail(
                                entidade.CorpoDoEmail.Replace(oldStringCompleto.Replace("<", "").Replace(">", ""),
                                    @"/Imagem/CorpoEmail/" + anexo.Id));
                        }
                    }
                    _repositorio.Atualizar(entidade);
                }

                if (filaId.HasValue && filaId != 0)
                {
                    retorno =
                        _atividadeFilaServico.Adicionar(new AtividadeFila(entidade.Atividade.Id, (int)filaId,
                            string.IsNullOrEmpty(entidade.Atividade.ResponsavelPorUserId)
                                ? (DateTime?)null
                                : DateTime.Now));
                }
                entidade.SetarIdEmailReferenciaHtml();
                retorno = Atualizar(entidade);
            }
            return retorno;
        }




        public IEnumerable<Email> ObterUids(int configuracaContasEmailsId)
        {
            return _repositorio.ObterUids(configuracaContasEmailsId);
        }

        public Email ObterEmailCompletoPor(long? emailId, long? atividadeId)
        {
            var email = _repositorio.ObterEmailCompletoPor(emailId, atividadeId);

            if (email == null) return email;
            email.Anexos = _emailAnexoServico.ObterAnexos(email.AtividadeId);
            email.Atividade.Envolvidos = _atividadeParteEnvolvidaServico.ObterPorAtividadeId(email.Atividade.Id);

            return email;
        }

        public ValidationResult RegistrarSpam(long id, string userId, int? statusAtividade)
        {
            var retorno = new ValidationResult();
            var email = _repositorio.ObterEmailCompletoPor(id, null);

            if (email != null)
            {
                email.Inativar(userId);
                _repositorio.Atualizar(email);

                if (email.Atividade != null)
                    _atividadeServico.Atualizar(email.Atividade);
            }

            return retorno;
        }

        public int PossuiNovosEmails(string userId)
        {
            return _repositorio.PossuiNovosEmails(userId);
        }

        public Email BuscarProximoEmail(string userId)
        {
            return _repositorio.BuscarProximoEmail(userId);
        }

        public Email AdicionarEmailEntradaServico(ConfiguracaoContasEmails configuracaoContaEmail,
            Email emailPai, IEnumerable<AtividadeParteEnvolvida> partesEnvolvidas, IEnumerable<EmailAnexo> anexos,
            string endereco, string assunto, string html, string texto, string uIdEmail, string messageId,
            DateTime criadoEm, string nomeCliente, string identificadorEmail)
        {
            var retorno = new Email();
            var gerarProtocolo = configuracaoContaEmail.Fila.GerarProtocoloNaEntradaDeEmail ?? false;
            var criadoPorUserId = "";
            long? atendimentoId = null;
            string protocolo = null;

            var usuarioAdm = _usuarioServico.ObterPorEmail("sistemas@bizpro.com.br");
            if (usuarioAdm != null)
                criadoPorUserId = usuarioAdm.Id;
            else
            {
                retorno.ValidationResult.Add(
                    new ValidationError(
                        "Não foi informado o usuario (Criado Por) e também não possui usuario padrão cadastrado (sistemas@bizpro.com.br)"));
                return retorno;
            }

            if (gerarProtocolo)
            {
                var atendimento = _atendimentoServico.AdicionarNovoAtendimento(null, criadoPorUserId, null);
                if (!atendimento.ValidationResult.IsValid)
                {
                    retorno.ValidationResult = atendimento.ValidationResult;
                    return retorno;
                }
                atendimentoId = atendimento.Id;
                protocolo = atendimento.Protocolo;
            }

            if (emailPai == null)
                emailPai = new Email();

            if (emailPai.Atividade == null)
                emailPai.Atividade = new Atividade();

            retorno = AdicionarEmail(criadoPorUserId, emailPai.Atividade.ResponsavelPorUserId, criadoEm,
                emailPai.Atividade.OcorrenciaId, emailPai.Atividade.ContratoId, atendimentoId,
                emailPai.Atividade.PessoasFisicasId, emailPai.Atividade.PessoasJuridicasId,
                emailPai.Atividade.PotenciaisClientesId, emailPai.Atividade.Id, assunto,
                string.Format("E-mail importado pelo serviço em {0}", DateTime.Now), endereco, html, texto, messageId,
                uIdEmail, "E", assunto, emailPai.Id > 0 ? emailPai.Id : (long?)null, configuracaoContaEmail.Id,
                (int)configuracaoContaEmail.FilasId, partesEnvolvidas, anexos, null, identificadorEmail);

            if (!retorno.ValidationResult.IsValid)
            {
                return retorno;
            }

            var enviarEmailResposta = configuracaoContaEmail.Fila.EnviarEmailComProtocoloGerado ?? false;

            if (!enviarEmailResposta) return retorno;
            if (!configuracaoContaEmail.Fila.EmailModeloEnvioProtocoloEmailsModeloId.HasValue) return retorno;

            var htmlModelo =
                _emailModelServico.ObterPorId(
                    (int)configuracaoContaEmail.Fila.EmailModeloEnvioProtocoloEmailsModeloId);

            if (htmlModelo == null) return retorno;

            html = htmlModelo.Html.Replace("[PROTOCOLO]", protocolo);
            html = html.Replace("[NOME_CLIENTE]", !string.IsNullOrEmpty(nomeCliente) ? nomeCliente : "");

            var partesEnvolvidasResposta = (from envolvido in partesEnvolvidas
                                            where envolvido.TipoParteEnvolvida == TipoParteEnvolvida.Remetente.Value
                                            select
                                            new AtividadeParteEnvolvida(envolvido.Email, envolvido.Nome, TipoParteEnvolvida.Destinatario.Value))
                .ToList();

            if (configuracaoContaEmail.Fila.ContaParaDisparoDeEmailConfiguracaoContasEmailsId.HasValue)
            {
                var contaDisparo =
                    _configuracaoContaEmailServico.ObterPorId(
                        (int)configuracaoContaEmail.Fila.ContaParaDisparoDeEmailConfiguracaoContasEmailsId);
                if (contaDisparo != null)
                    if (contaDisparo.Id > 0)
                        partesEnvolvidasResposta.Add(new AtividadeParteEnvolvida(contaDisparo.Email,
                            contaDisparo.Descricao, TipoParteEnvolvida.Remetente.Value));
            }
            else
                partesEnvolvidasResposta.Add(new AtividadeParteEnvolvida(configuracaoContaEmail.Email,
                    configuracaoContaEmail.Descricao, TipoParteEnvolvida.Remetente.Value));

            var filaEnvioEmailComum = _filaServico.ObterFilasPorNome("ENVIO_EMAIL_COMUM");
            long? respostaFilaId = null;

            if (filaEnvioEmailComum.Any())
                respostaFilaId = filaEnvioEmailComum.FirstOrDefault().Id;

            var retornoResposta = AdicionarEmail(criadoPorUserId, null, null, null, null, atendimentoId,
                 emailPai.Atividade.PessoasFisicasId, emailPai.Atividade.PessoasJuridicasId,
                 emailPai.Atividade.PotenciaisClientesId, null, "Resposta Automatica",
                 string.Format("E-mail respondido pelo serviço em {0}", DateTime.Now), endereco, html, null,
                 null, null, "S", "Resposta Automática", null, configuracaoContaEmail.Id,
                 respostaFilaId.HasValue ? (int)respostaFilaId : (int)configuracaoContaEmail.FilasId,
                 partesEnvolvidasResposta, new List<EmailAnexo>(), null, identificadorEmail);

            return retorno;
        }

        public Email AdicionarEmail(string criadoPorUserId, string responsavelPorUserId, DateTime? criadoEm,
            long? ocorrenciaId, long? contratoId, long? atendimentoId, long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potencialClienteId, long? atividadeDeOrigemId, string tituloAtividade, string descricaoAtividade,
            string enderecoEmail, string html, string texto, string messageId, string uIdMessage, string sentido,
            string assunto, long? emailPaiId, int? configuracaoContasEmailId, int? filaId,
            IEnumerable<AtividadeParteEnvolvida> atividadeEnvolvidos, IEnumerable<EmailAnexo> anexos,
            int? statusAtividadeId, string identificadorEmail)
        {
            var retorno = new Email();

            if (string.IsNullOrEmpty(criadoPorUserId))
            {
                var usuarioAdm = _usuarioServico.ObterPorEmail("sistemas@bizpro.com.br");
                if (usuarioAdm != null)
                    criadoPorUserId = usuarioAdm.Id;
                else
                {
                    retorno.ValidationResult.Add(
                        new ValidationError(
                            "Não foi informado o usuario (Criado Por) e também não possui usuario padrão cadastrado (sistemas@bizpro.com.br)"));
                    return retorno;
                }
            }

            var atividade = _atividadeServico.AdicionarAtividadeEmail(criadoPorUserId, ocorrenciaId, contratoId,
                atendimentoId, tituloAtividade, descricaoAtividade, pessoaFisicaId, pessoaJuridicaId, potencialClienteId,
                null, null, null, atividadeDeOrigemId, atividadeEnvolvidos, responsavelPorUserId,
                sentido.ToLower() == "s", statusAtividadeId);

            if (!atividade.ValidationResult.IsValid)
            {
                retorno.ValidationResult = atividade.ValidationResult;
                return retorno;
            }
            else
            {
                retorno.SetarAtividadeId(atividade.Id);
            }

            var email = new Email(enderecoEmail, assunto, html, texto, atividade.CriadoPorUserId, sentido, uIdMessage,
                messageId, emailPaiId, configuracaoContasEmailId, anexos, criadoEm, atividade,
                atividade.PessoasFisicasId, atividade.PessoasJuridicasId, identificadorEmail);

            if (email.IsValid())
                retorno.ValidationResult = Adicionar(email, filaId);

            return retorno;
        }

        public Email Novo(string criadoPorUserId, string responsavelPorUserId, DateTime? criadoEm,
            long? ocorrenciaId, long? contratoId, long? atendimentoId, long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potencialClienteId, long? atividadeDeOrigemId, string tituloAtividade, string descricaoAtividade,
            string enderecoEmail, string html, string texto, string messageId, string uIdMessage, string sentido,
            string assunto, long? emailPaiId, int? configuracaoContasEmailId, int? filaId,
            IEnumerable<AtividadeParteEnvolvida> atividadeEnvolvidos, IEnumerable<EmailAnexo> anexos,
            int? statusAtividadeId, string identificadorEmail)
        {
            var retorno = new Email();

            if (string.IsNullOrEmpty(criadoPorUserId))
            {
                var usuarioAdm = _usuarioServico.ObterPorEmail("sistemas@bizpro.com.br");
                if (usuarioAdm != null)
                    criadoPorUserId = usuarioAdm.Id;
                else
                {
                    retorno.ValidationResult.Add(
                        new ValidationError(
                            "Não foi informado o usuario (Criado Por) e também não possui usuario padrão cadastrado (sistemas@bizpro.com.br)"));
                    return retorno;
                }
            }

            var atividade = _atividadeServico.AdicionarAtividadeEmail(criadoPorUserId, ocorrenciaId, contratoId,
                atendimentoId, tituloAtividade, descricaoAtividade, pessoaFisicaId, pessoaJuridicaId, potencialClienteId,
                null, null, null, atividadeDeOrigemId, atividadeEnvolvidos, responsavelPorUserId,
                sentido.ToLower() == "s", statusAtividadeId);

            if (!atividade.ValidationResult.IsValid)
            {
                retorno.ValidationResult = atividade.ValidationResult;
                return retorno;
            }

            var email = new Email(enderecoEmail, assunto, html, texto, atividade.CriadoPorUserId, sentido, uIdMessage,
                messageId, emailPaiId, configuracaoContasEmailId, anexos, criadoEm, atividade,
                atividade.PessoasFisicasId, atividade.PessoasJuridicasId, identificadorEmail);

            if (email.IsValid())
                retorno.ValidationResult = Adicionar(email, filaId);

            return email;
        }

        public void ClassificarEmailAutomatico(long atividadeId, long statusAtividadeId, int filaId)
        {
             _repositorio.ClassificarEmailAutomatico(atividadeId, statusAtividadeId, filaId);
        }
    }
}
