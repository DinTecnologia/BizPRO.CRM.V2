using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IEmailServico : IServico<Email>
    {
        IEnumerable<Email> ObterEmailsPendentesDeEnvio(long filaId);
        ValidationResult AtualizarEmailEnviado(long emailId);
        void LogarTentativaEnvio(long emailId, IEnumerable<ValidationError> erros);
        IEnumerable<Email> ObterUids(int configuracaContasEmailsId);
        Email ObterEmailCompletoPor(long? emailId, long? atividadeId);
        ValidationResult RegistrarSpam(long id, string userId, int? statusAtividade);
        int PossuiNovosEmails(string userId);
        Email BuscarProximoEmail(string userId);

        Email AdicionarEmailEntradaServico(ConfiguracaoContasEmails configuracaoContaEmail, Email emailPai,
            IEnumerable<AtividadeParteEnvolvida> partesEnvolvidas, IEnumerable<EmailAnexo> anexos, string endereco,
            string assunto, string html, string texto, string uIdEmail, string messageId, DateTime criadoEm,
            string nomeCliente, string identificadorEmail);

        Email AdicionarEmail(string criadoPorUserId, string responsavelPorUserId, DateTime? criadoEm,
            long? ocorrenciaId, long? contratoId, long? atendimentoId, long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potencialClienteId, long? atividadeDeOrigemId, string tituloAtividade, string descricaoAtividade,
            string enderecoEmail, string html, string texto, string messageId, string uIdMessage, string sentido,
            string assunto, long? emailPaiId, int? configuracaoContasEmailId, int? filaId,
            IEnumerable<AtividadeParteEnvolvida> atividadeEnvolvidos, IEnumerable<EmailAnexo> anexos,
            int? statusAtividadeId, string IdentificadorEmail);

        Email Novo(string criadoPorUserId, string responsavelPorUserId, DateTime? criadoEm,
            long? ocorrenciaId, long? contratoId, long? atendimentoId, long? pessoaFisicaId, long? pessoaJuridicaId,
            long? potencialClienteId, long? atividadeDeOrigemId, string tituloAtividade, string descricaoAtividade,
            string enderecoEmail, string html, string texto, string messageId, string uIdMessage, string sentido,
            string assunto, long? emailPaiId, int? configuracaoContasEmailId, int? filaId,
            IEnumerable<AtividadeParteEnvolvida> atividadeEnvolvidos, IEnumerable<EmailAnexo> anexos,
            int? statusAtividadeId, string IdentificadorEmail);

        void ClassificarEmailAutomatico(long atividadeId, long statusAtividadeId, int filaId);
    }
}
