using System;
using BizPRO.CRM.V2.Dominio.Entidades;
using Dapper;
using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Repositorio
{
    public interface IAtividadeRepositorio : IRepositorio<Atividade>
    {
        Atividade AlteraDataPrevisaoAtividade(DateTime data, long atividadeId);
        void AtualizarAtendimentoId(long atividadeId, long atendimentoId);
        void AtualizarCliente(long atividadeId, long? pessoaFisicaid, long? pessoaJuridicaId, string userId);
        void AtualizarStatus(long atividadeId, long statusAtividadeId);
        void AtualizarStatusAtividadePorLigacaoId(long ligacaoId, int statusAtividadeId);
        Atividade ObterAtividadeCompletaPor(long atividadeId);
        IEnumerable<Atividade> ObterEntidadeCompletaPorProcedimento(string procedimento, DynamicParameters parametros);
        IEnumerable<Atividade> ObterNaoFinalizadasPorOcorrenciaId(long ocorrenciaId);
        IEnumerable<Atividade> ObterPorCliente(long? pessoaFisicaId, long? pessoaJuridicaId, int? quantidade);
        IEnumerable<Atividade> ObterPorOcorrenciaTipoId(long ocorrenciaTipoId);
        ValidationResult RedirecionarFila(string atividadesId, string usuarioId, int filaId);

        //IEnumerable<Atividade> ObterEntidadeCompletaPorProcedimento(string procedimento, DynamicParameters parametros);
        //IEnumerable<Atividade> ObterPorCliente(long? pessoaFisicaId, long? pessoaJuridicaId, int? quantidade);
        //IEnumerable<Atividade> ObterPorOcorrenciaTipoId(long ocorrenciaTipoId);
        //void AtualizarStatusAtividadePorLigacaoId(long ligacaoId, int statusAtividadeId);
        //void AtualizarAtendimentoId(long atividadeId, long atendimentoId);
        //void AtualizarStatus(long atividadeId, long statusAtividadeId);
        //IEnumerable<Atividade> ObterNaoFinalizadasPorOcorrenciaId(long ocorrenciaId);
        //Atividade ObterAtividadeCompletaPor(long atividadeId);
        //void AtualizarCliente(long atividadeId, long? pessoaFisicaid, long? pessoaJuridicaId, string userId);
        //ValidationResult RedirecionarFila(string atividadesId, string usuarioId, int filaId);
    }
}
