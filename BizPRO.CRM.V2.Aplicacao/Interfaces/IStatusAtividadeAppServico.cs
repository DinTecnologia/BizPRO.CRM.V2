using System.Collections.Generic;
using BizPRO.CRM.V2.Aplicacao.ViewModels;
using BizPRO.CRM.V2.Dominio.Entidades;
using DomainValidation.Validation;

namespace BizPRO.CRM.V2.Aplicacao.Interfaces
{
    public interface IStatusAtividadeAppServico
    {
        ValidationResult AtualizarStatusAtividade(long atividadeId, int statusAtividadeId, string userId, int? midiaId,
            long? atendimentoId);

        StatusAtendimentoViewModel Carregar(long atividadeId);
        StatusAtendimentoViewModel CarregarObjeto(string tipo);
        StatusAtendimentoViewModel CarregarStatusAtividadeTipos(long atividadeId, string tipos);
        StatusAtendimentoViewModel ObterStatusAtividadePorId(int statusAtividadeId);
        IEnumerable<StatusAtividade> Obter(int canal, string sentido, bool? padrao);
    }
}
