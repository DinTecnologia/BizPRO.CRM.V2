using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IAtividadeParteEnvolvidaServico
    {
        IEnumerable<AtividadeParteEnvolvida> ObterPorAtividadeId(long atividadeId);
        ValidationResult Adicionar(AtividadeParteEnvolvida entidade);
        AtividadeParteEnvolvida BuscarUltimoClienteTratativa(long atividadeId);
        bool PossuiClienteContato(long atividadeId);
        AtividadeParteEnvolvida BuscarClienteContato(long atividadeId);
        void Excluir(long atividadeId, long? pessoaFisicaId, long? pessoaJuridicaId);
        bool Atualizar(AtividadeParteEnvolvida entidade);
    }
}
