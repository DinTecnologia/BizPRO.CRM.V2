using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;
using System.Collections.Generic;

namespace BizPRO.CRM.V2.Dominio.Interfaces.Servicos
{
    public interface IAtividadeFilaServico : IServico<AtividadeFila>
    {
        IEnumerable<AtividadeFila> ObterPorAtividadeId(long? atividadeId);
        void AtualizaSaiuDaFilaEm(long id);
        ValidationResult AdicionarAtividadeFila(string nomeFila, long atividadeId);
        AtividadeFila ObterUltimoVinculoPraAtividade(long atividadeId);
        void AtualizaSaiuDaFilaPorAtividadeId(long atividadeId);
    }
}
