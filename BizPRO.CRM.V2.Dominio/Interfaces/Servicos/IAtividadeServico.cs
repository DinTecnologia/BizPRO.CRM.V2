using System;
using System.Collections.Generic;
using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IAtividadeServico
    {
        IEnumerable<Atividade> ObterAtividadesPorCliente(long? pessoaFisicaId, long? pessoaJuridicaId, int? quantidade);
        void AtualizarStatusLigacao(long ligacaoId, int statusAtividadeId);
        void AtualizarAtendimentoId(long atividadeId, long atendimentoId);
        void AtualizarStatus(long atividadeId, int statusAtividadeId, string userId, int? midiaId);
        void Atualizar(Atividade atividade, StatusAtividade statusAtividade, string finalizadoPorUserId, int midiaId);
        ValidationResult Adicionar(Atividade entidade);
        Atividade ObterPorId(long id);
        Atividade ObterPorIdDal(long id);
        ValidationResult Atualizar(Atividade entidade);
        void AtualizarDadosAtividadeEAtividadeFila(string userId, long atividadeId);
        ValidationResult AtualizarResponsavel(long atividadeId, string responsavelId, string atualizadoPorId);
        ValidationResult AdicionarSolicitacaoLigacaoCorretor(long ocorrenciaId, string criadoPorUserId, string descricao);
        IEnumerable<Atividade> ObterNaoFinalizadasPorOcorrenciaId(long ocorrenciaId);
        Atividade ObterAtividadeCompletaPor(long atividadeId);

        void AtualizarCliente(long atividadeId, long? pessoaFisicaId, long? pessoaJuridicaId, string userId,
            string tipoParteEnvolvida, bool inserirParteEnvolvida = true);

        Atividade NovaAtividadeLigacao(string criadoPorId, string reponsavelPorId, int? statusAtividade,
            long? atendimentoId, DateTime? previsaoDeExecucao, string titulo, string descricao, long? pessoaFisicaId,
            long? pessoaJuridicaId, string iniciadoPorUserId);

        Atividade AdicionarAtividadeEmail(string userId, long? ocorrenciaId, long? contratoId, long? atendimentoId,
            string titulo, string descricao, long? pessoaFisicaId, long? pessoaJuridicaId, long? potencialClienteId,
            int? canalId, int? midiaId, string iniciadoPorUserId, long? atividadeDeOrigemId,
            IEnumerable<AtividadeParteEnvolvida> envolvidos, string responsavelPorUserId, bool enviarEmail, int? statusAtividadeId);

        Atividade AdicionarAtividadeTarefa(string userId, long? ocorrenciaId, long? contratoId, long? atendimentoId,
            string titulo, string descricao, long? pessoaFisicaId, long? pessoaJuridicaId, long? potencialClienteId,
            int? canalId, int? midiaId, string iniciadoPorUserId, long? atividadeDeOrigemId, string responsavelPorUserId,
            DateTime? previsaoExecucao);

        ValidationResult RedirecionarFila(string atividadesId, string usuarioId, int filaId);

        IEnumerable<AtividadeApoio> ObterPor(int? atividadeTipoId, DateTime? criadoEm, string criadoPor,
            int? statusAtividadeId, long? ocorrenciaId, long? contratoId, long? atendimentoId,
            DateTime? previsaoExecucao, long? pessoaFisicaId, long? pessoaJuridicaId, long? potencialClienteId,
            int canalId, int? midiaId, string responsavel, int? filaId, string protocolo, int? situacaoId,
            bool? atividadeEmFila, int departamentoId);

        Atividade AdicionarAtividadeChat(string usuarioId, long? atendimentoId,
            IEnumerable<AtividadeParteEnvolvida> envolvidos, int? statusAtividadeId);

    }
}
